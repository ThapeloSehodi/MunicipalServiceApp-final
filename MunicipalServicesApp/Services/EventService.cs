using MunicipalServicesApp.Generic;
using MunicipalServicesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServicesApp.Services
{
    public class EventService
    {
        // Stores all events
        private readonly List<LocalEvent> events;

        // Organises events by date (always kept in date order)
        private readonly SortedDictionary<DateTime, List<LocalEvent>>
            eventsByDate;

        // Stores events by their unique ID (fast lookup)
        private readonly Dictionary<int, LocalEvent> eventsById;

        // Groups events by category (fast category lookup)
        private readonly Dictionary<string, List<LocalEvent>>
            eventsByCategory;

        // SET: unique event categories
        private readonly HashSet<string> categories;

        // SET: unique event dates, automatically kept in order
        private readonly SortedSet<DateTime> uniqueDates;

        // SET: IDs of events the user has clicked on
        private readonly HashSet<int> viewedEventIds;

        // STACK: recent searches (last search is on top)
        private readonly Stack<string> searchHistory;

        // QUEUE: upcoming events waiting to be shown one by one
        private readonly Queue<LocalEvent> eventQueue;

        // Records how often categories are searched
        private readonly Dictionary<string, int> categorySearchCounts;

        // Records how often categories are viewed (clicked)
        private readonly Dictionary<string, int> categoryViewCounts;

        // Records how often keywords are searched
        private readonly Dictionary<string, int> keywordSearchCounts;

        private static readonly HashSet<string> StopWords =
            new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "the", "and", "for", "with", "from", "near",
                "about", "are", "any", "all", "our", "your"
            };

        public EventService()
        {
            events = new List<LocalEvent>();

            eventsByDate =
                new SortedDictionary<DateTime, List<LocalEvent>>();

            eventsById = new Dictionary<int, LocalEvent>();

            eventsByCategory =
                new Dictionary<string, List<LocalEvent>>(
                    StringComparer.OrdinalIgnoreCase);

            categories =
                new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            uniqueDates = new SortedSet<DateTime>();

            viewedEventIds = new HashSet<int>();

            searchHistory = new Stack<string>();

            eventQueue = new Queue<LocalEvent>();

            categorySearchCounts =
                new Dictionary<string, int>(
                    StringComparer.OrdinalIgnoreCase);

            categoryViewCounts =
                new Dictionary<string, int>(
                    StringComparer.OrdinalIgnoreCase);

            keywordSearchCounts =
                new Dictionary<string, int>(
                    StringComparer.OrdinalIgnoreCase);

            LoadSampleEvents();
        }

        // ------------------------------------------------------------
        // Sample data (dates are relative to today so the events are
        // always "upcoming" whenever the application is run)
        // ------------------------------------------------------------
        private void LoadSampleEvents()
        {
            DateTime today = DateTime.Today;

            AddEvent(new LocalEvent
            {
                EventId = 1,
                Title = "Community Clean-Up Campaign",
                Category = "Environment",
                Location = "Pretoria West Community Hall",
                EventDate = today.AddDays(5).AddHours(9),
                Description =
                    "Residents are invited to help clean public spaces.",
                IsAnnouncement = false,
                Priority = 3
            });

            AddEvent(new LocalEvent
            {
                EventId = 2,
                Title = "Municipal Public Meeting",
                Category = "Community",
                Location = "Pretoria Civic Centre",
                EventDate = today.AddDays(8).AddHours(10),
                Description =
                    "Residents can discuss local service delivery matters.",
                IsAnnouncement = false,
                Priority = 2
            });

            AddEvent(new LocalEvent
            {
                EventId = 3,
                Title = "Road Maintenance Notice",
                Category = "Roads",
                Location = "Church Street, Pretoria",
                EventDate = today.AddDays(10).AddHours(8),
                Description =
                    "Road maintenance is scheduled. Please plan your route.",
                IsAnnouncement = true,
                Priority = 2
            });

            AddEvent(new LocalEvent
            {
                EventId = 4,
                Title = "Community Recycling Drive",
                Category = "Environment",
                Location = "Pretoria West Recreation Centre",
                EventDate = today.AddDays(14).AddHours(8.5),
                Description =
                    "Bring recyclable materials to the community collection point.",
                IsAnnouncement = false,
                Priority = 3
            });

            AddEvent(new LocalEvent
            {
                EventId = 5,
                Title = "Water Supply Interruption Notice",
                Category = "Utilities",
                Location = "Selected Pretoria West Areas",
                EventDate = today.AddDays(18).AddHours(7),
                Description =
                    "Residents should prepare for a planned water interruption.",
                IsAnnouncement = true,
                Priority = 1
            });

            AddEvent(new LocalEvent
            {
                EventId = 6,
                Title = "Youth Soccer Tournament",
                Category = "Sports",
                Location = "Mamelodi Stadium",
                EventDate = today.AddDays(7).AddHours(9.5),
                Description =
                    "Local youth teams compete in a community soccer day.",
                IsAnnouncement = false,
                Priority = 3
            });

            AddEvent(new LocalEvent
            {
                EventId = 7,
                Title = "Free Health Screening Day",
                Category = "Health",
                Location = "Sunnyside Community Clinic",
                EventDate = today.AddDays(9).AddHours(8),
                Description =
                    "Free blood pressure, glucose and general health checks.",
                IsAnnouncement = false,
                Priority = 2
            });

            AddEvent(new LocalEvent
            {
                EventId = 8,
                Title = "Pretoria Arts and Culture Festival",
                Category = "Culture",
                Location = "Church Square, Pretoria",
                EventDate = today.AddDays(12).AddHours(11),
                Description =
                    "Live music, local crafts and food stalls in the city centre.",
                IsAnnouncement = false,
                Priority = 2
            });

            AddEvent(new LocalEvent
            {
                EventId = 9,
                Title = "Electricity Load Reduction Notice",
                Category = "Utilities",
                Location = "Hatfield and Brooklyn",
                EventDate = today.AddDays(3).AddHours(6),
                Description =
                    "Scheduled power reduction for network maintenance.",
                IsAnnouncement = true,
                Priority = 1
            });

            AddEvent(new LocalEvent
            {
                EventId = 10,
                Title = "Neighbourhood Watch Safety Workshop",
                Category = "Safety",
                Location = "Centurion Community Hall",
                EventDate = today.AddDays(16).AddHours(17.5),
                Description =
                    "Learn how to organise and run a safe neighbourhood watch.",
                IsAnnouncement = false,
                Priority = 2
            });

            AddEvent(new LocalEvent
            {
                EventId = 11,
                Title = "Children's Library Reading Programme",
                Category = "Community",
                Location = "Pretoria Central Library",
                EventDate = today.AddDays(21).AddHours(10),
                Description =
                    "Story time and reading activities for primary school children.",
                IsAnnouncement = false,
                Priority = 3
            });

            AddEvent(new LocalEvent
            {
                EventId = 12,
                Title = "Pothole Repair Programme",
                Category = "Roads",
                Location = "Lynnwood Road, Pretoria",
                EventDate = today.AddDays(4).AddHours(7.5),
                Description =
                    "Repair crews will be working. Expect delays and lane closures.",
                IsAnnouncement = true,
                Priority = 2
            });

            AddEvent(new LocalEvent
            {
                EventId = 13,
                Title = "Refuse Collection Schedule Change",
                Category = "Environment",
                Location = "Soshanguve",
                EventDate = today.AddDays(6).AddHours(6),
                Description =
                    "Waste collection moves to Wednesdays. Put bins out early.",
                IsAnnouncement = true,
                Priority = 1
            });

            AddEvent(new LocalEvent
            {
                EventId = 14,
                Title = "Community Fun Run",
                Category = "Sports",
                Location = "Pretoria National Botanical Garden",
                EventDate = today.AddDays(20).AddHours(6.5),
                Description =
                    "A 5km family-friendly fun run open to all residents.",
                IsAnnouncement = false,
                Priority = 3
            });

            AddEvent(new LocalEvent
            {
                EventId = 15,
                Title = "Community Vaccination Drive",
                Category = "Health",
                Location = "Mamelodi Community Health Centre",
                EventDate = today.AddDays(26).AddHours(8),
                Description =
                    "Free vaccinations for children and adults.",
                IsAnnouncement = false,
                Priority = 2
            });
        }

        // ------------------------------------------------------------
        // Adding and retrieving events
        // ------------------------------------------------------------
        public void AddEvent(LocalEvent localEvent)
        {
            if (localEvent == null)
            {
                throw new ArgumentNullException("localEvent");
            }

            if (eventsById.ContainsKey(localEvent.EventId))
            {
                throw new ArgumentException(
                    "An event with this ID already exists.");
            }

            events.Add(localEvent);
            eventsById.Add(localEvent.EventId, localEvent);

            // Sets
            categories.Add(localEvent.Category);
            uniqueDates.Add(localEvent.EventDate.Date);

            // Dictionary grouped by category
            if (!eventsByCategory.ContainsKey(localEvent.Category))
            {
                eventsByCategory.Add(
                    localEvent.Category,
                    new List<LocalEvent>());
            }

            eventsByCategory[localEvent.Category].Add(localEvent);

            // Sorted dictionary grouped by date
            if (!eventsByDate.ContainsKey(localEvent.EventDate))
            {
                eventsByDate.Add(
                    localEvent.EventDate,
                    new List<LocalEvent>());
            }

            eventsByDate[localEvent.EventDate].Add(localEvent);
        }

        public List<LocalEvent> GetAllEvents()
        {
            return eventsByDate
                .SelectMany(item => item.Value)
                .ToList();
        }

        public List<LocalEvent> GetUpcomingEvents()
        {
            return GetAllEvents()
                .Where(e => e.EventDate >= DateTime.Now)
                .ToList();
        }

        public List<string> GetCategories()
        {
            return categories
                .OrderBy(c => c)
                .ToList();
        }

        // Unique event dates (from the SortedSet), in date order.
        public List<DateTime> GetUniqueDates()
        {
            return uniqueDates.ToList();
        }

        // Counts the unique dates in a list of events using a set.
        public int CountUniqueDates(IEnumerable<LocalEvent> eventList)
        {
            HashSet<DateTime> dates = new HashSet<DateTime>();

            foreach (LocalEvent localEvent in eventList)
            {
                dates.Add(localEvent.EventDate.Date);
            }

            return dates.Count;
        }

        public LocalEvent GetEventById(int eventId)
        {
            LocalEvent localEvent;

            if (eventsById.TryGetValue(eventId, out localEvent))
            {
                return localEvent;
            }

            return null;
        }

        // ------------------------------------------------------------
        // Searching
        // ------------------------------------------------------------
        private static bool IsCategorySelected(string category)
        {
            return !string.IsNullOrWhiteSpace(category) &&
                   category != "All Categories";
        }

        public List<LocalEvent> SearchEvents(
            string searchText,
            string category,
            DateTime? fromDate,
            DateTime? toDate)
        {
            searchText = (searchText ?? "").Trim();

            RecordSearch(searchText, category);

            DateTime now = DateTime.Now;
            IEnumerable<LocalEvent> candidates;

            if (IsCategorySelected(category))
            {
                // Dictionary lookup: jump straight to the category.
                List<LocalEvent> inCategory;

                if (!eventsByCategory.TryGetValue(
                        category.Trim(), out inCategory))
                {
                    return new List<LocalEvent>();
                }

                candidates = inCategory;
            }
            else
            {
                // Sorted dictionary: events are already in date order.
                candidates = GetAllEvents();
            }

            IEnumerable<LocalEvent> results =
                candidates.Where(e => e.EventDate >= now);

            if (fromDate.HasValue)
            {
                results = results.Where(e =>
                    e.EventDate.Date >= fromDate.Value.Date);
            }

            if (toDate.HasValue)
            {
                results = results.Where(e =>
                    e.EventDate.Date <= toDate.Value.Date);
            }

            if (searchText.Length > 0)
            {
                results = results.Where(e =>
                    Contains(e.Title, searchText) ||
                    Contains(e.Description, searchText) ||
                    Contains(e.Location, searchText) ||
                    Contains(e.Category, searchText));
            }

            return results.OrderBy(e => e.EventDate).ToList();
        }

        private static bool Contains(string source, string value)
        {
            return (source ?? "").IndexOf(
                value,
                StringComparison.OrdinalIgnoreCase) >= 0;
        }

        // ------------------------------------------------------------
        // Tracking user behaviour (feeds the recommendation feature)
        // ------------------------------------------------------------
        private void RecordSearch(string searchText, string category)
        {
            if (searchText.Length > 0)
            {
                // Stack: push the newest search on top.
                searchHistory.Push(searchText);

                foreach (string keyword in ExtractKeywords(searchText))
                {
                    IncrementCount(keywordSearchCounts, keyword);
                }
            }

            if (IsCategorySelected(category))
            {
                IncrementCount(categorySearchCounts, category.Trim());
            }
        }

        // Called when the user clicks on an event to read about it.
        public void RecordView(int eventId)
        {
            LocalEvent localEvent = GetEventById(eventId);

            if (localEvent == null)
            {
                return;
            }

            // Only count the first time an event is viewed (set).
            if (viewedEventIds.Add(eventId))
            {
                IncrementCount(categoryViewCounts, localEvent.Category);
            }
        }

        private static void IncrementCount(
            Dictionary<string, int> counts,
            string key)
        {
            int current;

            if (!counts.TryGetValue(key, out current))
            {
                current = 0;
            }

            counts[key] = current + 1;
        }

        private static List<string> ExtractKeywords(string text)
        {
            char[] separators =
            {
                ' ', ',', ';', '.', '-', '/', '\\', '(', ')', '&', '\''
            };

            List<string> keywords = new List<string>();

            foreach (string word in text.Split(
                separators, StringSplitOptions.RemoveEmptyEntries))
            {
                string keyword = word.Trim().ToLowerInvariant();

                // Treat "roads" and "road" as the same keyword.
                if (keyword.Length > 3 && keyword.EndsWith("s"))
                {
                    keyword = keyword.Substring(0, keyword.Length - 1);
                }

                if (keyword.Length >= 3 && !StopWords.Contains(keyword))
                {
                    keywords.Add(keyword);
                }
            }

            return keywords;
        }

        // Most recent searches first (newest on top of the stack).
        public List<string> GetSearchHistory()
        {
            return searchHistory.ToList();
        }

        public List<string> GetRecentSearches(int max)
        {
            return searchHistory
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .Take(max)
                .ToList();
        }

        // Describes the categories the user is most interested in.
        public List<string> GetTopInterests(int max)
        {
            Dictionary<string, int> combined =
                new Dictionary<string, int>(
                    StringComparer.OrdinalIgnoreCase);

            foreach (KeyValuePair<string, int> item in categorySearchCounts)
            {
                combined[item.Key] = item.Value;
            }

            foreach (KeyValuePair<string, int> item in categoryViewCounts)
            {
                int current;
                combined.TryGetValue(item.Key, out current);
                combined[item.Key] = current + item.Value;
            }

            return combined
                .OrderByDescending(item => item.Value)
                .ThenBy(item => item.Key)
                .Take(max)
                .Select(item => item.Key)
                .ToList();
        }

        // ------------------------------------------------------------
        // Recommendation feature
        // ------------------------------------------------------------
        // Every upcoming event is given a score based on:
        //   - how often its category was searched   (x3)
        //   - how often its category was viewed     (x2)
        //   - how many times searched keywords appear in it (x2)
        // The best scoring events that the user has not yet viewed
        // are shown first.
        public List<EventRecommendation> GetRecommendations(int max)
        {
            List<LocalEvent> upcoming = GetUpcomingEvents();

            bool hasHistory =
                categorySearchCounts.Count > 0 ||
                categoryViewCounts.Count > 0 ||
                keywordSearchCounts.Count > 0;

            if (!hasHistory)
            {
                // Nothing to learn from yet: suggest the most important
                // events happening soonest.
                return upcoming
                    .OrderBy(e => e.Priority)
                    .ThenBy(e => e.EventDate)
                    .Take(max)
                    .Select(e => new EventRecommendation
                    {
                        Event = e,
                        Score = 0,
                        Reason = "Popular with residents - " +
                                 "search to get personal suggestions."
                    })
                    .ToList();
            }

            List<EventRecommendation> scored =
                new List<EventRecommendation>();

            foreach (LocalEvent e in upcoming)
            {
                int score = 0;
                List<string> reasons = new List<string>();
                int count;

                if (categorySearchCounts.TryGetValue(e.Category, out count))
                {
                    score += count * 3;
                    reasons.Add("you searched the " + e.Category +
                                " category");
                }

                if (categoryViewCounts.TryGetValue(e.Category, out count))
                {
                    score += count * 2;
                    reasons.Add("you viewed " + e.Category + " events");
                }

                string text = e.Title + " " + e.Category + " " +
                              e.Location + " " + e.Description;

                List<string> matched = new List<string>();

                foreach (KeyValuePair<string, int> keyword
                         in keywordSearchCounts)
                {
                    if (Contains(text, keyword.Key))
                    {
                        score += keyword.Value * 2;
                        matched.Add(keyword.Key);
                    }
                }

                if (matched.Count > 0)
                {
                    reasons.Add("you searched for \"" +
                                string.Join("\", \"", matched.Take(2)) +
                                "\"");
                }

                if (score > 0)
                {
                    scored.Add(new EventRecommendation
                    {
                        Event = e,
                        Score = score,
                        Reason = "Because " +
                                 string.Join(" and ", reasons) + "."
                    });
                }
            }

            return scored
                .OrderBy(r => viewedEventIds.Contains(r.Event.EventId) ? 1 : 0)
                .ThenByDescending(r => r.Score)
                .ThenBy(r => r.Event.EventDate)
                .Take(max)
                .ToList();
        }

        // Kept from the first version: returns just the events.
        public List<LocalEvent> GetRecommendedEvents()
        {
            return GetRecommendations(3)
                .Select(r => r.Event)
                .ToList();
        }

        // ------------------------------------------------------------
        // Priority queue: urgent announcements first
        // ------------------------------------------------------------
        public List<LocalEvent> GetPriorityEvents(int max)
        {
            MinPriorityQueue<LocalEvent> urgentQueue =
                new MinPriorityQueue<LocalEvent>();

            // Events arrive in date order, so events with the same
            // priority leave the queue soonest-first.
            foreach (LocalEvent e in GetUpcomingEvents())
            {
                if (e.IsAnnouncement || e.Priority == 1)
                {
                    urgentQueue.Enqueue(e, e.Priority);
                }
            }

            return urgentQueue.ToOrderedList().Take(max).ToList();
        }

        // ------------------------------------------------------------
        // Queue: step through upcoming events one at a time
        // ------------------------------------------------------------
        public void QueueUpcomingEvents()
        {
            eventQueue.Clear();

            foreach (LocalEvent localEvent in GetUpcomingEvents())
            {
                eventQueue.Enqueue(localEvent);
            }
        }

        public int QueuedEventCount
        {
            get
            {
                return eventQueue.Count;
            }
        }

        public LocalEvent GetNextQueuedEvent()
        {
            if (eventQueue.Count == 0)
            {
                return null;
            }

            return eventQueue.Dequeue();
        }
    }
}
