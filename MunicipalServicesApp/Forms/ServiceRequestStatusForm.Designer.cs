namespace MunicipalServicesApp.Forms
{
    partial class ServiceRequestStatusForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabTrack = new System.Windows.Forms.TabPage();
            this.tabHeap = new System.Windows.Forms.TabPage();
            this.tabGraph = new System.Windows.Forms.TabPage();
            this.tabStructures = new System.Windows.Forms.TabPage();
            this.tvDepartments = new System.Windows.Forms.TreeView();
            this.grpTrack = new System.Windows.Forms.GroupBox();
            this.txtTrackId = new System.Windows.Forms.TextBox();
            this.btnTrack = new System.Windows.Forms.Button();
            this.pnlCardTotal = new System.Windows.Forms.Panel();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.lblTotalCaption = new System.Windows.Forms.Label();
            this.pnlCardOpen = new System.Windows.Forms.Panel();
            this.lblOpenValue = new System.Windows.Forms.Label();
            this.lblOpenCaption = new System.Windows.Forms.Label();
            this.pnlCardInProgress = new System.Windows.Forms.Panel();
            this.lblInProgressValue = new System.Windows.Forms.Label();
            this.lblInProgressCaption = new System.Windows.Forms.Label();
            this.pnlCardDone = new System.Windows.Forms.Panel();
            this.lblDoneValue = new System.Windows.Forms.Label();
            this.lblDoneCaption = new System.Windows.Forms.Label();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.lblStatusFilter = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblPriorityFilter = new System.Windows.Forms.Label();
            this.cmbPriority = new System.Windows.Forms.ComboBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnApplyFilters = new System.Windows.Forms.Button();
            this.btnResetFilters = new System.Windows.Forms.Button();
            this.lblResultCount = new System.Windows.Forms.Label();
            this.lblTrackResult = new System.Windows.Forms.Label();
            this.dgvRequests = new System.Windows.Forms.DataGridView();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.txtDetails = new System.Windows.Forms.TextBox();
            this.btnAdvance = new System.Windows.Forms.Button();
            this.lblNearby = new System.Windows.Forms.Label();
            this.pnlProgress = new MunicipalServicesApp.UI.BufferedPanel();
            this.lstHistory = new System.Windows.Forms.ListBox();
            this.lblHeapIntro = new System.Windows.Forms.Label();
            this.dgvHeap = new System.Windows.Forms.DataGridView();
            this.lblHeapArrayCaption = new System.Windows.Forms.Label();
            this.txtHeapArray = new System.Windows.Forms.TextBox();
            this.grpNext = new System.Windows.Forms.GroupBox();
            this.lblNextInfo = new System.Windows.Forms.Label();
            this.btnProcessNext = new System.Windows.Forms.Button();
            this.lblProcessResult = new System.Windows.Forms.Label();
            this.lblHeapStats = new System.Windows.Forms.Label();
            this.pnlGraph = new MunicipalServicesApp.UI.BufferedPanel();
            this.grpGraph = new System.Windows.Forms.GroupBox();
            this.lblStartArea = new System.Windows.Forms.Label();
            this.cmbStartArea = new System.Windows.Forms.ComboBox();
            this.btnBfs = new System.Windows.Forms.Button();
            this.btnDfs = new System.Windows.Forms.Button();
            this.btnMst = new System.Windows.Forms.Button();
            this.btnClearGraph = new System.Windows.Forms.Button();
            this.txtGraphOutput = new System.Windows.Forms.TextBox();
            this.lblStructure = new System.Windows.Forms.Label();
            this.cmbStructure = new System.Windows.Forms.ComboBox();
            this.lblTraversal = new System.Windows.Forms.Label();
            this.cmbTraversal = new System.Windows.Forms.ComboBox();
            this.btnRunTraversal = new System.Windows.Forms.Button();
            this.lblTraversalCount = new System.Windows.Forms.Label();
            this.lstTraversal = new System.Windows.Forms.ListBox();
            this.txtStructureInfo = new System.Windows.Forms.TextBox();
            this.lblFooterInfo = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.appHeader = new MunicipalServicesApp.UI.AppHeader();
            this.tabMain.SuspendLayout();
            this.tabTrack.SuspendLayout();
            this.tabHeap.SuspendLayout();
            this.tabGraph.SuspendLayout();
            this.tabStructures.SuspendLayout();
            this.grpTrack.SuspendLayout();
            this.pnlCardTotal.SuspendLayout();
            this.pnlCardOpen.SuspendLayout();
            this.pnlCardInProgress.SuspendLayout();
            this.pnlCardDone.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.grpDetails.SuspendLayout();
            this.pnlProgress.SuspendLayout();
            this.grpNext.SuspendLayout();
            this.pnlGraph.SuspendLayout();
            this.grpGraph.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHeap)).BeginInit();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabTrack);
            this.tabMain.Controls.Add(this.tabHeap);
            this.tabMain.Controls.Add(this.tabGraph);
            this.tabMain.Controls.Add(this.tabStructures);
            this.tabMain.Font = new System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMain.ItemSize = new System.Drawing.Size(190, 28);
            this.tabMain.Location = new System.Drawing.Point(12, 84);
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1136, 556);
            this.tabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabMain.Name = "tabMain";
            this.tabMain.TabIndex = 0;
            // 
            // tabTrack
            // 
            this.tabTrack.Controls.Add(this.tvDepartments);
            this.tabTrack.Controls.Add(this.grpTrack);
            this.tabTrack.Controls.Add(this.pnlCardTotal);
            this.tabTrack.Controls.Add(this.pnlCardOpen);
            this.tabTrack.Controls.Add(this.pnlCardInProgress);
            this.tabTrack.Controls.Add(this.pnlCardDone);
            this.tabTrack.Controls.Add(this.grpFilter);
            this.tabTrack.Controls.Add(this.lblResultCount);
            this.tabTrack.Controls.Add(this.lblTrackResult);
            this.tabTrack.Controls.Add(this.dgvRequests);
            this.tabTrack.Controls.Add(this.grpDetails);
            this.tabTrack.BackColor = System.Drawing.Color.FromArgb(238, 243, 248);
            this.tabTrack.Padding = new System.Windows.Forms.Padding(3);
            this.tabTrack.Text = "Track Requests";
            this.tabTrack.UseVisualStyleBackColor = false;
            this.tabTrack.Name = "tabTrack";
            this.tabTrack.TabIndex = 1;
            // 
            // tabHeap
            // 
            this.tabHeap.Controls.Add(this.lblHeapIntro);
            this.tabHeap.Controls.Add(this.dgvHeap);
            this.tabHeap.Controls.Add(this.lblHeapArrayCaption);
            this.tabHeap.Controls.Add(this.txtHeapArray);
            this.tabHeap.Controls.Add(this.grpNext);
            this.tabHeap.Controls.Add(this.lblHeapStats);
            this.tabHeap.BackColor = System.Drawing.Color.FromArgb(238, 243, 248);
            this.tabHeap.Padding = new System.Windows.Forms.Padding(3);
            this.tabHeap.Text = "Priority Queue (Heap)";
            this.tabHeap.UseVisualStyleBackColor = false;
            this.tabHeap.Name = "tabHeap";
            this.tabHeap.TabIndex = 2;
            // 
            // tabGraph
            // 
            this.tabGraph.Controls.Add(this.pnlGraph);
            this.tabGraph.Controls.Add(this.grpGraph);
            this.tabGraph.BackColor = System.Drawing.Color.FromArgb(238, 243, 248);
            this.tabGraph.Padding = new System.Windows.Forms.Padding(3);
            this.tabGraph.Text = "Service Network (Graph)";
            this.tabGraph.UseVisualStyleBackColor = false;
            this.tabGraph.Name = "tabGraph";
            this.tabGraph.TabIndex = 3;
            // 
            // tabStructures
            // 
            this.tabStructures.Controls.Add(this.lblStructure);
            this.tabStructures.Controls.Add(this.cmbStructure);
            this.tabStructures.Controls.Add(this.lblTraversal);
            this.tabStructures.Controls.Add(this.cmbTraversal);
            this.tabStructures.Controls.Add(this.btnRunTraversal);
            this.tabStructures.Controls.Add(this.lblTraversalCount);
            this.tabStructures.Controls.Add(this.lstTraversal);
            this.tabStructures.Controls.Add(this.txtStructureInfo);
            this.tabStructures.BackColor = System.Drawing.Color.FromArgb(238, 243, 248);
            this.tabStructures.Padding = new System.Windows.Forms.Padding(3);
            this.tabStructures.Text = "Data Structures";
            this.tabStructures.UseVisualStyleBackColor = false;
            this.tabStructures.Name = "tabStructures";
            this.tabStructures.TabIndex = 4;
            // 
            // tvDepartments
            // 
            this.tvDepartments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tvDepartments.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvDepartments.HideSelection = false;
            this.tvDepartments.ItemHeight = 26;
            this.tvDepartments.Location = new System.Drawing.Point(6, 6);
            this.tvDepartments.ShowLines = true;
            this.tvDepartments.Size = new System.Drawing.Size(200, 510);
            this.tvDepartments.Name = "tvDepartments";
            this.tvDepartments.TabIndex = 5;
            this.tvDepartments.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDepartments_AfterSelect);
            // 
            // grpTrack
            // 
            this.grpTrack.Controls.Add(this.txtTrackId);
            this.grpTrack.Controls.Add(this.btnTrack);
            this.grpTrack.Font = new System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTrack.Location = new System.Drawing.Point(214, 2);
            this.grpTrack.Size = new System.Drawing.Size(330, 56);
            this.grpTrack.TabStop = false;
            this.grpTrack.Text = "Track a request by ID";
            this.grpTrack.Name = "grpTrack";
            this.grpTrack.TabIndex = 6;
            // 
            // txtTrackId
            // 
            this.txtTrackId.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrackId.Location = new System.Drawing.Point(10, 22);
            this.txtTrackId.Size = new System.Drawing.Size(190, 25);
            this.txtTrackId.Name = "txtTrackId";
            this.txtTrackId.TabIndex = 7;
            this.txtTrackId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTrackId_KeyDown);
            // 
            // btnTrack
            // 
            this.btnTrack.Font = new System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrack.Location = new System.Drawing.Point(208, 20);
            this.btnTrack.Size = new System.Drawing.Size(110, 28);
            this.btnTrack.Text = "Track";
            this.btnTrack.UseVisualStyleBackColor = true;
            this.btnTrack.Name = "btnTrack";
            this.btnTrack.TabIndex = 8;
            this.btnTrack.Click += new System.EventHandler(this.btnTrack_Click);
            // 
            // pnlCardTotal
            // 
            this.pnlCardTotal.Controls.Add(this.lblTotalValue);
            this.pnlCardTotal.Controls.Add(this.lblTotalCaption);
            this.pnlCardTotal.BackColor = System.Drawing.Color.White;
            this.pnlCardTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardTotal.Location = new System.Drawing.Point(560, 2);
            this.pnlCardTotal.Size = new System.Drawing.Size(128, 56);
            this.pnlCardTotal.Name = "pnlCardTotal";
            this.pnlCardTotal.TabIndex = 9;
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.AutoSize = true;
            this.lblTotalValue.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalValue.ForeColor = System.Drawing.Color.FromArgb(12, 74, 110);
            this.lblTotalValue.Location = new System.Drawing.Point(8, 2);
            this.lblTotalValue.Text = "0";
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.TabIndex = 10;
            // 
            // lblTotalCaption
            // 
            this.lblTotalCaption.AutoSize = true;
            this.lblTotalCaption.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCaption.ForeColor = System.Drawing.Color.FromArgb(98, 112, 128);
            this.lblTotalCaption.Location = new System.Drawing.Point(10, 35);
            this.lblTotalCaption.Text = "Total requests";
            this.lblTotalCaption.Name = "lblTotalCaption";
            this.lblTotalCaption.TabIndex = 11;
            // 
            // pnlCardOpen
            // 
            this.pnlCardOpen.Controls.Add(this.lblOpenValue);
            this.pnlCardOpen.Controls.Add(this.lblOpenCaption);
            this.pnlCardOpen.BackColor = System.Drawing.Color.White;
            this.pnlCardOpen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardOpen.Location = new System.Drawing.Point(694, 2);
            this.pnlCardOpen.Size = new System.Drawing.Size(128, 56);
            this.pnlCardOpen.Name = "pnlCardOpen";
            this.pnlCardOpen.TabIndex = 12;
            // 
            // lblOpenValue
            // 
            this.lblOpenValue.AutoSize = true;
            this.lblOpenValue.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpenValue.ForeColor = System.Drawing.Color.FromArgb(205, 125, 0);
            this.lblOpenValue.Location = new System.Drawing.Point(8, 2);
            this.lblOpenValue.Text = "0";
            this.lblOpenValue.Name = "lblOpenValue";
            this.lblOpenValue.TabIndex = 13;
            // 
            // lblOpenCaption
            // 
            this.lblOpenCaption.AutoSize = true;
            this.lblOpenCaption.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpenCaption.ForeColor = System.Drawing.Color.FromArgb(98, 112, 128);
            this.lblOpenCaption.Location = new System.Drawing.Point(10, 35);
            this.lblOpenCaption.Text = "Still open";
            this.lblOpenCaption.Name = "lblOpenCaption";
            this.lblOpenCaption.TabIndex = 14;
            // 
            // pnlCardInProgress
            // 
            this.pnlCardInProgress.Controls.Add(this.lblInProgressValue);
            this.pnlCardInProgress.Controls.Add(this.lblInProgressCaption);
            this.pnlCardInProgress.BackColor = System.Drawing.Color.White;
            this.pnlCardInProgress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardInProgress.Location = new System.Drawing.Point(828, 2);
            this.pnlCardInProgress.Size = new System.Drawing.Size(128, 56);
            this.pnlCardInProgress.Name = "pnlCardInProgress";
            this.pnlCardInProgress.TabIndex = 15;
            // 
            // lblInProgressValue
            // 
            this.lblInProgressValue.AutoSize = true;
            this.lblInProgressValue.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInProgressValue.ForeColor = System.Drawing.Color.FromArgb(13, 110, 185);
            this.lblInProgressValue.Location = new System.Drawing.Point(8, 2);
            this.lblInProgressValue.Text = "0";
            this.lblInProgressValue.Name = "lblInProgressValue";
            this.lblInProgressValue.TabIndex = 16;
            // 
            // lblInProgressCaption
            // 
            this.lblInProgressCaption.AutoSize = true;
            this.lblInProgressCaption.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInProgressCaption.ForeColor = System.Drawing.Color.FromArgb(98, 112, 128);
            this.lblInProgressCaption.Location = new System.Drawing.Point(10, 35);
            this.lblInProgressCaption.Text = "In progress";
            this.lblInProgressCaption.Name = "lblInProgressCaption";
            this.lblInProgressCaption.TabIndex = 17;
            // 
            // pnlCardDone
            // 
            this.pnlCardDone.Controls.Add(this.lblDoneValue);
            this.pnlCardDone.Controls.Add(this.lblDoneCaption);
            this.pnlCardDone.BackColor = System.Drawing.Color.White;
            this.pnlCardDone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardDone.Location = new System.Drawing.Point(962, 2);
            this.pnlCardDone.Size = new System.Drawing.Size(128, 56);
            this.pnlCardDone.Name = "pnlCardDone";
            this.pnlCardDone.TabIndex = 18;
            // 
            // lblDoneValue
            // 
            this.lblDoneValue.AutoSize = true;
            this.lblDoneValue.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoneValue.ForeColor = System.Drawing.Color.FromArgb(0, 122, 77);
            this.lblDoneValue.Location = new System.Drawing.Point(8, 2);
            this.lblDoneValue.Text = "0";
            this.lblDoneValue.Name = "lblDoneValue";
            this.lblDoneValue.TabIndex = 19;
            // 
            // lblDoneCaption
            // 
            this.lblDoneCaption.AutoSize = true;
            this.lblDoneCaption.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoneCaption.ForeColor = System.Drawing.Color.FromArgb(98, 112, 128);
            this.lblDoneCaption.Location = new System.Drawing.Point(10, 35);
            this.lblDoneCaption.Text = "Completed";
            this.lblDoneCaption.Name = "lblDoneCaption";
            this.lblDoneCaption.TabIndex = 20;
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.lblStatusFilter);
            this.grpFilter.Controls.Add(this.cmbStatus);
            this.grpFilter.Controls.Add(this.lblPriorityFilter);
            this.grpFilter.Controls.Add(this.cmbPriority);
            this.grpFilter.Controls.Add(this.lblFrom);
            this.grpFilter.Controls.Add(this.dtpFrom);
            this.grpFilter.Controls.Add(this.lblTo);
            this.grpFilter.Controls.Add(this.dtpTo);
            this.grpFilter.Controls.Add(this.btnApplyFilters);
            this.grpFilter.Controls.Add(this.btnResetFilters);
            this.grpFilter.Font = new System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFilter.Location = new System.Drawing.Point(214, 62);
            this.grpFilter.Size = new System.Drawing.Size(900, 54);
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Filter requests";
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.TabIndex = 21;
            // 
            // lblStatusFilter
            // 
            this.lblStatusFilter.AutoSize = true;
            this.lblStatusFilter.Font = new System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusFilter.Location = new System.Drawing.Point(10, 25);
            this.lblStatusFilter.Text = "Status:";
            this.lblStatusFilter.Name = "lblStatusFilter";
            this.lblStatusFilter.TabIndex = 22;
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(58, 21);
            this.cmbStatus.Size = new System.Drawing.Size(120, 23);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.TabIndex = 23;
            // 
            // lblPriorityFilter
            // 
            this.lblPriorityFilter.AutoSize = true;
            this.lblPriorityFilter.Font = new System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriorityFilter.Location = new System.Drawing.Point(192, 25);
            this.lblPriorityFilter.Text = "Priority:";
            this.lblPriorityFilter.Name = "lblPriorityFilter";
            this.lblPriorityFilter.TabIndex = 24;
            // 
            // cmbPriority
            // 
            this.cmbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPriority.Font = new System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPriority.FormattingEnabled = true;
            this.cmbPriority.Location = new System.Drawing.Point(246, 21);
            this.cmbPriority.Size = new System.Drawing.Size(110, 23);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.TabIndex = 25;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(372, 25);
            this.lblFrom.Text = "From:";
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.TabIndex = 26;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Checked = false;
            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(412, 21);
            this.dtpFrom.ShowCheckBox = true;
            this.dtpFrom.Size = new System.Drawing.Size(130, 23);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.TabIndex = 27;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(554, 25);
            this.lblTo.Text = "To:";
            this.lblTo.Name = "lblTo";
            this.lblTo.TabIndex = 28;
            // 
            // dtpTo
            // 
            this.dtpTo.Checked = false;
            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(580, 21);
            this.dtpTo.ShowCheckBox = true;
            this.dtpTo.Size = new System.Drawing.Size(130, 23);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.TabIndex = 29;
            // 
            // btnApplyFilters
            // 
            this.btnApplyFilters.Font = new System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyFilters.Location = new System.Drawing.Point(726, 19);
            this.btnApplyFilters.Size = new System.Drawing.Size(78, 28);
            this.btnApplyFilters.Text = "Apply";
            this.btnApplyFilters.UseVisualStyleBackColor = true;
            this.btnApplyFilters.Name = "btnApplyFilters";
            this.btnApplyFilters.TabIndex = 30;
            this.btnApplyFilters.Click += new System.EventHandler(this.btnApplyFilters_Click);
            // 
            // btnResetFilters
            // 
            this.btnResetFilters.Font = new System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetFilters.Location = new System.Drawing.Point(812, 19);
            this.btnResetFilters.Size = new System.Drawing.Size(78, 28);
            this.btnResetFilters.Text = "Reset";
            this.btnResetFilters.UseVisualStyleBackColor = true;
            this.btnResetFilters.Name = "btnResetFilters";
            this.btnResetFilters.TabIndex = 31;
            this.btnResetFilters.Click += new System.EventHandler(this.btnResetFilters_Click);
            // 
            // lblResultCount
            // 
            this.lblResultCount.AutoSize = true;
            this.lblResultCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultCount.Location = new System.Drawing.Point(214, 121);
            this.lblResultCount.Text = "Showing 0 requests";
            this.lblResultCount.ForeColor = System.Drawing.Color.FromArgb(30, 41, 54);
            this.lblResultCount.Name = "lblResultCount";
            this.lblResultCount.TabIndex = 32;
            // 
            // lblTrackResult
            // 
            this.lblTrackResult.AutoSize = true;
            this.lblTrackResult.Font = new System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrackResult.Location = new System.Drawing.Point(500, 121);
            this.lblTrackResult.Text = "";
            this.lblTrackResult.ForeColor = System.Drawing.Color.FromArgb(98, 112, 128);
            this.lblTrackResult.Name = "lblTrackResult";
            this.lblTrackResult.TabIndex = 33;
            // 
            // dgvRequests
            // 
            this.dgvRequests.AllowUserToAddRows = false;
            this.dgvRequests.AllowUserToDeleteRows = false;
            this.dgvRequests.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRequests.BackgroundColor = System.Drawing.Color.White;
            this.dgvRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRequests.Font = new System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvRequests.Location = new System.Drawing.Point(214, 142);
            this.dgvRequests.MultiSelect = false;
            this.dgvRequests.ReadOnly = true;
            this.dgvRequests.RowHeadersVisible = false;
            this.dgvRequests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRequests.Size = new System.Drawing.Size(900, 206);
            this.dgvRequests.Name = "dgvRequests";
            this.dgvRequests.TabIndex = 34;
            this.dgvRequests.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvRequests_CellFormatting);
            this.dgvRequests.SelectionChanged += new System.EventHandler(this.dgvRequests_SelectionChanged);
            // 
            // grpDetails
            // 
            this.grpDetails.Controls.Add(this.txtDetails);
            this.grpDetails.Controls.Add(this.btnAdvance);
            this.grpDetails.Controls.Add(this.lblNearby);
            this.grpDetails.Controls.Add(this.pnlProgress);
            this.grpDetails.Controls.Add(this.lstHistory);
            this.grpDetails.Font = new System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDetails.Location = new System.Drawing.Point(214, 354);
            this.grpDetails.Size = new System.Drawing.Size(900, 168);
            this.grpDetails.TabStop = false;
            this.grpDetails.Text = "Request details and progress";
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.TabIndex = 35;
            // 
            // txtDetails
            // 
            this.txtDetails.BackColor = System.Drawing.Color.White;
            this.txtDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetails.Font = new System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetails.Location = new System.Drawing.Point(8, 20);
            this.txtDetails.Multiline = true;
            this.txtDetails.ReadOnly = true;
            this.txtDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetails.Size = new System.Drawing.Size(420, 108);
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.TabIndex = 36;
            // 
            // btnAdvance
            // 
            this.btnAdvance.Font = new System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdvance.Location = new System.Drawing.Point(8, 134);
            this.btnAdvance.Size = new System.Drawing.Size(200, 28);
            this.btnAdvance.Text = "Move to next stage";
            this.btnAdvance.UseVisualStyleBackColor = true;
            this.btnAdvance.Name = "btnAdvance";
            this.btnAdvance.TabIndex = 37;
            this.btnAdvance.Click += new System.EventHandler(this.btnAdvance_Click);
            // 
            // lblNearby
            // 
            this.lblNearby.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNearby.Location = new System.Drawing.Point(216, 134);
            this.lblNearby.Size = new System.Drawing.Size(212, 30);
            this.lblNearby.Text = "";
            this.lblNearby.ForeColor = System.Drawing.Color.FromArgb(98, 112, 128);
            this.lblNearby.Name = "lblNearby";
            this.lblNearby.TabIndex = 38;
            // 
            // pnlProgress
            // 
            this.pnlProgress.BackColor = System.Drawing.Color.White;
            this.pnlProgress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlProgress.Location = new System.Drawing.Point(440, 20);
            this.pnlProgress.Size = new System.Drawing.Size(452, 72);
            this.pnlProgress.Name = "pnlProgress";
            this.pnlProgress.TabIndex = 39;
            this.pnlProgress.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlProgress_Paint);
            // 
            // lstHistory
            // 
            this.lstHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstHistory.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstHistory.FormattingEnabled = true;
            this.lstHistory.HorizontalScrollbar = true;
            this.lstHistory.IntegralHeight = false;
            this.lstHistory.Location = new System.Drawing.Point(440, 98);
            this.lstHistory.Size = new System.Drawing.Size(452, 64);
            this.lstHistory.Name = "lstHistory";
            this.lstHistory.TabIndex = 40;
            // 
            // lblHeapIntro
            // 
            this.lblHeapIntro.Font = new System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeapIntro.Location = new System.Drawing.Point(10, 8);
            this.lblHeapIntro.Size = new System.Drawing.Size(1100, 36);
            this.lblHeapIntro.Text = "Open requests are stored in a binary min-heap. The most urgent request (Urgent first, then High, Medium and Low; oldest first when the priority is the same) is always at the top and is served next.";
            this.lblHeapIntro.ForeColor = System.Drawing.Color.FromArgb(30, 41, 54);
            this.lblHeapIntro.Name = "lblHeapIntro";
            this.lblHeapIntro.TabIndex = 41;
            // 
            // dgvHeap
            // 
            this.dgvHeap.AllowUserToAddRows = false;
            this.dgvHeap.AllowUserToDeleteRows = false;
            this.dgvHeap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHeap.BackgroundColor = System.Drawing.Color.White;
            this.dgvHeap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHeap.Font = new System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvHeap.Location = new System.Drawing.Point(10, 48);
            this.dgvHeap.MultiSelect = false;
            this.dgvHeap.ReadOnly = true;
            this.dgvHeap.RowHeadersVisible = false;
            this.dgvHeap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHeap.Size = new System.Drawing.Size(740, 300);
            this.dgvHeap.Name = "dgvHeap";
            this.dgvHeap.TabIndex = 42;
            // 
            // lblHeapArrayCaption
            // 
            this.lblHeapArrayCaption.AutoSize = true;
            this.lblHeapArrayCaption.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeapArrayCaption.Location = new System.Drawing.Point(10, 358);
            this.lblHeapArrayCaption.Text = "Heap array (level by level, as stored in memory):";
            this.lblHeapArrayCaption.ForeColor = System.Drawing.Color.FromArgb(30, 41, 54);
            this.lblHeapArrayCaption.Name = "lblHeapArrayCaption";
            this.lblHeapArrayCaption.TabIndex = 43;
            // 
            // txtHeapArray
            // 
            this.txtHeapArray.BackColor = System.Drawing.Color.White;
            this.txtHeapArray.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHeapArray.Font = new System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHeapArray.Location = new System.Drawing.Point(10, 378);
            this.txtHeapArray.Multiline = true;
            this.txtHeapArray.ReadOnly = true;
            this.txtHeapArray.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHeapArray.Size = new System.Drawing.Size(740, 70);
            this.txtHeapArray.Name = "txtHeapArray";
            this.txtHeapArray.TabIndex = 44;
            // 
            // grpNext
            // 
            this.grpNext.Controls.Add(this.lblNextInfo);
            this.grpNext.Controls.Add(this.btnProcessNext);
            this.grpNext.Controls.Add(this.lblProcessResult);
            this.grpNext.Font = new System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpNext.Location = new System.Drawing.Point(766, 48);
            this.grpNext.Size = new System.Drawing.Size(350, 262);
            this.grpNext.TabStop = false;
            this.grpNext.Text = "Next request to be handled";
            this.grpNext.Name = "grpNext";
            this.grpNext.TabIndex = 45;
            // 
            // lblNextInfo
            // 
            this.lblNextInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextInfo.Location = new System.Drawing.Point(12, 26);
            this.lblNextInfo.Size = new System.Drawing.Size(326, 130);
            this.lblNextInfo.Text = "";
            this.lblNextInfo.ForeColor = System.Drawing.Color.FromArgb(30, 41, 54);
            this.lblNextInfo.Name = "lblNextInfo";
            this.lblNextInfo.TabIndex = 46;
            // 
            // btnProcessNext
            // 
            this.btnProcessNext.Font = new System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcessNext.Location = new System.Drawing.Point(12, 166);
            this.btnProcessNext.Size = new System.Drawing.Size(220, 32);
            this.btnProcessNext.Text = "Process next request";
            this.btnProcessNext.UseVisualStyleBackColor = true;
            this.btnProcessNext.Name = "btnProcessNext";
            this.btnProcessNext.TabIndex = 47;
            this.btnProcessNext.Click += new System.EventHandler(this.btnProcessNext_Click);
            // 
            // lblProcessResult
            // 
            this.lblProcessResult.Font = new System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcessResult.Location = new System.Drawing.Point(12, 208);
            this.lblProcessResult.Size = new System.Drawing.Size(326, 44);
            this.lblProcessResult.Text = "";
            this.lblProcessResult.ForeColor = System.Drawing.Color.FromArgb(98, 112, 128);
            this.lblProcessResult.Name = "lblProcessResult";
            this.lblProcessResult.TabIndex = 48;
            // 
            // lblHeapStats
            // 
            this.lblHeapStats.Font = new System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeapStats.Location = new System.Drawing.Point(766, 322);
            this.lblHeapStats.Size = new System.Drawing.Size(350, 70);
            this.lblHeapStats.Text = "";
            this.lblHeapStats.ForeColor = System.Drawing.Color.FromArgb(30, 41, 54);
            this.lblHeapStats.Name = "lblHeapStats";
            this.lblHeapStats.TabIndex = 49;
            // 
            // pnlGraph
            // 
            this.pnlGraph.BackColor = System.Drawing.Color.White;
            this.pnlGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGraph.Location = new System.Drawing.Point(10, 10);
            this.pnlGraph.Size = new System.Drawing.Size(760, 506);
            this.pnlGraph.Name = "pnlGraph";
            this.pnlGraph.TabIndex = 50;
            this.pnlGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlGraph_Paint);
            // 
            // grpGraph
            // 
            this.grpGraph.Controls.Add(this.lblStartArea);
            this.grpGraph.Controls.Add(this.cmbStartArea);
            this.grpGraph.Controls.Add(this.btnBfs);
            this.grpGraph.Controls.Add(this.btnDfs);
            this.grpGraph.Controls.Add(this.btnMst);
            this.grpGraph.Controls.Add(this.btnClearGraph);
            this.grpGraph.Controls.Add(this.txtGraphOutput);
            this.grpGraph.Font = new System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpGraph.Location = new System.Drawing.Point(786, 10);
            this.grpGraph.Size = new System.Drawing.Size(330, 506);
            this.grpGraph.TabStop = false;
            this.grpGraph.Text = "Explore the service network";
            this.grpGraph.Name = "grpGraph";
            this.grpGraph.TabIndex = 51;
            // 
            // lblStartArea
            // 
            this.lblStartArea.AutoSize = true;
            this.lblStartArea.Font = new System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartArea.Location = new System.Drawing.Point(12, 26);
            this.lblStartArea.Text = "Start area:";
            this.lblStartArea.Name = "lblStartArea";
            this.lblStartArea.TabIndex = 52;
            // 
            // cmbStartArea
            // 
            this.cmbStartArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStartArea.Font = new System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStartArea.FormattingEnabled = true;
            this.cmbStartArea.Location = new System.Drawing.Point(12, 44);
            this.cmbStartArea.Size = new System.Drawing.Size(300, 23);
            this.cmbStartArea.Name = "cmbStartArea";
            this.cmbStartArea.TabIndex = 53;
            // 
            // btnBfs
            // 
            this.btnBfs.Font = new System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBfs.Location = new System.Drawing.Point(12, 80);
            this.btnBfs.Size = new System.Drawing.Size(300, 30);
            this.btnBfs.Text = "Nearby areas (Breadth-First Search)";
            this.btnBfs.UseVisualStyleBackColor = true;
            this.btnBfs.Name = "btnBfs";
            this.btnBfs.TabIndex = 54;
            this.btnBfs.Click += new System.EventHandler(this.btnBfs_Click);
            // 
            // btnDfs
            // 
            this.btnDfs.Font = new System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDfs.Location = new System.Drawing.Point(12, 116);
            this.btnDfs.Size = new System.Drawing.Size(300, 30);
            this.btnDfs.Text = "Coverage route (Depth-First Search)";
            this.btnDfs.UseVisualStyleBackColor = true;
            this.btnDfs.Name = "btnDfs";
            this.btnDfs.TabIndex = 55;
            this.btnDfs.Click += new System.EventHandler(this.btnDfs_Click);
            // 
            // btnMst
            // 
            this.btnMst.Font = new System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMst.Location = new System.Drawing.Point(12, 152);
            this.btnMst.Size = new System.Drawing.Size(300, 30);
            this.btnMst.Text = "Minimum spanning network (Kruskal)";
            this.btnMst.UseVisualStyleBackColor = true;
            this.btnMst.Name = "btnMst";
            this.btnMst.TabIndex = 56;
            this.btnMst.Click += new System.EventHandler(this.btnMst_Click);
            // 
            // btnClearGraph
            // 
            this.btnClearGraph.Font = new System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearGraph.Location = new System.Drawing.Point(12, 188);
            this.btnClearGraph.Size = new System.Drawing.Size(300, 26);
            this.btnClearGraph.Text = "Clear highlights";
            this.btnClearGraph.UseVisualStyleBackColor = true;
            this.btnClearGraph.Name = "btnClearGraph";
            this.btnClearGraph.TabIndex = 57;
            this.btnClearGraph.Click += new System.EventHandler(this.btnClearGraph_Click);
            // 
            // txtGraphOutput
            // 
            this.txtGraphOutput.BackColor = System.Drawing.Color.White;
            this.txtGraphOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGraphOutput.Font = new System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGraphOutput.Location = new System.Drawing.Point(12, 224);
            this.txtGraphOutput.Multiline = true;
            this.txtGraphOutput.ReadOnly = true;
            this.txtGraphOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGraphOutput.Size = new System.Drawing.Size(300, 270);
            this.txtGraphOutput.Name = "txtGraphOutput";
            this.txtGraphOutput.TabIndex = 58;
            // 
            // lblStructure
            // 
            this.lblStructure.AutoSize = true;
            this.lblStructure.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStructure.Location = new System.Drawing.Point(10, 12);
            this.lblStructure.Text = "Data structure:";
            this.lblStructure.ForeColor = System.Drawing.Color.FromArgb(30, 41, 54);
            this.lblStructure.Name = "lblStructure";
            this.lblStructure.TabIndex = 59;
            // 
            // cmbStructure
            // 
            this.cmbStructure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStructure.Font = new System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStructure.FormattingEnabled = true;
            this.cmbStructure.Location = new System.Drawing.Point(10, 32);
            this.cmbStructure.Size = new System.Drawing.Size(360, 23);
            this.cmbStructure.Name = "cmbStructure";
            this.cmbStructure.TabIndex = 60;
            // 
            // lblTraversal
            // 
            this.lblTraversal.AutoSize = true;
            this.lblTraversal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTraversal.Location = new System.Drawing.Point(390, 12);
            this.lblTraversal.Text = "Operation / traversal:";
            this.lblTraversal.ForeColor = System.Drawing.Color.FromArgb(30, 41, 54);
            this.lblTraversal.Name = "lblTraversal";
            this.lblTraversal.TabIndex = 61;
            // 
            // cmbTraversal
            // 
            this.cmbTraversal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTraversal.Font = new System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTraversal.FormattingEnabled = true;
            this.cmbTraversal.Location = new System.Drawing.Point(390, 32);
            this.cmbTraversal.Size = new System.Drawing.Size(300, 23);
            this.cmbTraversal.Name = "cmbTraversal";
            this.cmbTraversal.TabIndex = 62;
            // 
            // btnRunTraversal
            // 
            this.btnRunTraversal.Font = new System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRunTraversal.Location = new System.Drawing.Point(706, 30);
            this.btnRunTraversal.Size = new System.Drawing.Size(110, 27);
            this.btnRunTraversal.Text = "Run";
            this.btnRunTraversal.UseVisualStyleBackColor = true;
            this.btnRunTraversal.Name = "btnRunTraversal";
            this.btnRunTraversal.TabIndex = 63;
            this.btnRunTraversal.Click += new System.EventHandler(this.btnRunTraversal_Click);
            // 
            // lblTraversalCount
            // 
            this.lblTraversalCount.AutoSize = true;
            this.lblTraversalCount.Font = new System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTraversalCount.Location = new System.Drawing.Point(830, 36);
            this.lblTraversalCount.Text = "";
            this.lblTraversalCount.ForeColor = System.Drawing.Color.FromArgb(98, 112, 128);
            this.lblTraversalCount.Name = "lblTraversalCount";
            this.lblTraversalCount.TabIndex = 64;
            // 
            // lstTraversal
            // 
            this.lstTraversal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstTraversal.Font = new System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTraversal.FormattingEnabled = true;
            this.lstTraversal.HorizontalScrollbar = true;
            this.lstTraversal.IntegralHeight = false;
            this.lstTraversal.Location = new System.Drawing.Point(10, 68);
            this.lstTraversal.Size = new System.Drawing.Size(560, 446);
            this.lstTraversal.Name = "lstTraversal";
            this.lstTraversal.TabIndex = 65;
            // 
            // txtStructureInfo
            // 
            this.txtStructureInfo.BackColor = System.Drawing.Color.White;
            this.txtStructureInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStructureInfo.Font = new System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStructureInfo.Location = new System.Drawing.Point(586, 68);
            this.txtStructureInfo.Multiline = true;
            this.txtStructureInfo.ReadOnly = true;
            this.txtStructureInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStructureInfo.Size = new System.Drawing.Size(530, 446);
            this.txtStructureInfo.Name = "txtStructureInfo";
            this.txtStructureInfo.TabIndex = 66;
            // 
            // lblFooterInfo
            // 
            this.lblFooterInfo.AutoSize = true;
            this.lblFooterInfo.Font = new System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFooterInfo.Location = new System.Drawing.Point(12, 658);
            this.lblFooterInfo.Text = "";
            this.lblFooterInfo.ForeColor = System.Drawing.Color.FromArgb(98, 112, 128);
            this.lblFooterInfo.Name = "lblFooterInfo";
            this.lblFooterInfo.TabIndex = 67;
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(1008, 650);
            this.btnBack.Size = new System.Drawing.Size(140, 30);
            this.btnBack.Text = "Back to Main Menu";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Name = "btnBack";
            this.btnBack.TabIndex = 68;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // appHeader
            // 
            this.appHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.appHeader.Location = new System.Drawing.Point(0, 0);
            this.appHeader.Size = new System.Drawing.Size(1160, 72);
            this.appHeader.Subtitle = "Track the progress of your service requests";
            this.appHeader.Title = "Service Request Status";
            this.appHeader.Name = "appHeader";
            this.appHeader.TabIndex = 69;
            // 
            // ServiceRequestStatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(238, 243, 248);
            this.ClientSize = new System.Drawing.Size(1160, 690);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Service Request Status";
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.lblFooterInfo);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.appHeader);
            this.Name = "ServiceRequestStatusForm";
            this.grpGraph.ResumeLayout(false);
            this.pnlGraph.ResumeLayout(false);
            this.grpNext.ResumeLayout(false);
            this.pnlProgress.ResumeLayout(false);
            this.grpDetails.ResumeLayout(false);
            this.grpFilter.ResumeLayout(false);
            this.pnlCardDone.ResumeLayout(false);
            this.pnlCardInProgress.ResumeLayout(false);
            this.pnlCardOpen.ResumeLayout(false);
            this.pnlCardTotal.ResumeLayout(false);
            this.grpTrack.ResumeLayout(false);
            this.tabStructures.ResumeLayout(false);
            this.tabGraph.ResumeLayout(false);
            this.tabHeap.ResumeLayout(false);
            this.tabTrack.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHeap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabTrack;
        private System.Windows.Forms.TabPage tabHeap;
        private System.Windows.Forms.TabPage tabGraph;
        private System.Windows.Forms.TabPage tabStructures;
        private System.Windows.Forms.TreeView tvDepartments;
        private System.Windows.Forms.GroupBox grpTrack;
        private System.Windows.Forms.TextBox txtTrackId;
        private System.Windows.Forms.Button btnTrack;
        private System.Windows.Forms.Panel pnlCardTotal;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.Label lblTotalCaption;
        private System.Windows.Forms.Panel pnlCardOpen;
        private System.Windows.Forms.Label lblOpenValue;
        private System.Windows.Forms.Label lblOpenCaption;
        private System.Windows.Forms.Panel pnlCardInProgress;
        private System.Windows.Forms.Label lblInProgressValue;
        private System.Windows.Forms.Label lblInProgressCaption;
        private System.Windows.Forms.Panel pnlCardDone;
        private System.Windows.Forms.Label lblDoneValue;
        private System.Windows.Forms.Label lblDoneCaption;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.Label lblStatusFilter;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblPriorityFilter;
        private System.Windows.Forms.ComboBox cmbPriority;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnApplyFilters;
        private System.Windows.Forms.Button btnResetFilters;
        private System.Windows.Forms.Label lblResultCount;
        private System.Windows.Forms.Label lblTrackResult;
        private System.Windows.Forms.DataGridView dgvRequests;
        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.TextBox txtDetails;
        private System.Windows.Forms.Button btnAdvance;
        private System.Windows.Forms.Label lblNearby;
        private MunicipalServicesApp.UI.BufferedPanel pnlProgress;
        private System.Windows.Forms.ListBox lstHistory;
        private System.Windows.Forms.Label lblHeapIntro;
        private System.Windows.Forms.DataGridView dgvHeap;
        private System.Windows.Forms.Label lblHeapArrayCaption;
        private System.Windows.Forms.TextBox txtHeapArray;
        private System.Windows.Forms.GroupBox grpNext;
        private System.Windows.Forms.Label lblNextInfo;
        private System.Windows.Forms.Button btnProcessNext;
        private System.Windows.Forms.Label lblProcessResult;
        private System.Windows.Forms.Label lblHeapStats;
        private MunicipalServicesApp.UI.BufferedPanel pnlGraph;
        private System.Windows.Forms.GroupBox grpGraph;
        private System.Windows.Forms.Label lblStartArea;
        private System.Windows.Forms.ComboBox cmbStartArea;
        private System.Windows.Forms.Button btnBfs;
        private System.Windows.Forms.Button btnDfs;
        private System.Windows.Forms.Button btnMst;
        private System.Windows.Forms.Button btnClearGraph;
        private System.Windows.Forms.TextBox txtGraphOutput;
        private System.Windows.Forms.Label lblStructure;
        private System.Windows.Forms.ComboBox cmbStructure;
        private System.Windows.Forms.Label lblTraversal;
        private System.Windows.Forms.ComboBox cmbTraversal;
        private System.Windows.Forms.Button btnRunTraversal;
        private System.Windows.Forms.Label lblTraversalCount;
        private System.Windows.Forms.ListBox lstTraversal;
        private System.Windows.Forms.TextBox txtStructureInfo;
        private System.Windows.Forms.Label lblFooterInfo;
        private System.Windows.Forms.Button btnBack;
        private MunicipalServicesApp.UI.AppHeader appHeader;
    }
}
