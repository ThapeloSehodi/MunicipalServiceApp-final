using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MunicipalServicesApp.UI;
using MunicipalServicesApp.Models;
using MunicipalServicesApp.Services;

namespace MunicipalServicesApp.Forms
{
    public partial class LocalEventsForm : Form
    {
        private EventService eventService;

        // The recommendations currently shown in the list box
        private List<EventRecommendation> currentRecommendations;

        // The priority announcements currently shown in the list box
        private List<LocalEvent> currentUrgent;

        public LocalEventsForm(EventService service)
        {
            InitializeComponent();
            Theme.Apply(this);

            eventService = service;
            currentRecommendations = new List<EventRecommendation>();
            currentUrgent = new List<LocalEvent>();

            ConfigureGrid();
            LoadCategories();

            eventService.QueueUpcomingEvents();

            ShowEvents(eventService.GetUpcomingEvents());
            RefreshInsights();
        }

        // --------------------------------------------------------
        // Setup
        // --------------------------------------------------------
        private void ConfigureGrid()
        {
            dgvEvents.AutoGenerateColumns = false;
            dgvEvents.Columns.Clear();

            AddColumn("Date & Time", "DisplayDate", 22);
            AddColumn("Type", "DisplayType", 12);
            AddColumn("Category", "Category", 12);
            AddColumn("Title", "Title", 34);
            AddColumn("Location", "Location", 28);
            AddColumn("Priority", "PriorityLabel", 10);
        }

        private void AddColumn(string header, string property, float weight)
        {
            DataGridViewTextBoxColumn column =
                new DataGridViewTextBoxColumn();

            column.HeaderText = header;
            column.DataPropertyName = property;
            column.FillWeight = weight;

            dgvEvents.Columns.Add(column);
        }

        private void LoadCategories()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("All Categories");

            foreach (string category in eventService.GetCategories())
            {
                cmbCategory.Items.Add(category);
            }

            cmbCategory.SelectedIndex = 0;
        }

        // --------------------------------------------------------
        // Showing events
        // --------------------------------------------------------
        private void ShowEvents(List<LocalEvent> eventList)
        {
            dgvEvents.DataSource = null;
            dgvEvents.DataSource = eventList;

            int total = eventService.GetUpcomingEvents().Count;
            int dates = eventService.CountUniqueDates(eventList);

            lblStatus.Text = "Showing " + eventList.Count + " of " +
                total + " upcoming item(s) across " + dates +
                " unique date(s)";

            if (eventList.Count == 0)
            {
                txtDetails.Text =
                    "No events matched your search." +
                    Environment.NewLine +
                    "Try a different keyword, category or date range.";
            }
        }

        private void ShowDetails(LocalEvent localEvent)
        {
            if (localEvent == null)
            {
                return;
            }

            StringBuilder text = new StringBuilder();

            text.AppendLine(localEvent.Title);
            text.AppendLine();
            text.AppendLine("Type: " + localEvent.DisplayType +
                            "   |   Category: " + localEvent.Category +
                            "   |   Priority: " + localEvent.PriorityLabel);
            text.AppendLine("When: " + localEvent.DisplayDate);
            text.AppendLine("Where: " + localEvent.Location);
            text.AppendLine();
            text.AppendLine(localEvent.Description);

            txtDetails.Text = text.ToString();
        }

        private void RefreshInsights()
        {
            // Recommendations
            currentRecommendations = eventService.GetRecommendations(4);

            lstRecommendations.Items.Clear();

            foreach (EventRecommendation recommendation
                     in currentRecommendations)
            {
                lstRecommendations.Items.Add(
                    recommendation.Event.EventDate.ToString("dd MMM") +
                    "  -  " + recommendation.Event.Title);
            }

            lblRecReason.Text = currentRecommendations.Count == 0
                ? "No recommendations available yet."
                : "Select a recommendation to see why it was suggested.";

            // Priority queue
            currentUrgent = eventService.GetPriorityEvents(5);

            lstUrgent.Items.Clear();

            foreach (LocalEvent urgent in currentUrgent)
            {
                lstUrgent.Items.Add(
                    "[" + urgent.PriorityLabel + "] " +
                    urgent.EventDate.ToString("dd MMM") + "  -  " +
                    urgent.Title);
            }

            // Stack of recent searches
            lstRecentSearches.Items.Clear();

            foreach (string search in eventService.GetRecentSearches(5))
            {
                lstRecentSearches.Items.Add(search);
            }

            // Interests learned from searches and clicks
            List<string> interests = eventService.GetTopInterests(3);

            lblInterests.Text = interests.Count == 0
                ? "Your interests: none yet - search or click events to " +
                  "get personal recommendations."
                : "Your interests: " + string.Join(", ", interests);

            // Queue
            lblQueue.Text = "Events in queue: " +
                eventService.QueuedEventCount;
        }

