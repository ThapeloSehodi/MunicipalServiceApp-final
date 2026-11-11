using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MunicipalServicesApp.Forms;
using MunicipalServicesApp.Services;
using MunicipalServicesApp.UI;

namespace MunicipalServicesApp
{
    public partial class MainForm : Form
    {
        private IssueService issueService;
        private EventService eventService;
        private ServiceRequestService serviceRequestService;

        public MainForm()
        {
            InitializeComponent();

            issueService = new IssueService();
            eventService = new EventService();
            serviceRequestService = new ServiceRequestService();

            Theme.Apply(this);
            UpdateSummary();
        }

        // Keeps the summary line on the main menu up to date.
        private void UpdateSummary()
        {
            serviceRequestService.SyncFromIssues(issueService);

            lblSummary.Text =
                "Issues reported: " + issueService.GetIssueCount() +
                "      |      Upcoming events: " + eventService.GetUpcomingEvents().Count +
                "      |      Open service requests: " + serviceRequestService.OpenCount;
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            UpdateSummary();
        }

        private void btnReportIssues_Click(object sender, EventArgs e)
        {
            ReportIssuesForm reportIssuesForm =
                new ReportIssuesForm(issueService);

            reportIssuesForm.ShowDialog();
        }

        private void btnEvents_Click(object sender, EventArgs e)
        {
            LocalEventsForm eventsForm =
                new LocalEventsForm(eventService);

            eventsForm.ShowDialog();
        }

        private void btnServiceStatus_Click(object sender, EventArgs e)
        {
            ServiceRequestStatusForm statusForm =
                new ServiceRequestStatusForm(serviceRequestService, issueService);

            statusForm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
