using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MunicipalServicesApp.Generic;
using MunicipalServicesApp.Models;
using MunicipalServicesApp.Services;
using MunicipalServicesApp.UI;

namespace MunicipalServicesApp.Forms
{
    public partial class ServiceRequestStatusForm : Form
    {
        private readonly ServiceRequestService service;
        private readonly IssueService issueService;

        private ServiceRequest selectedRequest;
        private List<ServiceRequest> currentRequests;
        private bool isLoading;

        private readonly Font boldFont = new Font("Segoe UI", 9F, FontStyle.Bold);

        // Network diagram state
        private Dictionary<string, PointF> areaLayout;
        private Dictionary<string, int> openCountByArea;
        private Dictionary<string, int> visitOrder;
        private List<GraphEdge<string>> highlightedEdges;

        public ServiceRequestStatusForm(
            ServiceRequestService requestService,
            IssueService issues)
        {
            InitializeComponent();

            service = requestService;
            issueService = issues;

            currentRequests = new List<ServiceRequest>();
            visitOrder = new Dictionary<string, int>();
            highlightedEdges = new List<GraphEdge<string>>();
            openCountByArea = new Dictionary<string, int>();

            // Every issue reported in Part 1 becomes a service request.
            service.SyncFromIssues(issueService);

            Theme.Apply(this);

            isLoading = true;

            ConfigureRequestGrid();
            ConfigureHeapGrid();
            LoadFilterOptions();
            BuildDepartmentTree();
            LoadGraphControls();
            LoadExplorerControls();

            isLoading = false;

            RefreshAll();
        }

        // --------------------------------------------------------
        // Setup
        // --------------------------------------------------------
        private void AddGridColumn(
            DataGridView grid,
            string name,
            string header,
            string property,
            float weight)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();

            column.Name = name;
            column.HeaderText = header;
            column.FillWeight = weight;

            if (property != null)
            {
                column.DataPropertyName = property;
            }

            grid.Columns.Add(column);
        }

        private void ConfigureRequestGrid()
        {
            dgvRequests.AutoGenerateColumns = false;
            dgvRequests.Columns.Clear();

            AddGridColumn(dgvRequests, "colId", "Request ID", "RequestId", 11);
            AddGridColumn(dgvRequests, "colTitle", "Title", "Title", 36);
            AddGridColumn(dgvRequests, "colCategory", "Category", "Category", 16);
            AddGridColumn(dgvRequests, "colLocation", "Location", "Location", 16);
            AddGridColumn(dgvRequests, "colStatus", "Status", "StatusText", 13);
            AddGridColumn(dgvRequests, "colPriority", "Priority", "PriorityLabel", 10);
            AddGridColumn(dgvRequests, "colSubmitted", "Submitted", "SubmittedText", 18);
        }

        private void ConfigureHeapGrid()
        {
            dgvHeap.AutoGenerateColumns = false;
            dgvHeap.Columns.Clear();

            AddGridColumn(dgvHeap, "colHeapRank", "Rank", null, 7);
            AddGridColumn(dgvHeap, "colHeapId", "Request ID", null, 12);
            AddGridColumn(dgvHeap, "colHeapTitle", "Title", null, 36);
            AddGridColumn(dgvHeap, "colHeapArea", "Area", null, 16);
            AddGridColumn(dgvHeap, "colHeapPriority", "Priority", null, 11);
            AddGridColumn(dgvHeap, "colHeapStatus", "Status", null, 13);
            AddGridColumn(dgvHeap, "colHeapSubmitted", "Submitted", null, 17);
        }

        private void LoadFilterOptions()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("All Statuses");
            cmbStatus.Items.Add("Submitted");
            cmbStatus.Items.Add("Under Review");
            cmbStatus.Items.Add("In Progress");
            cmbStatus.Items.Add("Completed");
            cmbStatus.SelectedIndex = 0;

