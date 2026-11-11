using MunicipalServicesApp.Generic;
using MunicipalServicesApp.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServicesApp.Services
{
    public class ServiceRequestService
    {
        public const string DefaultArea = "Pretoria CBD";

        public const string StructGeneral = "General Tree - Department hierarchy";
        public const string StructBinary = "Binary Tree - Request overview";
        public const string StructBst = "Binary Search Tree - Date index";
        public const string StructAvl = "AVL Tree - Request ID index";
        public const string StructRedBlack = "Red-Black Tree - Category index";
        public const string StructHeap = "Min-Heap - Priority queue";
        public const string StructGraph = "Graph - Service area network";

        // Master list of every request
        private readonly List<ServiceRequest> requests;

        // AVL tree: finds a request by its unique ID (always balanced)
        private readonly AvlTree<string, ServiceRequest> idIndex;

        // Binary search tree: keeps requests ordered by date submitted
        private readonly BinarySearchTree<string, ServiceRequest> dateIndex;

        // Red-black tree: keeps requests ordered by category, then ID
        private readonly RedBlackTree<string, ServiceRequest> categoryIndex;

        // Binary tree: a simple overview tree of request IDs
        private readonly BinaryTree<string> overviewTree;

        // General tree: Municipality -> Department -> Category
        private readonly GeneralTree<string> departmentTree;

        // Graph: service areas joined by roads (distance in km)
        private readonly Graph<string> serviceNetwork;

        // Where each area is drawn on the network diagram (0 to 1)
        private readonly Dictionary<string, PointF> areaLayout;

        // Hash table: Part 1 issue reference -> service request ID
        private readonly Dictionary<string, string> issueToRequest;

        private int nextNumber;

        public ServiceRequestService()
        {
            requests = new List<ServiceRequest>();

            idIndex = new AvlTree<string, ServiceRequest>(StringComparer.Ordinal);
            dateIndex = new BinarySearchTree<string, ServiceRequest>(StringComparer.Ordinal);
            categoryIndex = new RedBlackTree<string, ServiceRequest>(StringComparer.Ordinal);
            overviewTree = new BinaryTree<string>();

            serviceNetwork = new Graph<string>();
            areaLayout = new Dictionary<string, PointF>();

            issueToRequest = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            nextNumber = 1001;

            departmentTree = BuildDepartmentTree();
            BuildServiceNetwork();
            LoadSampleRequests();
        }

        // ------------------------------------------------------------
        // Setting up the structures
        // ------------------------------------------------------------
        private GeneralTree<string> BuildDepartmentTree()
        {
            GeneralTree<string> tree = new GeneralTree<string>("Municipal Services");

            GeneralTreeNode<string> water = tree.Root.AddChild("Water & Sanitation");
            water.AddChild("Water");
            water.AddChild("Sewage");
            water.AddChild("Sanitation");

            GeneralTreeNode<string> roads = tree.Root.AddChild("Roads & Transport");
            roads.AddChild("Roads");
            roads.AddChild("Street Lighting");

            GeneralTreeNode<string> energy = tree.Root.AddChild("Electricity & Energy");
            energy.AddChild("Electricity");

            GeneralTreeNode<string> environment = tree.Root.AddChild("Environmental Services");
            environment.AddChild("Waste Management");

            GeneralTreeNode<string> general = tree.Root.AddChild("General Services");
            general.AddChild("Other");

            return tree;
        }

        private void AddArea(string name, float x, float y)
        {
            serviceNetwork.AddVertex(name);
            areaLayout[name] = new PointF(x, y);
        }

        private void BuildServiceNetwork()
        {
            AddArea("Soshanguve", 0.30f, 0.08f);
            AddArea("Pretoria West", 0.08f, 0.42f);
            AddArea("Pretoria CBD", 0.30f, 0.42f);
            AddArea("Sunnyside", 0.45f, 0.28f);
            AddArea("Hatfield", 0.47f, 0.52f);
            AddArea("Brooklyn", 0.60f, 0.62f);
            AddArea("Lynnwood", 0.68f, 0.42f);
            AddArea("Menlyn", 0.80f, 0.58f);
            AddArea("Silverton", 0.82f, 0.28f);
            AddArea("Mamelodi", 0.92f, 0.10f);
            AddArea("Centurion", 0.36f, 0.90f);

            // Approximate road distances in kilometres
            serviceNetwork.AddEdge("Pretoria CBD", "Sunnyside", 3);
            serviceNetwork.AddEdge("Pretoria CBD", "Pretoria West", 5);
            serviceNetwork.AddEdge("Pretoria CBD", "Hatfield", 6);
            serviceNetwork.AddEdge("Pretoria CBD", "Silverton", 13);
            serviceNetwork.AddEdge("Pretoria CBD", "Soshanguve", 28);
            serviceNetwork.AddEdge("Sunnyside", "Hatfield", 4);
            serviceNetwork.AddEdge("Hatfield", "Brooklyn", 3);
            serviceNetwork.AddEdge("Hatfield", "Lynnwood", 6);
            serviceNetwork.AddEdge("Brooklyn", "Lynnwood", 4);
            serviceNetwork.AddEdge("Brooklyn", "Menlyn", 5);
            serviceNetwork.AddEdge("Brooklyn", "Centurion", 18);
            serviceNetwork.AddEdge("Lynnwood", "Menlyn", 3);
            serviceNetwork.AddEdge("Menlyn", "Silverton", 9);
            serviceNetwork.AddEdge("Menlyn", "Mamelodi", 14);
            serviceNetwork.AddEdge("Silverton", "Mamelodi", 8);
            serviceNetwork.AddEdge("Pretoria West", "Centurion", 17);
            serviceNetwork.AddEdge("Pretoria West", "Soshanguve", 26);
        }

        private void LoadSampleRequests()
        {
            AddSample("Burst water main on Church Street", "Water", "Pretoria CBD",
                "Water is flowing onto the road and affecting traffic.", 1, 12, RequestStatus.Completed);
            AddSample("Large pothole near Hatfield Plaza", "Roads", "Hatfield",
                "A large pothole is damaging vehicles.", 3, 11, RequestStatus.InProgress);
            AddSample("Streetlights not working on Lynnwood Road", "Street Lighting", "Lynnwood",
                "Four streetlights have been off for a week.", 3, 10, RequestStatus.UnderReview);
            AddSample("Sewage overflow in Sunnyside", "Sewage", "Sunnyside",
                "Raw sewage is leaking into the street.", 1, 9, RequestStatus.InProgress);
            AddSample("Missed refuse collection", "Waste Management", "Mamelodi",
                "Refuse has not been collected for two weeks.", 2, 9, RequestStatus.Submitted);
            AddSample("Power outage affecting several streets", "Electricity", "Brooklyn",
                "There has been no electricity since last night.", 1, 8, RequestStatus.InProgress);
            AddSample("Blocked storm water drain", "Roads", "Menlyn",
                "The drain is blocked and causing flooding.", 2, 8, RequestStatus.UnderReview);
            AddSample("Illegal dumping near Silverton park", "Waste Management", "Silverton",
                "Builders rubble was dumped next to the park.", 3, 7, RequestStatus.Submitted);
            AddSample("Low water pressure", "Water", "Centurion",
                "Residents report very low pressure every morning.", 3, 7, RequestStatus.Completed);
            AddSample("Broken traffic signal", "Roads", "Pretoria West",
                "The traffic signal is stuck on red.", 1, 6, RequestStatus.Completed);
            AddSample("Public toilets out of order", "Sanitation", "Pretoria CBD",
                "The public toilets at the taxi rank are closed.", 3, 6, RequestStatus.UnderReview);
            AddSample("Damaged electricity cable", "Electricity", "Soshanguve",
                "An exposed cable is lying on the pavement.", 1, 5, RequestStatus.InProgress);
            AddSample("Water leak at street corner", "Water", "Sunnyside",
                "A small leak has been running for days.", 4, 5, RequestStatus.Submitted);
            AddSample("Overgrown sidewalk blocking pedestrians", "Other", "Hatfield",
                "Vegetation is blocking the pavement.", 4, 4, RequestStatus.Submitted);
            AddSample("Flickering streetlight", "Street Lighting", "Pretoria CBD",
                "The light flickers throughout the night.", 4, 4, RequestStatus.Completed);
            AddSample("Sewer smell outside school", "Sewage", "Mamelodi",
                "A strong smell is coming from the drain outside the school.", 2, 3, RequestStatus.UnderReview);
            AddSample("Cluster of potholes on main road", "Roads", "Silverton",
                "Several potholes opened up after the rain.", 2, 3, RequestStatus.Submitted);
            AddSample("No water supply", "Water", "Brooklyn",
                "Taps have been dry since this morning.", 1, 2, RequestStatus.Submitted);
            AddSample("Overflowing public bins", "Waste Management", "Pretoria CBD",
                "The bins in the park have not been emptied.", 3, 2, RequestStatus.Submitted);
            AddSample("Transformer making a loud noise", "Electricity", "Centurion",
                "The transformer is humming loudly.", 2, 1, RequestStatus.Submitted);
            AddSample("Cracked pavement", "Roads", "Lynnwood",
                "The cracked pavement is a tripping hazard.", 4, 1, RequestStatus.Submitted);
            AddSample("Leaking sewer pipe", "Sewage", "Pretoria West",
                "A sewer pipe is leaking next to the pavement.", 3, 1, RequestStatus.UnderReview);
        }

        private void AddSample(
            string title,
            string category,
            string area,
            string description,
            int priority,
            int daysAgo,
            RequestStatus status)
        {
            ServiceRequest request = new ServiceRequest();

            request.RequestId = NextRequestId();
            request.Title = title;
            request.Category = category;
            request.Department = GetDepartmentForCategory(category);
            request.Location = area;
            request.Area = area;
            request.Description = description;
            request.Priority = priority;

            // Slightly different times so the sample data looks natural.
            DateTime submitted = DateTime.Now.AddDays(-daysAgo).AddMinutes(-(nextNumber * 37 % 600));
            request.DateSubmitted = submitted;

            request.SetStatus(RequestStatus.Submitted, submitted, "Request received.");

            if (status >= RequestStatus.UnderReview)
            {
                request.SetStatus(RequestStatus.UnderReview, submitted.AddHours(3),
                    "Assigned to the " + request.Department + " department.");
            }

            if (status >= RequestStatus.InProgress)
            {
                request.SetStatus(RequestStatus.InProgress, submitted.AddHours(20),
                    "A work crew has been dispatched.");
            }

            if (status >= RequestStatus.Completed)
            {
                request.SetStatus(RequestStatus.Completed, submitted.AddDays(1).AddHours(6),
                    "Work completed and checked.");
            }

            AddRequest(request);
        }

        private string NextRequestId()
        {
            string id = "SR-" + nextNumber;
            nextNumber++;

            return id;
        }

        // ------------------------------------------------------------
        // Keys used by the search trees
        // ------------------------------------------------------------
        private static string DateKey(ServiceRequest request)
        {
            return request.DateSubmitted.ToString("yyyyMMddHHmmssfff", CultureInfo.InvariantCulture) +
                   "|" + request.RequestId;
        }

        private static string CategoryKey(string category, string requestId)
        {
            return category + "|" + requestId;
        }

        private static string KeyToId(string key)
        {
            int position = key.IndexOf('|');

            return position >= 0 ? key.Substring(position + 1) : key;
        }

        private static string KeyToCategory(string key)
        {
            int position = key.IndexOf('|');

            return position >= 0 ? key.Substring(0, position) : key;
        }

        // ------------------------------------------------------------
        // Adding and importing requests
        // ------------------------------------------------------------
        public void AddRequest(ServiceRequest request)
        {
            requests.Add(request);

            idIndex.Insert(request.RequestId, request);
            dateIndex.Insert(DateKey(request), request);
            categoryIndex.Insert(CategoryKey(request.Category, request.RequestId), request);
            overviewTree.Insert(request.RequestId);
        }

        // Every issue reported in Part 1 becomes a service request.
        // Returns how many new requests were created.
        public int SyncFromIssues(IssueService issueService)
        {
            int added = 0;

            foreach (Issue issue in issueService.GetAllIssues())
            {
                if (string.IsNullOrEmpty(issue.ReferenceNumber) ||
                    issueToRequest.ContainsKey(issue.ReferenceNumber))
                {
                    continue;
                }

                string category = string.IsNullOrWhiteSpace(issue.Category) ? "Other" : issue.Category;
                string location = string.IsNullOrWhiteSpace(issue.Location) ? "Unknown location" : issue.Location;

                ServiceRequest request = new ServiceRequest();

                request.RequestId = NextRequestId();
                request.Title = category + " issue at " + location;
                request.Category = category;
                request.Department = GetDepartmentForCategory(category);
                request.Location = location;
                request.Area = DetectArea(location);
                request.Description = issue.Description;
                request.Priority = PriorityFromText(issue.Priority);
                request.DateSubmitted = issue.DateSubmitted;
                request.SourceReference = issue.ReferenceNumber;

                request.SetStatus(RequestStatus.Submitted, issue.DateSubmitted,
                    "Received from the Report Issues page (" + issue.ReferenceNumber + ").");

                AddRequest(request);
                issueToRequest[issue.ReferenceNumber] = request.RequestId;
                added++;
            }

            return added;
        }

        private static int PriorityFromText(string text)
        {
            switch ((text ?? "").Trim().ToLower())
            {
                case "urgent":
                    return 1;
                case "high":
                    return 2;
                case "low":
                    return 4;
                default:
                    return 3;
            }
        }

        // Finds which service area a free-text location belongs to.
        private string DetectArea(string location)
        {
            foreach (string area in serviceNetwork.Vertices)
            {
                if ((location ?? "").IndexOf(area, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return area;
                }
            }

            return DefaultArea;
        }

        // ------------------------------------------------------------
        // Departments (general tree)
        // ------------------------------------------------------------
        public GeneralTreeNode<string> GetDepartmentRoot()
        {
            return departmentTree.Root;
        }

        public List<string> GetCategoriesUnder(GeneralTreeNode<string> node)
        {
            return departmentTree.GetLeafValues(node);
        }

        public string GetDepartmentForCategory(string category)
        {
            GeneralTreeNode<string> node = departmentTree.Find(v => v == category);

            if (node != null && node.Parent != null && node.Parent.Parent != null)
            {
                return node.Parent.Value;
            }

            return "General Services";
        }

        // Counts requests in the given categories using the red-black tree.
        public int CountForCategories(IEnumerable<string> categories)
        {
            int total = 0;

            foreach (string category in categories)
            {
                total += categoryIndex.Range(category + "|", category + "|\uffff").Count;
            }

            return total;
        }

        // ------------------------------------------------------------
        // Tracking and filtering
        // ------------------------------------------------------------
        // Finds a request by its ID using the AVL tree. The user may also
        // type a number (1004) or the reference of the original issue.
        public ServiceRequest TrackRequest(string input, out int comparisons)
        {
            comparisons = 0;

            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            string text = input.Trim();
            string id = text.ToUpperInvariant();
            string mapped;

            if (issueToRequest.TryGetValue(text, out mapped))
            {
                id = mapped;
            }
            else if (text.All(char.IsDigit))
            {
                id = "SR-" + text;
            }

            ServiceRequest found;
            bool exists = idIndex.TryGetValue(id, out found);
            comparisons = idIndex.LastSearchComparisons;

            return exists ? found : null;
        }

        // Filters the requests. The best index is used for the first step:
        // the red-black tree for categories, the binary search tree for
        // dates, otherwise the full date-ordered list.
        public List<ServiceRequest> Filter(
            IList<string> categories,
            RequestStatus? status,
            int? priority,
            DateTime? fromDate,
            DateTime? toDate)
        {
            IEnumerable<ServiceRequest> source;

            if (categories != null && categories.Count > 0)
            {
                List<ServiceRequest> inCategories = new List<ServiceRequest>();

                foreach (string category in categories)
                {
                    inCategories.AddRange(
                        categoryIndex.Range(category + "|", category + "|\uffff"));
                }

                source = inCategories;
            }
            else if (fromDate.HasValue || toDate.HasValue)
            {
                string low = fromDate.HasValue
                    ? fromDate.Value.Date.ToString("yyyyMMdd", CultureInfo.InvariantCulture)
                    : "";

                string high = toDate.HasValue
                    ? toDate.Value.Date.ToString("yyyyMMdd", CultureInfo.InvariantCulture) + "\uffff"
                    : "\uffff";

                source = dateIndex.Range(low, high);
            }
            else
            {
                source = dateIndex.InOrderValues();
            }

            if (fromDate.HasValue)
            {
                source = source.Where(r => r.DateSubmitted.Date >= fromDate.Value.Date);
            }

            if (toDate.HasValue)
            {
                source = source.Where(r => r.DateSubmitted.Date <= toDate.Value.Date);
            }

            if (status.HasValue)
            {
                source = source.Where(r => r.Status == status.Value);
            }

            if (priority.HasValue)
            {
                source = source.Where(r => r.Priority == priority.Value);
            }

            return source.OrderByDescending(r => r.DateSubmitted).ToList();
        }

        // ------------------------------------------------------------
        // Counts for the dashboard cards
        // ------------------------------------------------------------
        public int TotalCount
        {
            get
            {
                return requests.Count;
            }
        }

        public int OpenCount
        {
            get
            {
                return requests.Count(r => r.IsOpen);
            }
        }

        public int InProgressCount
        {
            get
            {
                return requests.Count(r => r.Status == RequestStatus.InProgress);
            }
        }

        public int CompletedCount
        {
            get
            {
                return requests.Count(r => r.Status == RequestStatus.Completed);
            }
        }

        // ------------------------------------------------------------
        // Updating status
        // ------------------------------------------------------------
        // Moves a request to its next stage and records it in the history.
        public bool AdvanceStatus(string requestId, out string message)
        {
            ServiceRequest request;

            if (!idIndex.TryGetValue(requestId, out request))
            {
                message = "Request " + requestId + " was not found.";
                return false;
            }

            if (!request.IsOpen)
            {
                message = request.RequestId + " is already completed.";
                return false;
            }

            RequestStatus next = (RequestStatus)((int)request.Status + 1);
            string note;

            switch (next)
            {
                case RequestStatus.UnderReview:
                    note = "Assigned to the " + request.Department + " department.";
                    break;
                case RequestStatus.InProgress:
                    note = "A work crew has been dispatched.";
                    break;
                default:
                    note = "Work completed and checked.";
                    break;
            }

            request.SetStatus(next, DateTime.Now, note);
            message = request.RequestId + " moved to " + request.StatusText + ".";

            return true;
        }

        // ------------------------------------------------------------
        // Priority queue (min-heap)
        // ------------------------------------------------------------
        // Open requests go into the heap. The lowest priority number
        // (Urgent) comes out first. Requests are added oldest first, so
        // requests with the same priority leave in the order they arrived.
        private MinPriorityQueue<ServiceRequest> BuildHeap()
        {
            MinPriorityQueue<ServiceRequest> heap = new MinPriorityQueue<ServiceRequest>();

            foreach (ServiceRequest request in dateIndex.InOrderValues())
            {
                if (request.IsOpen)
                {
                    heap.Enqueue(request, request.Priority);
                }
            }

            return heap;
        }

        public List<ServiceRequest> GetPriorityOrder()
        {
            return BuildHeap().ToOrderedList();
        }

        public List<ServiceRequest> GetHeapArray()
        {
            return BuildHeap().ToHeapArray();
        }

        public ServiceRequest PeekNextRequest()
        {
            MinPriorityQueue<ServiceRequest> heap = BuildHeap();

            return heap.Count == 0 ? null : heap.Peek();
        }

        // Takes the most urgent request and moves it to its next stage.
        public bool ProcessNextRequest(out string message)
        {
            ServiceRequest next = PeekNextRequest();

            if (next == null)
            {
                message = "There are no open requests.";
                return false;
            }

            return AdvanceStatus(next.RequestId, out message);
        }

        // ------------------------------------------------------------
        // Service network (graph)
        // ------------------------------------------------------------
        public List<string> GetAreas()
        {
            return serviceNetwork.Vertices;
        }

        public List<GraphEdge<string>> GetRoads()
        {
            return serviceNetwork.Edges;
        }

        public Dictionary<string, PointF> GetAreaLayout()
        {
            return areaLayout;
        }

        public Dictionary<string, int> GetOpenCountByArea()
        {
            Dictionary<string, int> counts = new Dictionary<string, int>();

            foreach (string area in serviceNetwork.Vertices)
            {
                counts[area] = 0;
            }

            foreach (ServiceRequest request in requests)
            {
                if (request.IsOpen && counts.ContainsKey(request.Area))
                {
                    counts[request.Area]++;
                }
            }

            return counts;
        }

        // Breadth-first search: areas ordered by how many roads away they are.
        public List<KeyValuePair<string, int>> GetNearbyAreas(string startArea)
        {
            return serviceNetwork.BreadthFirst(startArea);
        }

        // Depth-first search: a route that visits every area.
        public List<string> GetCoverageRoute(string startArea)
        {
            return serviceNetwork.DepthFirst(startArea);
        }

        // Kruskal's minimum spanning tree: the shortest set of roads that
        // still connects every area.
        public List<GraphEdge<string>> GetMinimumSpanningNetwork(out double totalKm, out double allRoadsKm)
        {
            List<GraphEdge<string>> tree = serviceNetwork.MinimumSpanningTree();

            totalKm = Graph<string>.TotalWeight(tree);
            allRoadsKm = Graph<string>.TotalWeight(serviceNetwork.Edges);

            return tree;
        }

        // Open requests in the same area or in areas one road away.
        public List<ServiceRequest> GetNearbyOpenRequests(ServiceRequest request)
        {
            HashSet<string> nearbyAreas = new HashSet<string>();

            foreach (KeyValuePair<string, int> area in serviceNetwork.BreadthFirst(request.Area))
            {
                if (area.Value <= 1)
                {
                    nearbyAreas.Add(area.Key);
                }
            }

            return requests
                .Where(r => r.IsOpen &&
                            r.RequestId != request.RequestId &&
                            nearbyAreas.Contains(r.Area))
                .ToList();
        }

        // ------------------------------------------------------------
        // Data structure explorer
        // ------------------------------------------------------------
        public List<string> GetStructureNames()
        {
            return new List<string>
            {
                StructGeneral,
                StructBinary,
                StructBst,
                StructAvl,
                StructRedBlack,
                StructHeap,
                StructGraph
            };
        }

        public List<string> GetTraversalOptions(string structure)
        {
            switch (structure)
            {
                case StructGeneral:
                    return new List<string> { "Pre-order (depth-first)", "Level-order (breadth-first)" };
                case StructHeap:
                    return new List<string> { "Heap array (level order)", "Priority order (extract minimum)" };
                case StructGraph:
                    return new List<string>
                    {
                        "Breadth-first search",
                        "Depth-first search",
                        "Minimum spanning tree (Kruskal)"
                    };
                default:
                    return new List<string> { "In-order", "Pre-order", "Post-order", "Level-order" };
            }
        }

        public List<string> RunTraversal(string structure, string option)
        {
            List<string> lines = new List<string>();

            switch (structure)
            {
                case StructGeneral:
                    List<string> values = option.StartsWith("Pre")
                        ? departmentTree.PreOrder()
                        : departmentTree.LevelOrder();
                    lines.AddRange(values);
                    break;

                case StructBinary:
                    List<string> ids = new List<string>();

                    if (option == "In-order")
                    {
                        ids = overviewTree.InOrder();
                    }
                    else if (option == "Pre-order")
                    {
                        ids = overviewTree.PreOrder();
                    }
                    else if (option == "Post-order")
                    {
                        ids = overviewTree.PostOrder();
                    }
                    else
                    {
                        ids = overviewTree.LevelOrder();
                    }

                    foreach (string id in ids)
                    {
                        lines.Add(RequestLabel(id));
                    }

                    break;

                case StructBst:
                    foreach (string key in KeysFor(dateIndex, option))
                    {
                        lines.Add(RequestLabel(KeyToId(key)));
                    }

                    break;

                case StructAvl:
                    foreach (string key in KeysFor(idIndex, option))
                    {
                        lines.Add(RequestLabel(key) + "   [balance " + idIndex.GetBalanceFactor(key) + "]");
                    }

                    break;

                case StructRedBlack:
                    foreach (string key in KeysFor(categoryIndex, option))
                    {
                        lines.Add(RequestLabel(KeyToId(key)) + "   [" + KeyToCategory(key) + ", " +
                                  (categoryIndex.IsRedNode(key) ? "red" : "black") + "]");
                    }

                    break;

                case StructHeap:
                    List<ServiceRequest> heapItems = option.StartsWith("Heap")
                        ? GetHeapArray()
                        : GetPriorityOrder();

                    foreach (ServiceRequest item in heapItems)
                    {
                        lines.Add(item.RequestId + "   [" + item.PriorityLabel + ", " + item.StatusText + "]   " + item.Title);
                    }

                    break;

                case StructGraph:
                    lines.AddRange(RunGraphOperation(option));
                    break;
            }

            return lines;
        }

        private List<string> KeysFor(SearchTreeBase<string, ServiceRequest> tree, string option)
        {
            if (option == "In-order")
            {
                return tree.InOrderKeys();
            }

            if (option == "Pre-order")
            {
                return tree.PreOrderKeys();
            }

            if (option == "Post-order")
            {
                return tree.PostOrderKeys();
            }

            return tree.LevelOrderKeys();
        }

        private List<string> RunGraphOperation(string option)
        {
            List<string> lines = new List<string>();

            if (option.StartsWith("Breadth"))
            {
                foreach (KeyValuePair<string, int> area in serviceNetwork.BreadthFirst(DefaultArea))
                {
                    lines.Add(area.Key + "   [" + area.Value + " road(s) from " + DefaultArea + "]");
                }
            }
            else if (option.StartsWith("Depth"))
            {
                foreach (string area in serviceNetwork.DepthFirst(DefaultArea))
                {
                    lines.Add(area);
                }
            }
            else
            {
                double total;
                double all;

                foreach (GraphEdge<string> edge in GetMinimumSpanningNetwork(out total, out all))
                {
                    lines.Add(edge.From + "  <->  " + edge.To + "   (" + edge.Weight + " km)");
                }

                lines.Add("");
                lines.Add("Total: " + total + " km (all roads together: " + all + " km)");
            }

            return lines;
        }

        private string RequestLabel(string requestId)
        {
            ServiceRequest request;

            if (idIndex.TryGetValue(requestId, out request))
            {
                return requestId + "   " + request.Title;
            }

            return requestId;
        }

        public string DescribeStructure(string structure)
        {
            StringBuilder text = new StringBuilder();
            string nl = Environment.NewLine;

            switch (structure)
            {
                case StructGeneral:
                    text.AppendLine("GENERAL TREE");
                    text.AppendLine();
                    text.AppendLine("Role: organises the municipal departments and their service categories.");
                    text.AppendLine("Used for: the department tree on the Track Requests tab. Clicking a branch shows the requests of every category below it.");
                    text.AppendLine();
                    text.AppendLine("Nodes: " + departmentTree.Count());
                    text.AppendLine("Height: " + departmentTree.Height() + " levels");
                    text.AppendLine();
                    text.AppendLine("Pre-order visits a node before its children (depth-first).");
                    text.AppendLine("Level-order visits one level at a time (breadth-first, uses a queue).");
                    break;

                case StructBinary:
                    text.AppendLine("BINARY TREE");
                    text.AppendLine();
                    text.AppendLine("Role: each node has at most two children. Request IDs are added in the first free position, level by level, so the tree is always complete.");
                    text.AppendLine("Used for: showing the four classic traversals on real request data.");
                    text.AppendLine();
                    text.AppendLine("Nodes: " + overviewTree.Count);
                    text.AppendLine("Height: " + overviewTree.Height());
                    text.AppendLine();
                    text.AppendLine("In-order: left, node, right");
                    text.AppendLine("Pre-order: node, left, right");
                    text.AppendLine("Post-order: left, right, node");
                    text.AppendLine("Level-order: row by row");
                    break;

                case StructBst:
                    text.AppendLine("BINARY SEARCH TREE");
                    text.AppendLine();
                    text.AppendLine("Role: keeps requests sorted by the date they were submitted. Smaller keys go left, larger keys go right.");
                    text.AppendLine("Used for: the From / To date filter (a range search that skips whole branches) and for listing requests in date order.");
                    text.AppendLine();
                    text.AppendLine("Nodes: " + dateIndex.Count);
                    text.AppendLine("Height: " + dateIndex.Height() + " (best possible: " + dateIndex.MinimumPossibleHeight() + ")");
                    text.AppendLine();
                    text.AppendLine("Search: O(log n) when balanced, O(n) in the worst case.");
                    text.AppendLine("An in-order traversal always returns the keys in sorted order.");
                    break;

                case StructAvl:
                    BinarySearchTree<string, int> plain = new BinarySearchTree<string, int>(StringComparer.Ordinal);

                    foreach (string id in requests.Select(r => r.RequestId).OrderBy(i => i, StringComparer.Ordinal))
                    {
                        plain.Insert(id, 0);
                    }

                    text.AppendLine("AVL TREE");
                    text.AppendLine();
                    text.AppendLine("Role: a self-balancing binary search tree. The heights of the left and right side of every node never differ by more than 1 (the balance factor is -1, 0 or 1).");
                    text.AppendLine("Used for: the \"Track a request by ID\" search. Every lookup is guaranteed O(log n).");
                    text.AppendLine();
                    text.AppendLine("Nodes: " + idIndex.Count);
                    text.AppendLine("Height: " + idIndex.Height() + " (best possible: " + idIndex.MinimumPossibleHeight() + ")");
                    text.AppendLine("Rotations done so far: " + idIndex.RotationCount);
                    text.AppendLine();
                    text.AppendLine("Why balancing matters: request IDs are created in increasing order (SR-1001, SR-1002 ...). A plain binary search tree would turn into a straight line with height " + plain.Height() + ". The AVL tree rotates to keep its height at " + idIndex.Height() + ".");
                    break;

                case StructRedBlack:
                    text.AppendLine("RED-BLACK TREE");
                    text.AppendLine();
                    text.AppendLine("Role: a balanced search tree that colours nodes red or black. The root is black, a red node never has a red child, and every path has the same number of black nodes.");
                    text.AppendLine("Used for: the category index. Requests are stored as \"Category|ID\", so all requests of one category sit next to each other. This powers the department tree counts and the category filter.");
                    text.AppendLine();
                    text.AppendLine("Nodes: " + categoryIndex.Count);
                    text.AppendLine("Height: " + categoryIndex.Height() + " (best possible: " + categoryIndex.MinimumPossibleHeight() + ")");
                    text.AppendLine("Rotations: " + categoryIndex.RotationCount + ", colour flips: " + categoryIndex.ColourFlipCount);
                    text.AppendLine();
                    text.AppendLine("An AVL tree is balanced more strictly (a smaller height, so slightly faster searches). A red-black tree allows a little more imbalance but needs less rebalancing work when items are deleted, so it suits data that changes often.");
                    break;

                case StructHeap:
                    MinPriorityQueue<ServiceRequest> heap = BuildHeap();

                    text.AppendLine("MIN-HEAP (PRIORITY QUEUE)");
                    text.AppendLine();
                    text.AppendLine("Role: a complete binary tree stored in an array where every parent has a higher priority (a lower number) than its children. The most urgent item is always at the top.");
                    text.AppendLine("Used for: the Priority Queue tab. Open requests are served Urgent first, then High, Medium and Low. Requests with the same priority are served oldest first.");
                    text.AppendLine();
                    text.AppendLine("Open requests in the heap: " + heap.Count);
                    text.AppendLine();
                    text.AppendLine("Peek: O(1)    Insert: O(log n)    Remove top: O(log n)");
                    break;

                case StructGraph:
                    text.AppendLine("GRAPH");
                    text.AppendLine();
                    text.AppendLine("Role: models how the service areas are connected by roads. Each area is a vertex, each road is an edge with a distance in km.");
                    text.AppendLine("Used for: the Service Network tab. Breadth-first search finds nearby areas, depth-first search builds a route that covers every area, and Kruskal's algorithm finds the minimum spanning tree: the shortest set of roads that still connects every area.");
                    text.AppendLine();
                    text.AppendLine("Areas (vertices): " + serviceNetwork.VertexCount);
                    text.AppendLine("Roads (edges): " + serviceNetwork.EdgeCount);
                    text.AppendLine();
                    text.AppendLine("The explorer starts every search from " + DefaultArea + ".");
                    break;
            }

            return text.ToString().Replace("\r\n", nl);
        }
    }
}
