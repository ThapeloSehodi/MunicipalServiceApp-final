namespace MunicipalServicesApp.Forms
{
    partial class LocalEventsForm
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
            this.lblHeading = new System.Windows.Forms.Label();
            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblResults = new System.Windows.Forms.Label();
            this.dgvEvents = new System.Windows.Forms.DataGridView();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.txtDetails = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.grpRecommended = new System.Windows.Forms.GroupBox();
            this.lstRecommendations = new System.Windows.Forms.ListBox();
            this.lblRecReason = new System.Windows.Forms.Label();
            this.grpUrgent = new System.Windows.Forms.GroupBox();
            this.lstUrgent = new System.Windows.Forms.ListBox();
            this.grpRecent = new System.Windows.Forms.GroupBox();
            this.lstRecentSearches = new System.Windows.Forms.ListBox();
            this.lblInterests = new System.Windows.Forms.Label();
            this.btnNextEvent = new System.Windows.Forms.Button();
            this.lblQueue = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.appHeader = new MunicipalServicesApp.UI.AppHeader();
            this.grpSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).BeginInit();
            this.grpDetails.SuspendLayout();
            this.grpRecommended.SuspendLayout();
            this.grpUrgent.SuspendLayout();
            this.grpRecent.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.Location = new System.Drawing.Point(24, 14);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(335, 26);
            this.lblHeading.TabIndex = 0;
            this.lblHeading.Text = "LOCAL EVENTS && ANNOUNCEMENTS";
            this.lblHeading.Visible = false;
            // 
            // grpSearch
            // 
            this.grpSearch.Controls.Add(this.lblSearch);
            this.grpSearch.Controls.Add(this.txtSearch);
            this.grpSearch.Controls.Add(this.lblCategory);
            this.grpSearch.Controls.Add(this.cmbCategory);
            this.grpSearch.Controls.Add(this.lblFromDate);
            this.grpSearch.Controls.Add(this.dtpFromDate);
            this.grpSearch.Controls.Add(this.lblToDate);
            this.grpSearch.Controls.Add(this.dtpToDate);
            this.grpSearch.Controls.Add(this.btnSearch);
            this.grpSearch.Controls.Add(this.btnClear);
            this.grpSearch.Location = new System.Drawing.Point(24, 82);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(1052, 84);
            this.grpSearch.TabIndex = 1;
            this.grpSearch.TabStop = false;
            this.grpSearch.Text = "Search Events";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(12, 24);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(80, 13);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search Events:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(15, 42);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(230, 20);
            this.txtSearch.TabIndex = 1;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(262, 24);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(52, 13);
            this.lblCategory.TabIndex = 2;
            this.lblCategory.Text = "Category:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(265, 42);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(170, 21);
            this.cmbCategory.TabIndex = 3;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(452, 24);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(59, 13);
            this.lblFromDate.TabIndex = 4;
            this.lblFromDate.Text = "From Date:";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Checked = false;
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(455, 42);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.ShowCheckBox = true;
            this.dtpFromDate.Size = new System.Drawing.Size(150, 20);
            this.dtpFromDate.TabIndex = 5;
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(622, 24);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(49, 13);
            this.lblToDate.TabIndex = 6;
            this.lblToDate.Text = "To Date:";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Checked = false;
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(625, 42);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.ShowCheckBox = true;
            this.dtpToDate.Size = new System.Drawing.Size(150, 20);
            this.dtpToDate.TabIndex = 7;
            // 
            // btnSearch
            // 
            this.btnSearch.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnSearch.Location = new System.Drawing.Point(800, 40);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 25);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClear
            // 
            this.btnClear.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnClear.Location = new System.Drawing.Point(915, 40);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 25);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResults.Location = new System.Drawing.Point(24, 176);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(279, 16);
            this.lblResults.TabIndex = 2;
            this.lblResults.Text = "Upcoming Events (shaded = announcement)";
            // 
            // dgvEvents
            // 
            this.dgvEvents.AllowUserToAddRows = false;
            this.dgvEvents.AllowUserToDeleteRows = false;
            this.dgvEvents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEvents.BackgroundColor = System.Drawing.Color.White;
            this.dgvEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEvents.Location = new System.Drawing.Point(24, 196);
            this.dgvEvents.MultiSelect = false;
            this.dgvEvents.Name = "dgvEvents";
            this.dgvEvents.ReadOnly = true;
            this.dgvEvents.RowHeadersVisible = false;
            this.dgvEvents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEvents.Size = new System.Drawing.Size(640, 240);
            this.dgvEvents.TabIndex = 3;
            this.dgvEvents.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEvents_CellClick);
            this.dgvEvents.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvEvents_DataBindingComplete);
            this.dgvEvents.SelectionChanged += new System.EventHandler(this.dgvEvents_SelectionChanged);
            // 
            // grpDetails
            // 
            this.grpDetails.Controls.Add(this.txtDetails);
            this.grpDetails.Location = new System.Drawing.Point(24, 444);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Size = new System.Drawing.Size(640, 150);
            this.grpDetails.TabIndex = 4;
            this.grpDetails.TabStop = false;
            this.grpDetails.Text = "Event Details";
            // 
            // txtDetails
            // 
            this.txtDetails.BackColor = System.Drawing.Color.White;
            this.txtDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetails.Location = new System.Drawing.Point(3, 16);
            this.txtDetails.Multiline = true;
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.ReadOnly = true;
            this.txtDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetails.Size = new System.Drawing.Size(634, 131);
            this.txtDetails.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(24, 604);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(66, 13);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Showing: 0";
            // 
            // grpRecommended
            // 
            this.grpRecommended.Controls.Add(this.lstRecommendations);
            this.grpRecommended.Controls.Add(this.lblRecReason);
            this.grpRecommended.Location = new System.Drawing.Point(684, 176);
            this.grpRecommended.Name = "grpRecommended";
            this.grpRecommended.Size = new System.Drawing.Size(392, 170);
            this.grpRecommended.TabIndex = 6;
            this.grpRecommended.TabStop = false;
            this.grpRecommended.Text = "Recommended For You";
            // 
            // lstRecommendations
            // 
            this.lstRecommendations.FormattingEnabled = true;
            this.lstRecommendations.Location = new System.Drawing.Point(10, 22);
            this.lstRecommendations.Name = "lstRecommendations";
            this.lstRecommendations.Size = new System.Drawing.Size(372, 88);
            this.lstRecommendations.TabIndex = 0;
            this.lstRecommendations.SelectedIndexChanged += new System.EventHandler(this.lstRecommendations_SelectedIndexChanged);
            // 
            // lblRecReason
            // 
            this.lblRecReason.Location = new System.Drawing.Point(10, 116);
            this.lblRecReason.Name = "lblRecReason";
            this.lblRecReason.Size = new System.Drawing.Size(372, 44);
            this.lblRecReason.TabIndex = 1;
            this.lblRecReason.Text = "Select a recommendation to see why it was suggested.";
            // 
            // grpUrgent
            // 
            this.grpUrgent.Controls.Add(this.lstUrgent);
            this.grpUrgent.Location = new System.Drawing.Point(684, 352);
            this.grpUrgent.Name = "grpUrgent";
            this.grpUrgent.Size = new System.Drawing.Size(392, 110);
            this.grpUrgent.TabIndex = 7;
            this.grpUrgent.TabStop = false;
            this.grpUrgent.Text = "Priority Announcements (most urgent first)";
            // 
            // lstUrgent
            // 
            this.lstUrgent.FormattingEnabled = true;
            this.lstUrgent.Location = new System.Drawing.Point(10, 20);
            this.lstUrgent.Name = "lstUrgent";
            this.lstUrgent.Size = new System.Drawing.Size(372, 80);
            this.lstUrgent.TabIndex = 0;
            // 
            // grpRecent
            // 
            this.grpRecent.Controls.Add(this.lstRecentSearches);
            this.grpRecent.Location = new System.Drawing.Point(684, 468);
            this.grpRecent.Name = "grpRecent";
            this.grpRecent.Size = new System.Drawing.Size(392, 84);
            this.grpRecent.TabIndex = 8;
            this.grpRecent.TabStop = false;
            this.grpRecent.Text = "Recent Searches (double-click to repeat)";
            // 
            // lstRecentSearches
            // 
            this.lstRecentSearches.FormattingEnabled = true;
            this.lstRecentSearches.Location = new System.Drawing.Point(10, 20);
            this.lstRecentSearches.Name = "lstRecentSearches";
            this.lstRecentSearches.Size = new System.Drawing.Size(372, 60);
            this.lstRecentSearches.TabIndex = 0;
            this.lstRecentSearches.DoubleClick += new System.EventHandler(this.lstRecentSearches_DoubleClick);
            // 
            // lblInterests
            // 
            this.lblInterests.Location = new System.Drawing.Point(684, 558);
            this.lblInterests.Name = "lblInterests";
            this.lblInterests.Size = new System.Drawing.Size(392, 30);
            this.lblInterests.TabIndex = 9;
            this.lblInterests.Text = "Your interests: none yet";
            // 
            // btnNextEvent
            // 
            this.btnNextEvent.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnNextEvent.Location = new System.Drawing.Point(684, 600);
            this.btnNextEvent.Name = "btnNextEvent";
            this.btnNextEvent.Size = new System.Drawing.Size(130, 27);
            this.btnNextEvent.TabIndex = 10;
            this.btnNextEvent.Text = "Next Upcoming Event";
            this.btnNextEvent.UseVisualStyleBackColor = true;
            this.btnNextEvent.Click += new System.EventHandler(this.btnNextEvent_Click);
            // 
            // lblQueue
            // 
            this.lblQueue.AutoSize = true;
            this.lblQueue.Location = new System.Drawing.Point(824, 607);
            this.lblQueue.Name = "lblQueue";
            this.lblQueue.Size = new System.Drawing.Size(88, 13);
            this.lblQueue.TabIndex = 11;
            this.lblQueue.Text = "Events in queue: 0";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(966, 600);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(110, 27);
            this.btnBack.TabIndex = 12;
            this.btnBack.Text = "Back to Main Menu";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // appHeader
            // 
            this.appHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.appHeader.Location = new System.Drawing.Point(0, 0);
            this.appHeader.Name = "appHeader";
            this.appHeader.Size = new System.Drawing.Size(1100, 72);
            this.appHeader.Subtitle = "Discover what is happening in your community";
            this.appHeader.TabIndex = 99;
            this.appHeader.Title = "Local Events & Announcements";
            // 
            // LocalEventsForm
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(238, 243, 248);
            this.ClientSize = new System.Drawing.Size(1100, 640);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblQueue);
            this.Controls.Add(this.btnNextEvent);
            this.Controls.Add(this.lblInterests);
            this.Controls.Add(this.grpRecent);
            this.Controls.Add(this.grpUrgent);
            this.Controls.Add(this.grpRecommended);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.grpDetails);
            this.Controls.Add(this.dgvEvents);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.grpSearch);
            this.Controls.Add(this.lblHeading);
            this.Controls.Add(this.appHeader);
            this.MaximizeBox = false;
            this.Name = "LocalEventsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Local Events and Announcements";
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).EndInit();
            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            this.grpRecommended.ResumeLayout(false);
            this.grpUrgent.ResumeLayout(false);
            this.grpRecent.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.DataGridView dgvEvents;
        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.TextBox txtDetails;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox grpRecommended;
        private System.Windows.Forms.ListBox lstRecommendations;
        private System.Windows.Forms.Label lblRecReason;
        private System.Windows.Forms.GroupBox grpUrgent;
        private System.Windows.Forms.ListBox lstUrgent;
        private System.Windows.Forms.GroupBox grpRecent;
        private System.Windows.Forms.ListBox lstRecentSearches;
        private System.Windows.Forms.Label lblInterests;
        private System.Windows.Forms.Button btnNextEvent;
        private System.Windows.Forms.Label lblQueue;
        private System.Windows.Forms.Button btnBack;
        private MunicipalServicesApp.UI.AppHeader appHeader;
    }
}
