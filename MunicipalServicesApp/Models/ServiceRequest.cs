using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServicesApp.Models
{
    public enum RequestStatus
    {
        Submitted = 0,
        UnderReview = 1,
        InProgress = 2,
        Completed = 3
    }

    // One line in the progress history of a request.
    public class StatusHistoryEntry
    {
        public DateTime Date { get; set; }

        public RequestStatus Status { get; set; }

        public string Note { get; set; }

        public override string ToString()
        {
            return Date.ToString("dd MMM yyyy HH:mm") + "   " +
                   ServiceRequest.StatusToText(Status) + "   -   " + Note;
        }
    }

    public class ServiceRequest
    {
        public string RequestId { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public string Department { get; set; }

        public string Location { get; set; }

        // The service area (a vertex in the service network graph).
        public string Area { get; set; }

        public string Description { get; set; }

        // The reference of the Part 1 issue this request came from (if any).
        public string SourceReference { get; set; }

        // 1 = Urgent, 2 = High, 3 = Medium, 4 = Low (lower = more important)
        public int Priority { get; set; }

        public RequestStatus Status { get; private set; }

        public DateTime DateSubmitted { get; set; }

        public DateTime LastUpdated { get; private set; }

        public List<StatusHistoryEntry> History { get; private set; }

        public ServiceRequest()
        {
            Priority = 3;
            Status = RequestStatus.Submitted;
            History = new List<StatusHistoryEntry>();
        }

        public bool IsOpen
        {
            get
            {
                return Status != RequestStatus.Completed;
            }
        }

        public string StatusText
        {
            get
            {
                return StatusToText(Status);
            }
        }

        public string PriorityLabel
        {
            get
            {
                return PriorityToText(Priority);
            }
        }

        public string SubmittedText
        {
            get
            {
                return DateSubmitted.ToString("dd MMM yyyy HH:mm");
            }
        }

        public string UpdatedText
        {
            get
            {
                return LastUpdated.ToString("dd MMM yyyy HH:mm");
            }
        }

        // Changes the status and records it in the history.
        public void SetStatus(RequestStatus status, DateTime when, string note)
        {
            Status = status;
            LastUpdated = when;

            History.Add(new StatusHistoryEntry
            {
                Date = when,
                Status = status,
                Note = note
            });
        }

        public static string StatusToText(RequestStatus status)
        {
            switch (status)
            {
                case RequestStatus.Submitted:
                    return "Submitted";
                case RequestStatus.UnderReview:
                    return "Under Review";
                case RequestStatus.InProgress:
                    return "In Progress";
                default:
                    return "Completed";
            }
        }

        public static string PriorityToText(int priority)
        {
            switch (priority)
            {
                case 1:
                    return "Urgent";
                case 2:
                    return "High";
                case 3:
                    return "Medium";
                default:
                    return "Low";
            }
        }
    }
}
