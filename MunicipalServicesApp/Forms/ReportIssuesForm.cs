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
    public partial class ReportIssuesForm : Form
    {
        private IssueService issueService;
        public ReportIssuesForm(IssueService service)
        {
            InitializeComponent();
            Theme.Apply(this);

            issueService = service;

            LoadCategories();
            LoadPriorities();
            UpdateProgress();
        }
        private void LoadCategories()
        {
            cmbCategory.Items.Clear();

            cmbCategory.Items.Add("Sanitation");
            cmbCategory.Items.Add("Roads");
            cmbCategory.Items.Add("Water");
            cmbCategory.Items.Add("Electricity");
            cmbCategory.Items.Add("Waste Management");
            cmbCategory.Items.Add("Street Lighting");
            cmbCategory.Items.Add("Sewage");
            cmbCategory.Items.Add("Other");

            cmbCategory.SelectedIndex = -1;
        }
        private void LoadPriorities()
        {
            cmbPriority.Items.Clear();

            cmbPriority.Items.Add("Low");
            cmbPriority.Items.Add("Medium");
            cmbPriority.Items.Add("High");
            cmbPriority.Items.Add("Urgent");

            cmbPriority.SelectedIndex = -1;
        }


        private void lblCharacterCount_Click(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Validate Location
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show(
                    "Please enter the location of the issue.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtLocation.Focus();
                return;
            }

            // Validate Category
            if (cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select an issue category.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbCategory.Focus();
                return;
            }

            // Validate Priority
            if (cmbPriority.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select the issue priority.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbPriority.Focus();
                return;
            }

            // Validate Description
            if (string.IsNullOrWhiteSpace(rtbDescription.Text))
            {
                MessageBox.Show(
                    "Please provide a description of the issue.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                rtbDescription.Focus();
                return;
            }

            // Create a new Issue object
            Issue newIssue = new Issue
            {
                ReferenceNumber = issueService.GenerateReferenceNumber(),
                Location = txtLocation.Text.Trim(),
                Category = cmbCategory.SelectedItem.ToString(),
                Priority = cmbPriority.SelectedItem.ToString(),
                Description = rtbDescription.Text.Trim(),
                AttachmentPath =
                    lblSelectedFile.Text == "No file selected"
                        ? ""
                        : lblSelectedFile.Text,
                Status = "Submitted",
                DateSubmitted = DateTime.Now
            };

            // Store the issue using the IssueService
            issueService.AddIssue(newIssue);

            // Tell the citizen the report was successful
            MessageBox.Show(
                "Your issue has been reported successfully!\n\n" +
                "Reference Number: " + newIssue.ReferenceNumber +
                "\n\nThank you for helping improve municipal services.",
                "Report Submitted",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // Clear the form
            ClearForm();
        }

        private void grpDescription_Enter(object sender, EventArgs e)
        {

        }

        private void rtbDescription_TextChanged(object sender, EventArgs e)
        {
            if (rtbDescription.Text.Length > 500)
            {
                rtbDescription.Text = rtbDescription.Text.Substring(0, 500);
                rtbDescription.SelectionStart = rtbDescription.Text.Length;
            }

            lblCharacterCount.Text =
                "Characters: " + rtbDescription.Text.Length + " / 500";

            UpdateProgress();
        }

        private void txtLocation_TextChanged(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void cmbPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateProgress();
        }
        private void UpdateProgress()
        {
            int progress = 0;

            if (!string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                progress += 25;
            }

            if (cmbCategory.SelectedIndex >= 0)
            {
                progress += 25;
            }

            if (!string.IsNullOrWhiteSpace(rtbDescription.Text))
            {
                progress += 25;
            }

            if (!string.IsNullOrWhiteSpace(lblSelectedFile.Text) &&
                lblSelectedFile.Text != "No file selected")
            {
                progress += 25;
            }

            progressBarReport.Value = progress;

            lblProgress.Text =
                "Reporting Progress: " + progress + "%";

            if (progress == 0)
            {
                lblEncouragement.Text =
                    "Let's get started! Please enter the location.";
            }
            else if (progress == 25)
            {
                lblEncouragement.Text =
                    "Great! Now select the issue category.";
            }
            else if (progress == 50)
            {
                lblEncouragement.Text =
                    "Good progress! Please describe the issue.";
            }
            else if (progress == 75)
            {
                lblEncouragement.Text =
                    "Almost there! Add supporting evidence if available.";
            }
            else
            {
                lblEncouragement.Text =
                    "Excellent! Your report is ready to submit.";
            }
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select an Image or Document";

                openFileDialog.Filter =
                    "Image Files|*.jpg;*.jpeg;*.png;*.gif|" +
                    "Documents|*.pdf;*.doc;*.docx|" +
                    "All Files|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    lblSelectedFile.Text = openFileDialog.FileName;

                    UpdateProgress();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        private void ClearForm()
        {
            txtLocation.Clear();

            cmbCategory.SelectedIndex = -1;

            cmbPriority.SelectedIndex = -1;

            rtbDescription.Clear();

            lblSelectedFile.Text = "No file selected";

            lblCharacterCount.Text = "Characters: 0 / 500";

            progressBarReport.Value = 0;

            lblProgress.Text = "Reporting Progress: 0%";

            lblEncouragement.Text =
                "Let's get started! Please enter the location.";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnViewIssues_Click(object sender, EventArgs e)
        {
            ManageIssuesForm manageForm =
      new ManageIssuesForm(issueService);

            manageForm.ShowDialog();
        }
    }
}
