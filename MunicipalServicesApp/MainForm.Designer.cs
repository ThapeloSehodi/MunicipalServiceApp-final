namespace MunicipalServicesApp
{
    partial class MainForm
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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblWelcomeSub = new System.Windows.Forms.Label();
            this.btnReportIssues = new MunicipalServicesApp.UI.TileButton();
            this.btnEvents = new MunicipalServicesApp.UI.TileButton();
            this.btnServiceStatus = new MunicipalServicesApp.UI.TileButton();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.lblSummary = new System.Windows.Forms.Label();
            this.pnlTip = new System.Windows.Forms.Panel();
            this.lblTip = new System.Windows.Forms.Label();
            this.lblFooter = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.appHeader = new MunicipalServicesApp.UI.AppHeader();
            this.pnlSummary.SuspendLayout();
            this.pnlTip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(30, 41, 54);
            this.lblWelcome.Location = new System.Drawing.Point(24, 90);
            this.lblWelcome.Text = "Welcome to the Citizen Service Portal";
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.TabIndex = 0;
            // 
            // lblWelcomeSub
            // 
            this.lblWelcomeSub.AutoSize = true;
            this.lblWelcomeSub.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcomeSub.ForeColor = System.Drawing.Color.FromArgb(98, 112, 128);
            this.lblWelcomeSub.Location = new System.Drawing.Point(27, 126);
            this.lblWelcomeSub.Text = "Choose a service below to get started.";
            this.lblWelcomeSub.Name = "lblWelcomeSub";
            this.lblWelcomeSub.TabIndex = 1;
            // 
            // btnReportIssues
            // 
            this.btnReportIssues.AccentColor = System.Drawing.Color.FromArgb(200, 62, 52);
            this.btnReportIssues.Description = "Report potholes, leaks, outages and other municipal problems.";
            this.btnReportIssues.IconText = "!";
            this.btnReportIssues.Location = new System.Drawing.Point(25, 168);
            this.btnReportIssues.Size = new System.Drawing.Size(270, 180);
            this.btnReportIssues.Text = "Report an Issue";
            this.btnReportIssues.Title = "Report an Issue";
            this.btnReportIssues.UseVisualStyleBackColor = true;
            this.btnReportIssues.Name = "btnReportIssues";
            this.btnReportIssues.TabIndex = 2;
            this.btnReportIssues.Click += new System.EventHandler(this.btnReportIssues_Click);
            // 
            // btnEvents
            // 
            this.btnEvents.AccentColor = System.Drawing.Color.FromArgb(12, 74, 110);
            this.btnEvents.Description = "Browse, search and get recommendations for local events.";
            this.btnEvents.IconText = "★";
            this.btnEvents.Location = new System.Drawing.Point(307, 168);
            this.btnEvents.Size = new System.Drawing.Size(270, 180);
            this.btnEvents.Text = "Events & Announcements";
            this.btnEvents.Title = "Events & Announcements";
            this.btnEvents.UseVisualStyleBackColor = true;
            this.btnEvents.Name = "btnEvents";
            this.btnEvents.TabIndex = 3;
            this.btnEvents.Click += new System.EventHandler(this.btnEvents_Click);
            // 
            // btnServiceStatus
            // 
            this.btnServiceStatus.AccentColor = System.Drawing.Color.FromArgb(0, 122, 77);
            this.btnServiceStatus.Description = "Track your service requests and see live progress updates.";
            this.btnServiceStatus.IconText = "≡";
            this.btnServiceStatus.Location = new System.Drawing.Point(589, 168);
            this.btnServiceStatus.Size = new System.Drawing.Size(270, 180);
            this.btnServiceStatus.Text = "Service Request Status";
            this.btnServiceStatus.Title = "Service Request Status";
            this.btnServiceStatus.UseVisualStyleBackColor = true;
            this.btnServiceStatus.Name = "btnServiceStatus";
            this.btnServiceStatus.TabIndex = 4;
            this.btnServiceStatus.Click += new System.EventHandler(this.btnServiceStatus_Click);
            // 
            // pnlSummary
            // 
            this.pnlSummary.Controls.Add(this.lblSummary);
            this.pnlSummary.BackColor = System.Drawing.Color.White;
            this.pnlSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSummary.Location = new System.Drawing.Point(25, 370);
            this.pnlSummary.Size = new System.Drawing.Size(834, 52);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.TabIndex = 5;
            // 
            // lblSummary
            // 
            this.lblSummary.AutoSize = true;
            this.lblSummary.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSummary.ForeColor = System.Drawing.Color.FromArgb(12, 74, 110);
            this.lblSummary.Location = new System.Drawing.Point(16, 16);
            this.lblSummary.Text = "Loading summary...";
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.TabIndex = 6;
            // 
            // pnlTip
            // 
            this.pnlTip.Controls.Add(this.lblTip);
            this.pnlTip.BackColor = System.Drawing.Color.FromArgb(255, 248, 225);
            this.pnlTip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTip.Location = new System.Drawing.Point(25, 436);
            this.pnlTip.Size = new System.Drawing.Size(834, 52);
            this.pnlTip.Name = "pnlTip";
            this.pnlTip.TabIndex = 7;
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTip.ForeColor = System.Drawing.Color.FromArgb(90, 70, 0);
            this.lblTip.Location = new System.Drawing.Point(16, 16);
            this.lblTip.Text = "Tip: every issue you report is added to Service Request Status, so you can follow its progress.";
            this.lblTip.Name = "lblTip";
            this.lblTip.TabIndex = 8;
            // 
            // lblFooter
            // 
            this.lblFooter.AutoSize = true;
            this.lblFooter.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFooter.ForeColor = System.Drawing.Color.FromArgb(98, 112, 128);
            this.lblFooter.Location = new System.Drawing.Point(25, 520);
            this.lblFooter.Text = "Municipal Services Application | South Africa";
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.TabIndex = 9;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(759, 510);
            this.btnExit.Size = new System.Drawing.Size(100, 32);
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Name = "btnExit";
            this.btnExit.TabIndex = 10;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // appHeader
            // 
            this.appHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.appHeader.Location = new System.Drawing.Point(0, 0);
            this.appHeader.Size = new System.Drawing.Size(884, 72);
            this.appHeader.Subtitle = "Your gateway to municipal services in South Africa";
            this.appHeader.Title = "Municipal Services";
            this.appHeader.Name = "appHeader";
            this.appHeader.TabIndex = 11;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(238, 243, 248);
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Municipal Services Application";
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.lblWelcomeSub);
            this.Controls.Add(this.btnReportIssues);
            this.Controls.Add(this.btnEvents);
            this.Controls.Add(this.btnServiceStatus);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.pnlTip);
            this.Controls.Add(this.lblFooter);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.appHeader);
            this.Name = "MainForm";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.pnlTip.ResumeLayout(false);
            this.pnlSummary.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblWelcomeSub;
        private MunicipalServicesApp.UI.TileButton btnReportIssues;
        private MunicipalServicesApp.UI.TileButton btnEvents;
        private MunicipalServicesApp.UI.TileButton btnServiceStatus;
        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.Panel pnlTip;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.Label lblFooter;
        private System.Windows.Forms.Button btnExit;
        private MunicipalServicesApp.UI.AppHeader appHeader;
    }
}
