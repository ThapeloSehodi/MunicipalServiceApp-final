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
    public partial class ManageIssuesForm : Form
    {
        private IssueService issueService;
        public ManageIssuesForm(IssueService service)
        {
            InitializeComponent();
            Theme.Apply(this);
            issueService = service;

            LoadIssues();

        }
        private void LoadIssues()
        {
            List<Issue> issues = issueService.GetAllIssues();

            dgvIssues.DataSource = null;
            dgvIssues.DataSource = issues;

            UpdateDashboard(issues);
        }
        private void UpdateDashboard(List<Issue> issues)
        {
            int total = issues.Count;

            int submitted = issues.Count(i =>
                i.Status == "Submitted");

            int high = issues.Count(i =>
                i.Priority == "High");

            int urgent = issues.Count(i =>
                i.Priority == "Urgent");

            int roads = issues.Count(i =>
                i.Category == "Roads");

            lblTotalI.Text =
                "Total Issues: " + total;

            lblSubmitted.Text =
                "Submitted: " + submitted;

            lblHigh.Text =
                "High Priority: " + high;

            lblUrgent.Text =
                "Urgent: " + urgent;

            lblRoads.Text =
                "Road Issues: " + roads;
        }
        private void ManageIssuesForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();

            List<Issue> results =
                issueService.SearchIssues(searchText);

            dgvIssues.DataSource = null;
            dgvIssues.DataSource = results;

            UpdateDashboard(results);
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();

            LoadIssues();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnViewIssues_Click(object sender, EventArgs e)
        {
            ManageIssuesForm manageForm =
       new ManageIssuesForm(issueService);

            manageForm.ShowDialog();
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvIssues.CurrentRow == null)
            {
                MessageBox.Show(
                    "Please select an issue first.",
                    "No Issue Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            Issue selectedIssue =
                dgvIssues.CurrentRow.DataBoundItem as Issue;

            if (selectedIssue == null)
            {
                MessageBox.Show(
                    "Unable to load the selected issue.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            IssueDetailsForm detailsForm =
                new IssueDetailsForm(selectedIssue);

            detailsForm.ShowDialog();
        }
    }
}
