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
using System.IO;
using MunicipalServicesApp.Models;

namespace MunicipalServicesApp.Forms
{
    public partial class IssueDetailsForm : Form
    {
        private Issue issue;
        public IssueDetailsForm(Issue selectedIssue)
        {
            InitializeComponent();
            Theme.Apply(this);

            issue = selectedIssue;

            DisplayIssueDetails();
        }
        private void DisplayIssueDetails()
        {
            lblReference.Text = issue.ReferenceNumber;
            lblLocation.Text = issue.Location;
            lblCategory.Text = issue.Category;
            lblPriority.Text = issue.Priority;
            lblStatus.Text = issue.Status;
            lblDate.Text = issue.DateSubmitted.ToString("dd/MM/yyyy HH:mm");

            if (string.IsNullOrWhiteSpace(issue.AttachmentPath))
            {
                lblAttachment.Text = "No attachment";
            }
            else
            {
                lblAttachment.Text = Path.GetFileName(issue.AttachmentPath);
            }

            rtbDescription.Text = issue.Description;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
