namespace MunicipalServicesApp.Forms
{
    partial class ReportIssuesForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpReportDetails = new System.Windows.Forms.GroupBox();
            this.cmbPriority = new System.Windows.Forms.ComboBox();
            this.lblPriority = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.grpDescription = new System.Windows.Forms.GroupBox();
            this.lblCharacterCount = new System.Windows.Forms.Label();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.grpAttachment = new System.Windows.Forms.GroupBox();
            this.lblSelectedFile = new System.Windows.Forms.Label();
            this.btnAttach = new System.Windows.Forms.Button();
            this.grpProgress = new System.Windows.Forms.GroupBox();
            this.lblEncouragement = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.progressBarReport = new System.Windows.Forms.ProgressBar();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnViewIssues = new System.Windows.Forms.Button();
            this.appHeader = new MunicipalServicesApp.UI.AppHeader();
            this.grpReportDetails.SuspendLayout();
            this.grpDescription.SuspendLayout();
            this.grpAttachment.SuspendLayout();
            this.grpProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(209, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(243, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Report Municipal Issue";
            this.lblTitle.Visible = false;
            // 
            // grpReportDetails
            // 
            this.grpReportDetails.Controls.Add(this.cmbPriority);
            this.grpReportDetails.Controls.Add(this.lblPriority);
            this.grpReportDetails.Controls.Add(this.cmbCategory);
            this.grpReportDetails.Controls.Add(this.lblCategory);
            this.grpReportDetails.Controls.Add(this.txtLocation);
            this.grpReportDetails.Controls.Add(this.lblLocation);
            this.grpReportDetails.Location = new System.Drawing.Point(45, 89);
            this.grpReportDetails.Name = "grpReportDetails";
            this.grpReportDetails.Size = new System.Drawing.Size(691, 110);
            this.grpReportDetails.TabIndex = 1;
            this.grpReportDetails.TabStop = false;
            this.grpReportDetails.Text = "Report Details";
            // 
            // cmbPriority
            // 
            this.cmbPriority.FormattingEnabled = true;
            this.cmbPriority.Location = new System.Drawing.Point(86, 67);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(121, 21);
            this.cmbPriority.TabIndex = 5;
            this.cmbPriority.SelectedIndexChanged += new System.EventHandler(this.cmbPriority_SelectedIndexChanged);
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.Location = new System.Drawing.Point(19, 72);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(38, 13);
            this.lblPriority.TabIndex = 4;
            this.lblPriority.Text = "Priority";
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(86, 39);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(121, 21);
            this.cmbCategory.TabIndex = 3;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(19, 42);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(55, 13);
            this.lblCategory.TabIndex = 2;
            this.lblCategory.Text = "Category :";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(86, 13);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(321, 20);
            this.txtLocation.TabIndex = 1;
            this.txtLocation.TextChanged += new System.EventHandler(this.txtLocation_TextChanged);
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(19, 20);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(51, 13);
            this.lblLocation.TabIndex = 0;
            this.lblLocation.Text = "Location:";
            // 
            // grpDescription
            // 
            this.grpDescription.Controls.Add(this.lblCharacterCount);
            this.grpDescription.Controls.Add(this.rtbDescription);
            this.grpDescription.Location = new System.Drawing.Point(45, 205);
            this.grpDescription.Name = "grpDescription";
            this.grpDescription.Size = new System.Drawing.Size(691, 129);
            this.grpDescription.TabIndex = 2;
            this.grpDescription.TabStop = false;
            this.grpDescription.Text = "Issue Description";
            // 
            // lblCharacterCount
            // 
            this.lblCharacterCount.AutoSize = true;
            this.lblCharacterCount.Location = new System.Drawing.Point(6, 113);
            this.lblCharacterCount.Name = "lblCharacterCount";
            this.lblCharacterCount.Size = new System.Drawing.Size(99, 13);
            this.lblCharacterCount.TabIndex = 1;
            this.lblCharacterCount.Text = "Characters: 0 / 500";
            this.lblCharacterCount.Click += new System.EventHandler(this.lblCharacterCount_Click);
            // 
            // rtbDescription
            // 
            this.rtbDescription.Location = new System.Drawing.Point(7, 20);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(663, 90);
            this.rtbDescription.TabIndex = 0;
            this.rtbDescription.Text = "";
            this.rtbDescription.TextChanged += new System.EventHandler(this.rtbDescription_TextChanged);
            // 
            // grpAttachment
            // 
            this.grpAttachment.Controls.Add(this.lblSelectedFile);
            this.grpAttachment.Controls.Add(this.btnAttach);
            this.grpAttachment.Location = new System.Drawing.Point(45, 340);
            this.grpAttachment.Name = "grpAttachment";
            this.grpAttachment.Size = new System.Drawing.Size(691, 52);
            this.grpAttachment.TabIndex = 3;
            this.grpAttachment.TabStop = false;
            this.grpAttachment.Text = "Supporting Evidence";
            // 
            // lblSelectedFile
            // 
            this.lblSelectedFile.AutoSize = true;
            this.lblSelectedFile.Location = new System.Drawing.Point(247, 25);
            this.lblSelectedFile.Name = "lblSelectedFile";
            this.lblSelectedFile.Size = new System.Drawing.Size(80, 13);
            this.lblSelectedFile.TabIndex = 1;
            this.lblSelectedFile.Text = "No file selected";
            // 
            // btnAttach
            // 
            this.btnAttach.Location = new System.Drawing.Point(9, 20);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(198, 23);
            this.btnAttach.TabIndex = 0;
            this.btnAttach.Text = "Attach Image / Document";
            this.btnAttach.UseVisualStyleBackColor = true;
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // grpProgress
            // 
            this.grpProgress.Controls.Add(this.lblEncouragement);
            this.grpProgress.Controls.Add(this.lblProgress);
            this.grpProgress.Controls.Add(this.progressBarReport);
            this.grpProgress.Location = new System.Drawing.Point(45, 398);
            this.grpProgress.Name = "grpProgress";
            this.grpProgress.Size = new System.Drawing.Size(709, 125);
            this.grpProgress.TabIndex = 4;
            this.grpProgress.TabStop = false;
            this.grpProgress.Text = "Reporting Progress";
            // 
            // lblEncouragement
            // 
            this.lblEncouragement.AutoSize = true;
            this.lblEncouragement.Location = new System.Drawing.Point(25, 101);
            this.lblEncouragement.Name = "lblEncouragement";
            this.lblEncouragement.Size = new System.Drawing.Size(208, 13);
            this.lblEncouragement.TabIndex = 2;
            this.lblEncouragement.Text = "Let\'s get started! Please enter the location.";
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(22, 84);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(120, 13);
            this.lblProgress.TabIndex = 1;
            this.lblProgress.Text = " Reporting Progress: 0%";
            // 
            // progressBarReport
            // 
            this.progressBarReport.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.progressBarReport.Location = new System.Drawing.Point(7, 19);
            this.progressBarReport.Name = "progressBarReport";
            this.progressBarReport.Size = new System.Drawing.Size(483, 37);
            this.progressBarReport.TabIndex = 0;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(52, 530);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(181, 530);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear Form";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(473, 528);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(122, 23);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Back To Main Manu";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnViewIssues
            // 
            this.btnViewIssues.Location = new System.Drawing.Point(282, 528);
            this.btnViewIssues.Name = "btnViewIssues";
            this.btnViewIssues.Size = new System.Drawing.Size(117, 23);
            this.btnViewIssues.TabIndex = 8;
            this.btnViewIssues.Text = "View Submitted Issues";
            this.btnViewIssues.UseVisualStyleBackColor = true;
            this.btnViewIssues.Click += new System.EventHandler(this.btnViewIssues_Click);
            // 
            // appHeader
            // 
            this.appHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.appHeader.Location = new System.Drawing.Point(0, 0);
            this.appHeader.Name = "appHeader";
            this.appHeader.Size = new System.Drawing.Size(800, 72);
            this.appHeader.Subtitle = "Tell your municipality about a problem in your area";
            this.appHeader.TabIndex = 99;
            this.appHeader.Title = "Report an Issue";
            // 
            // ReportIssuesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(238, 243, 248);
            this.ClientSize = new System.Drawing.Size(800, 556);
            this.Controls.Add(this.btnViewIssues);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.grpProgress);
            this.Controls.Add(this.grpAttachment);
            this.Controls.Add(this.grpDescription);
            this.Controls.Add(this.grpReportDetails);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.appHeader);
            this.Name = "ReportIssuesForm";
            this.Text = "Report an Issue";
            this.grpReportDetails.ResumeLayout(false);
            this.grpReportDetails.PerformLayout();
            this.grpDescription.ResumeLayout(false);
            this.grpDescription.PerformLayout();
            this.grpAttachment.ResumeLayout(false);
            this.grpAttachment.PerformLayout();
            this.grpProgress.ResumeLayout(false);
            this.grpProgress.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpReportDetails;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.ComboBox cmbPriority;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.GroupBox grpDescription;
        private System.Windows.Forms.Label lblCharacterCount;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.GroupBox grpAttachment;
        private System.Windows.Forms.Button btnAttach;
        private System.Windows.Forms.Label lblSelectedFile;
        private System.Windows.Forms.GroupBox grpProgress;
        private System.Windows.Forms.ProgressBar progressBarReport;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label lblEncouragement;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnViewIssues;
        private MunicipalServicesApp.UI.AppHeader appHeader;
    }
}