            cmbPriority.Items.Clear();
            cmbPriority.Items.Add("All Priorities");
            cmbPriority.Items.Add("Urgent");
            cmbPriority.Items.Add("High");
            cmbPriority.Items.Add("Medium");
            cmbPriority.Items.Add("Low");
            cmbPriority.SelectedIndex = 0;
        }

        // The department tree (a general tree) shown in the TreeView.
        private void BuildDepartmentTree()
        {
            tvDepartments.BeginUpdate();
            tvDepartments.Nodes.Clear();

            TreeNode rootNode = CreateTreeNode(service.GetDepartmentRoot());
            tvDepartments.Nodes.Add(rootNode);

            rootNode.ExpandAll();
            tvDepartments.SelectedNode = rootNode;

            tvDepartments.EndUpdate();
        }

        private TreeNode CreateTreeNode(GeneralTreeNode<string> node)
        {
            int count = service.CountForCategories(service.GetCategoriesUnder(node));

            TreeNode treeNode = new TreeNode(node.Value + "  (" + count + ")");
            treeNode.Tag = node;

            foreach (GeneralTreeNode<string> child in node.Children)
            {
                treeNode.Nodes.Add(CreateTreeNode(child));
            }

            return treeNode;
        }

        private void LoadGraphControls()
        {
            areaLayout = service.GetAreaLayout();

            cmbStartArea.Items.Clear();

            foreach (string area in service.GetAreas())
            {
                cmbStartArea.Items.Add(area);
            }

            int index = cmbStartArea.Items.IndexOf(ServiceRequestService.DefaultArea);
            cmbStartArea.SelectedIndex = index >= 0 ? index : 0;
        }

        private void LoadExplorerControls()
        {
            cmbStructure.Items.Clear();

            foreach (string name in service.GetStructureNames())
            {
                cmbStructure.Items.Add(name);
            }

            cmbStructure.SelectedIndexChanged += cmbStructure_SelectedIndexChanged;
            cmbStructure.SelectedIndex = 0;
        }

        // --------------------------------------------------------
        // Refreshing everything on the page
        // --------------------------------------------------------
        private void RefreshAll()
        {
            UpdateCards();
            ApplyFilters();
            LoadHeapTab();
            RefreshGraph();
            RefreshExplorerInfo();
        }

        private void UpdateCards()
        {
            lblTotalValue.Text = service.TotalCount.ToString();
            lblOpenValue.Text = service.OpenCount.ToString();
            lblInProgressValue.Text = service.InProgressCount.ToString();
            lblDoneValue.Text = service.CompletedCount.ToString();

            lblFooterInfo.Text = "Municipal Services Application  |  " +
                service.TotalCount + " service requests, " +
                service.OpenCount + " still open";
        }

        // --------------------------------------------------------
        // Tab 1: tracking and filtering
        // --------------------------------------------------------
        private List<string> GetSelectedCategories()
        {
            TreeNode selected = tvDepartments.SelectedNode;

            if (selected == null)
            {
                return null;
            }

            GeneralTreeNode<string> node = selected.Tag as GeneralTreeNode<string>;

            // The root means "all departments": no category filter.
            if (node == null || node.Parent == null)
            {
                return null;
            }

            return service.GetCategoriesUnder(node);
        }

        private void ApplyFilters()
        {
            if (isLoading)
            {
                return;
            }

            DateTime? fromDate = null;
            DateTime? toDate = null;

            if (dtpFrom.Checked)
            {
                fromDate = dtpFrom.Value.Date;
            }

            if (dtpTo.Checked)
            {
                toDate = dtpTo.Value.Date;
            }

            if (fromDate.HasValue && toDate.HasValue && fromDate.Value > toDate.Value)
            {
                MessageBox.Show(
                    "The 'From' date must be on or before the 'To' date.",
                    "Invalid Date Range",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            RequestStatus? status = null;

            if (cmbStatus.SelectedIndex > 0)
            {
                status = (RequestStatus)(cmbStatus.SelectedIndex - 1);
            }

            int? priority = null;

            if (cmbPriority.SelectedIndex > 0)
            {
                priority = cmbPriority.SelectedIndex;
            }

            string keepId = selectedRequest != null ? selectedRequest.RequestId : null;

            currentRequests = service.Filter(
                GetSelectedCategories(),
                status,
                priority,
                fromDate,
                toDate);

            dgvRequests.DataSource = null;
            dgvRequests.DataSource = currentRequests;

            lblResultCount.Text = "Showing " + currentRequests.Count +
                " of " + service.TotalCount + " requests";

            SelectRowById(keepId);
        }

        // Selects a row in the grid. Returns false if it is not in the list.
        private bool SelectRowById(string requestId)
        {
            if (requestId == null)
            {
                return false;
            }

            foreach (DataGridViewRow row in dgvRequests.Rows)
            {
                ServiceRequest request = row.DataBoundItem as ServiceRequest;

                if (request != null && request.RequestId == requestId)
                {
                    dgvRequests.CurrentCell = row.Cells[0];
                    row.Selected = true;
                    return true;
                }
            }

            return false;
        }

        private void ResetFilters()
        {
            isLoading = true;

            cmbStatus.SelectedIndex = 0;
            cmbPriority.SelectedIndex = 0;
            dtpFrom.Checked = false;
            dtpTo.Checked = false;

            if (tvDepartments.Nodes.Count > 0)
            {
                tvDepartments.SelectedNode = tvDepartments.Nodes[0];
            }

            isLoading = false;
        }

        private void tvDepartments_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ApplyFilters();
        }

        private void btnApplyFilters_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void btnResetFilters_Click(object sender, EventArgs e)
        {
            ResetFilters();
            lblTrackResult.Text = "";
            ApplyFilters();
        }

        private void txtTrackId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnTrack.PerformClick();
            }
        }

        // Tracks a request by its unique ID using the AVL tree.
        private void btnTrack_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTrackId.Text))
            {
                MessageBox.Show(
                    "Please enter a request ID, for example SR-1004.",
                    "Track Request",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            int comparisons;
            ServiceRequest found = service.TrackRequest(txtTrackId.Text, out comparisons);

            if (found == null)
            {
                lblTrackResult.ForeColor = Color.FromArgb(200, 35, 51);
                lblTrackResult.Text = "No request found for \"" + txtTrackId.Text.Trim() +
                    "\" (searched " + comparisons + " node(s) of the AVL tree).";

                return;
            }

            lblTrackResult.ForeColor = Theme.Accent;
            lblTrackResult.Text = "Found " + found.RequestId + " using the AVL tree in " +
                comparisons + " comparison(s) out of " + service.TotalCount + " requests.";

            // Make sure the request is visible in the list.
            selectedRequest = found;

            if (!SelectRowById(found.RequestId))
            {
                ResetFilters();
                ApplyFilters();
                SelectRowById(found.RequestId);
            }
        }

        private void dgvRequests_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRequests.CurrentRow == null)
            {
                ShowDetails(null);
                return;
            }

            ShowDetails(dgvRequests.CurrentRow.DataBoundItem as ServiceRequest);
        }

        private void dgvRequests_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvRequests.Rows.Count)
            {
                return;
            }

            ServiceRequest request = dgvRequests.Rows[e.RowIndex].DataBoundItem as ServiceRequest;

            if (request == null)
            {
                return;
            }

            string column = dgvRequests.Columns[e.ColumnIndex].Name;

            if (column == "colStatus")
            {
                e.CellStyle.ForeColor = Theme.StatusColor(request.Status);
                e.CellStyle.Font = boldFont;
            }
            else if (column == "colPriority")
            {
                e.CellStyle.ForeColor = Theme.PriorityColor(request.Priority);
                e.CellStyle.Font = boldFont;
            }
        }

        private void ShowDetails(ServiceRequest request)
        {
            selectedRequest = request;

            lstHistory.Items.Clear();

            if (request == null)
            {
                txtDetails.Text = "Select a request to see its details.";
                lblNearby.Text = "";
                btnAdvance.Text = "Move to next stage";
                btnAdvance.Enabled = false;
                pnlProgress.Invalidate();
                return;
            }

            StringBuilder text = new StringBuilder();

            text.AppendLine(request.Title);
            text.AppendLine();
            text.AppendLine("Request ID:   " + request.RequestId);
            text.AppendLine("Department:   " + request.Department + "  (" + request.Category + ")");
            text.AppendLine("Location:       " + request.Location);
            text.AppendLine("Priority:        " + request.PriorityLabel);
            text.AppendLine("Status:          " + request.StatusText);
            text.AppendLine("Submitted:    " + request.SubmittedText);
            text.AppendLine("Last update:  " + request.UpdatedText);

            if (!string.IsNullOrEmpty(request.SourceReference))
            {
                text.AppendLine("Issue ref:      " + request.SourceReference);
            }

            text.AppendLine();
            text.AppendLine(request.Description);

            txtDetails.Text = text.ToString();
            txtDetails.SelectionStart = 0;

            foreach (StatusHistoryEntry entry in request.History)
            {
                lstHistory.Items.Add(entry.ToString());
            }

            int nearby = service.GetNearbyOpenRequests(request).Count;

            lblNearby.Text = "Graph search: " + nearby + " other open request(s) in " +
                request.Area + " or neighbouring areas.";

            if (request.IsOpen)
            {
                RequestStatus next = (RequestStatus)((int)request.Status + 1);
                btnAdvance.Text = "Move to: " + ServiceRequest.StatusToText(next);
                btnAdvance.Enabled = true;
            }
            else
            {
                btnAdvance.Text = "Request completed";
                btnAdvance.Enabled = false;
            }

            pnlProgress.Invalidate();
        }

        // Moves the selected request to its next stage (staff action demo).
        private void btnAdvance_Click(object sender, EventArgs e)
        {
            if (selectedRequest == null)
            {
                return;
            }

            string message;
            service.AdvanceStatus(selectedRequest.RequestId, out message);

            lblTrackResult.ForeColor = Theme.Accent;
            lblTrackResult.Text = message;

            RefreshAll();
        }

        // Draws the four-step progress tracker.
        private void pnlProgress_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            string[] steps = { "Submitted", "Under Review", "In Progress", "Completed" };
            int current = selectedRequest == null ? -1 : (int)selectedRequest.Status;

            int width = pnlProgress.ClientSize.Width;
            int margin = 50;
            int y = 22;
            float stepWidth = (width - 2 * margin) / 3f;

            Color done = Theme.Accent;
            Color waiting = Color.FromArgb(200, 208, 218);

            // Lines between the circles
            for (int i = 0; i < 3; i++)
            {
                using (Pen line = new Pen(i < current ? done : waiting, 4f))
                {
                    g.DrawLine(line, margin + i * stepWidth, y, margin + (i + 1) * stepWidth, y);
                }
            }

            using (Font labelFont = new Font("Segoe UI", 8.5F))
            using (StringFormat center = new StringFormat())
            {
                center.Alignment = StringAlignment.Center;

                for (int i = 0; i < 4; i++)
                {
                    float x = margin + i * stepWidth;
                    bool reached = i <= current;
                    bool isCurrent = i == current;

                    RectangleF circle = new RectangleF(x - 13, y - 13, 26, 26);

                    using (SolidBrush fill = new SolidBrush(reached ? done : Color.White))
                    {
                        g.FillEllipse(fill, circle);
                    }

                    using (Pen outline = new Pen(reached ? done : waiting, 3f))
                    {
                        g.DrawEllipse(outline, circle);
                    }

                    if (isCurrent && i < 3)
                    {
                        // Gold ring around the current stage
                        using (Pen ring = new Pen(Theme.Gold, 3f))
                        {
                            g.DrawEllipse(ring, x - 17, y - 17, 34, 34);
                        }
                    }

                    if (reached)
                    {
                        // Tick mark
                        using (Pen tick = new Pen(Color.White, 3f))
                        {
                            g.DrawLines(tick, new PointF[]
                            {
                                new PointF(x - 6, y),
                                new PointF(x - 2, y + 5),
                                new PointF(x + 6, y - 5)
                            });
                        }
                    }

                    using (SolidBrush textBrush = new SolidBrush(reached ? Theme.TextDark : Theme.TextMuted))
                    {
                        g.DrawString(steps[i], labelFont, textBrush, new RectangleF(x - 50, y + 22, 100, 20), center);
                    }
                }
            }
        }

        // --------------------------------------------------------
        // Tab 2: priority queue (heap)
        // --------------------------------------------------------
        private void LoadHeapTab()
        {
            List<ServiceRequest> ordered = service.GetPriorityOrder();

            dgvHeap.Rows.Clear();

            int rank = 1;

            foreach (ServiceRequest request in ordered)
            {
                int index = dgvHeap.Rows.Add(
                    rank,
                    request.RequestId,
                    request.Title,
                    request.Area,
                    request.PriorityLabel,
                    request.StatusText,
                    request.SubmittedText);

                dgvHeap.Rows[index].Cells["colHeapPriority"].Style.ForeColor =
                    Theme.PriorityColor(request.Priority);
                dgvHeap.Rows[index].Cells["colHeapPriority"].Style.Font = boldFont;

                rank++;
            }

            List<ServiceRequest> heapArray = service.GetHeapArray();

            txtHeapArray.Text = string.Join(
                "   |   ",
                heapArray.Take(14).Select(r => r.RequestId + " (P" + r.Priority + ")"));

            if (heapArray.Count > 14)
            {
                txtHeapArray.Text += "   |   ... " + (heapArray.Count - 14) + " more";
            }

            ServiceRequest top = service.PeekNextRequest();

            if (top == null)
            {
                lblNextInfo.Text = "There are no open requests. Well done!";
                btnProcessNext.Enabled = false;
            }
            else
            {
                lblNextInfo.Text =
                    top.RequestId + "  -  " + top.Title + Environment.NewLine + Environment.NewLine +
                    "Priority: " + top.PriorityLabel + Environment.NewLine +
                    "Status: " + top.StatusText + Environment.NewLine +
                    "Area: " + top.Area;
                btnProcessNext.Enabled = true;
            }

            lblHeapStats.Text =
                "Open requests in the heap: " + ordered.Count + Environment.NewLine +
                "Insert and remove cost O(log n); reading the top costs O(1).";
        }

        private void btnProcessNext_Click(object sender, EventArgs e)
        {
            string message;
            service.ProcessNextRequest(out message);

            RefreshAll();

            lblProcessResult.Text = message;
        }

        // --------------------------------------------------------
        // Tab 3: service network (graph)
        // --------------------------------------------------------
        private void RefreshGraph()
        {
            openCountByArea = service.GetOpenCountByArea();
            pnlGraph.Invalidate();
        }

        private void btnBfs_Click(object sender, EventArgs e)
        {
            string start = cmbStartArea.Text;
            List<KeyValuePair<string, int>> areas = service.GetNearbyAreas(start);

            visitOrder.Clear();
            highlightedEdges.Clear();

            StringBuilder text = new StringBuilder();
            text.AppendLine("BREADTH-FIRST SEARCH from " + start);
            text.AppendLine("Areas are visited by number of roads away.");
            text.AppendLine();

            int order = 1;
            int lastHop = -1;

            foreach (KeyValuePair<string, int> area in areas)
            {
                if (area.Value != lastHop)
                {
                    text.AppendLine("Hop " + area.Value + ":");
                    lastHop = area.Value;
                }

                int open = openCountByArea.ContainsKey(area.Key) ? openCountByArea[area.Key] : 0;
                text.AppendLine("   " + order + ". " + area.Key + "  (" + open + " open)");

                visitOrder[area.Key] = order;
                order++;
            }

            txtGraphOutput.Text = text.ToString();
            pnlGraph.Invalidate();
        }

        private void btnDfs_Click(object sender, EventArgs e)
        {
            string start = cmbStartArea.Text;
            List<string> route = service.GetCoverageRoute(start);

            visitOrder.Clear();
            highlightedEdges.Clear();

            StringBuilder text = new StringBuilder();
            text.AppendLine("DEPTH-FIRST SEARCH from " + start);
            text.AppendLine("A route that goes as deep as possible before backing up.");
            text.AppendLine();

            int order = 1;

            foreach (string area in route)
            {
                int open = openCountByArea.ContainsKey(area) ? openCountByArea[area] : 0;
                text.AppendLine(order + ". " + area + "  (" + open + " open)");

                visitOrder[area] = order;
                order++;
            }

            txtGraphOutput.Text = text.ToString();
            pnlGraph.Invalidate();
        }

        private void btnMst_Click(object sender, EventArgs e)
        {
            double total;
            double allRoads;

            List<GraphEdge<string>> tree = service.GetMinimumSpanningNetwork(out total, out allRoads);

            visitOrder.Clear();
            highlightedEdges = tree;

            StringBuilder text = new StringBuilder();
            text.AppendLine("MINIMUM SPANNING TREE (Kruskal)");
            text.AppendLine("The shortest set of roads that still connects every area.");
            text.AppendLine();

            foreach (GraphEdge<string> edge in tree)
            {
                text.AppendLine(edge.From + " - " + edge.To + "  (" + edge.Weight + " km)");
            }

            text.AppendLine();
            text.AppendLine("Total: " + total + " km");
            text.AppendLine("All roads: " + allRoads + " km");
            text.AppendLine("Saving: " + (allRoads - total) + " km");

            txtGraphOutput.Text = text.ToString();
            pnlGraph.Invalidate();
        }

        private void btnClearGraph_Click(object sender, EventArgs e)
        {
            visitOrder.Clear();
            highlightedEdges.Clear();
            txtGraphOutput.Text = "";
            pnlGraph.Invalidate();
        }

        private bool IsHighlighted(GraphEdge<string> edge)
        {
            foreach (GraphEdge<string> chosen in highlightedEdges)
            {
                if ((chosen.From == edge.From && chosen.To == edge.To) ||
                    (chosen.From == edge.To && chosen.To == edge.From))
                {
                    return true;
                }
            }

            return false;
        }

        // Draws the service area network.
        private void pnlGraph_Paint(object sender, PaintEventArgs e)
        {
            if (areaLayout == null)
            {
                return;
            }

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            int margin = 60;
            int drawWidth = pnlGraph.ClientSize.Width - 2 * margin;
            int drawHeight = pnlGraph.ClientSize.Height - 2 * margin - 14;

            Func<string, PointF> position = area => new PointF(
                margin + areaLayout[area].X * drawWidth,
                margin + areaLayout[area].Y * drawHeight);

            // Roads
            using (Font weightFont = new Font("Segoe UI", 8F))
            using (SolidBrush weightBrush = new SolidBrush(Theme.TextMuted))
            {
                foreach (GraphEdge<string> edge in service.GetRoads())
                {
                    PointF a = position(edge.From);
                    PointF b = position(edge.To);
                    bool chosen = IsHighlighted(edge);

                    using (Pen road = new Pen(
                        chosen ? Theme.Accent : Color.FromArgb(190, 200, 212),
                        chosen ? 4.5f : 1.8f))
                    {
                        g.DrawLine(road, a, b);
                    }

                    g.DrawString(
                        edge.Weight + " km",
                        weightFont,
                        chosen ? new SolidBrush(Theme.Accent) : weightBrush,
                        (a.X + b.X) / 2f - 14,
                        (a.Y + b.Y) / 2f - 14);
                }
            }

            // Areas
            using (Font nameFont = new Font("Segoe UI", 8.5F, FontStyle.Bold))
            using (Font countFont = new Font("Segoe UI", 9.5F, FontStyle.Bold))
            using (Font badgeFont = new Font("Segoe UI", 7.5F, FontStyle.Bold))
            using (StringFormat center = new StringFormat())
            {
                center.Alignment = StringAlignment.Center;
                center.LineAlignment = StringAlignment.Center;

                foreach (string area in service.GetAreas())
                {
                    PointF p = position(area);
                    int open = openCountByArea.ContainsKey(area) ? openCountByArea[area] : 0;

                    Color fill = Color.FromArgb(120, 144, 156);

                    if (open >= 3)
                    {
                        fill = Color.FromArgb(214, 89, 0);
                    }
                    else if (open >= 1)
                    {
                        fill = Theme.Primary;
                    }

                    RectangleF circle = new RectangleF(p.X - 19, p.Y - 19, 38, 38);

                    using (SolidBrush brush = new SolidBrush(fill))
                    {
                        g.FillEllipse(brush, circle);
                    }

                    using (Pen outline = new Pen(Color.White, 2.5f))
                    {
                        g.DrawEllipse(outline, circle);
                    }

                    g.DrawString(open.ToString(), countFont, Brushes.White, circle, center);

                    using (SolidBrush nameBrush = new SolidBrush(Theme.TextDark))
                    {
                        g.DrawString(area, nameFont, nameBrush,
                            new RectangleF(p.X - 60, p.Y + 21, 120, 18), center);
                    }

                    if (visitOrder.ContainsKey(area))
                    {
                        RectangleF badge = new RectangleF(p.X + 10, p.Y - 28, 20, 20);

                        using (SolidBrush gold = new SolidBrush(Theme.Gold))
                        {
                            g.FillEllipse(gold, badge);
                        }

                        g.DrawString(visitOrder[area].ToString(), badgeFont,
                            Brushes.Black, badge, center);
                    }
                }
            }

            // Legend
            using (Font legendFont = new Font("Segoe UI", 8.5F))
            using (SolidBrush legendBrush = new SolidBrush(Theme.TextMuted))
            {
                g.DrawString(
                    "Number in circle = open requests   |   Orange = 3 or more   |   " +
                    "Green roads = minimum spanning tree   |   Gold badge = visit order",
                    legendFont,
                    legendBrush,
                    10,
                    pnlGraph.ClientSize.Height - 22);
            }
        }

        // --------------------------------------------------------
        // Tab 4: data structure explorer
        // --------------------------------------------------------
        private void cmbStructure_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStructure.SelectedItem == null)
            {
                return;
            }

            cmbTraversal.Items.Clear();

            foreach (string option in service.GetTraversalOptions(cmbStructure.Text))
            {
                cmbTraversal.Items.Add(option);
            }

            cmbTraversal.SelectedIndex = 0;

            RefreshExplorerInfo();
            RunSelectedTraversal();
        }

        private void RefreshExplorerInfo()
        {
            if (cmbStructure.SelectedItem == null)
            {
                return;
            }

            txtStructureInfo.Text = service.DescribeStructure(cmbStructure.Text);
            txtStructureInfo.SelectionStart = 0;
        }

        private void RunSelectedTraversal()
        {
            if (cmbStructure.SelectedItem == null || cmbTraversal.SelectedItem == null)
            {
                return;
            }

            List<string> lines = service.RunTraversal(cmbStructure.Text, cmbTraversal.Text);

            lstTraversal.BeginUpdate();
            lstTraversal.Items.Clear();

            int number = 1;

            foreach (string line in lines)
            {
                lstTraversal.Items.Add(line.Length == 0 ? "" : number + ".  " + line);

                if (line.Length > 0)
                {
                    number++;
                }
            }

            lstTraversal.EndUpdate();

            lblTraversalCount.Text = (number - 1) + " item(s)";
        }

        private void btnRunTraversal_Click(object sender, EventArgs e)
        {
            RunSelectedTraversal();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