        // --------------------------------------------------------
        // Button and control events
        // --------------------------------------------------------
        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime? fromDate = null;
            DateTime? toDate = null;

            if (dtpFromDate.Checked)
            {
                fromDate = dtpFromDate.Value.Date;
            }

            if (dtpToDate.Checked)
            {
                toDate = dtpToDate.Value.Date;
            }

            if (fromDate.HasValue && toDate.HasValue &&
                fromDate.Value > toDate.Value)
            {
                MessageBox.Show(
                    "The 'From Date' must be on or before the 'To Date'.",
                    "Invalid Date Range",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            string category = cmbCategory.SelectedItem as string;

            List<LocalEvent> results = eventService.SearchEvents(
                txtSearch.Text,
                category,
                fromDate,
                toDate);

            ShowEvents(results);
            RefreshInsights();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbCategory.SelectedIndex = 0;
            dtpFromDate.Checked = false;
            dtpToDate.Checked = false;

            ShowEvents(eventService.GetUpcomingEvents());
        }

        private void dgvEvents_DataBindingComplete(
            object sender,
            DataGridViewBindingCompleteEventArgs e)
        {
            // Shade announcements so they stand out from events.
            foreach (DataGridViewRow row in dgvEvents.Rows)
            {
                LocalEvent localEvent = row.DataBoundItem as LocalEvent;

                if (localEvent != null && localEvent.IsAnnouncement)
                {
                    row.DefaultCellStyle.BackColor = Color.LemonChiffon;
                }
            }
        }

        private void dgvEvents_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEvents.CurrentRow == null)
            {
                return;
            }

            ShowDetails(dgvEvents.CurrentRow.DataBoundItem as LocalEvent);
        }

        // Clicking an event tells the recommendation feature what
        // the user is interested in.
        private void dgvEvents_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            LocalEvent clicked =
                dgvEvents.Rows[e.RowIndex].DataBoundItem as LocalEvent;

            if (clicked == null)
            {
                return;
            }

            eventService.RecordView(clicked.EventId);
            RefreshInsights();
        }

        private void lstRecommendations_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            int index = lstRecommendations.SelectedIndex;

            if (index < 0 || index >= currentRecommendations.Count)
            {
                return;
            }

            EventRecommendation recommendation =
                currentRecommendations[index];

            lblRecReason.Text = recommendation.Reason;
            ShowDetails(recommendation.Event);
        }

        private void lstRecentSearches_DoubleClick(
            object sender,
            EventArgs e)
        {
            string search = lstRecentSearches.SelectedItem as string;

            if (string.IsNullOrEmpty(search))
            {
                return;
            }

            txtSearch.Text = search;
            btnSearch.PerformClick();
        }

        private void btnNextEvent_Click(object sender, EventArgs e)
        {
            LocalEvent next = eventService.GetNextQueuedEvent();

            if (next == null)
            {
                // The queue is empty, so start again from the beginning.
                eventService.QueueUpcomingEvents();
                next = eventService.GetNextQueuedEvent();

                MessageBox.Show(
                    "You have reached the end of the queue. " +
                    "Starting again from the first upcoming event.",
                    "Queue Restarted",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            if (next != null)
            {
                // Highlight the event in the grid if it is being shown.
                foreach (DataGridViewRow row in dgvEvents.Rows)
                {
                    LocalEvent rowEvent = row.DataBoundItem as LocalEvent;

                    if (rowEvent != null &&
                        rowEvent.EventId == next.EventId)
                    {
                        dgvEvents.CurrentCell = row.Cells[0];
                        break;
                    }
                }

                ShowDetails(next);
            }

            lblQueue.Text = "Events in queue: " +
                eventService.QueuedEventCount;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
