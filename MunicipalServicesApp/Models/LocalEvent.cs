using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServicesApp.Models
{
    public class LocalEvent
    {
        public int EventId { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public string Location { get; set; }

        public DateTime EventDate { get; set; }

        public string Description { get; set; }

        public bool IsAnnouncement { get; set; }

        // 1 = High, 2 = Medium, 3 = Low (lower number = more important).
        // Used by the priority queue.
        public int Priority { get; set; }

        public LocalEvent()
        {
            Priority = 2;
        }

        public string DisplayType
        {
            get
            {
                return IsAnnouncement ? "Announcement" : "Event";
            }
        }

        public string PriorityLabel
        {
            get
            {
                switch (Priority)
                {
                    case 1:
                        return "High";
                    case 2:
                        return "Medium";
                    default:
                        return "Low";
                }
            }
        }

        public string DisplayDate
        {
            get
            {
                return EventDate.ToString("ddd, dd MMM yyyy  HH:mm");
            }
        }
    }
}
