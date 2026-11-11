# Municipal Services Application

## 1. Project Overview

The Municipal Services Application is a C# Windows Forms application developed to allow citizens to report municipal service-related issues.

The application provides a simple interface where users can enter information about an issue, select a category and priority, provide a description, and attach a related file.

Part 1 provides the Report Issues functionality. Part 2 adds the **Local Events and Announcements** page, which lets citizens browse and search upcoming events and announcements and receive personalised recommendations. Part 3 (the final part) adds the **Service Request Status** page, where citizens can track the progress of their service requests, and gives the whole application a new look with a header banner and a consistent colour theme.

---

## 2. Technologies Used

- C#
- .NET Framework
- Windows Forms
- Visual Studio
- Object-Oriented Programming
- Generic Classes
- List Data Structure
- Stack, Queue and Priority Queue (binary heap)
- Dictionary, SortedDictionary and HashSet / SortedSet
- LINQ

---

## 3. Main Features

### Report Issues

Citizens can report municipal issues by providing:

- Location of the issue
- Issue category
- Priority
- Description
- Optional file attachment

After submitting an issue, the application generates a unique reference number and displays a confirmation message.

### View Submitted Issues

The application includes a View Submitted Issues feature that allows submitted issues to be displayed in a DataGridView.

Users can search submitted issues using information such as:

- Reference number
- Location
- Category
- Priority
- Status

### Engagement Feature

The Report Issues form includes a progress indicator and encouraging messages to guide users while completing the report.

### User Feedback

Message boxes are used to provide feedback when:

- Required information is missing
- An issue is successfully submitted
- An action requires user attention

### Service Request Status (Part 3)

Open it from the main menu with **Service Request Status**. The page has four tabs:

- **Track Requests** - a department tree on the left, dashboard cards (total, open, in progress, completed), filters (status, priority, date range), a request list with colour-coded status and priority, and a details panel with a **progress tracker** (Submitted > Under Review > In Progress > Completed) and a status history.
- **Priority Queue (Heap)** - the open requests in the order they should be handled (Urgent first), the heap array as it is stored in memory, and a **Process next request** button.
- **Service Network (Graph)** - a drawn map of service areas joined by roads. Run a breadth-first search (nearby areas), a depth-first search (coverage route) or Kruskal's minimum spanning tree.
- **Data Structures** - an explorer that shows every data structure with its traversals (in-order, pre-order, post-order, level-order, BFS, DFS) and a short explanation of its role.

Every issue reported on the Report Issues page automatically becomes a service request, so it can be tracked here.

### Local Events and Announcements (Part 2)

Open it from the main menu with **Local Events & Announcements**. The page contains:

- **Events grid** - upcoming events and announcements in date order. Announcements are shaded yellow.
- **Search** - search by keyword (title, description, location or category), filter by category, and filter by date range. Tick the checkbox next to *From Date* / *To Date* to use a date filter.
- **Event Details** - click an event to read its full details.
- **Recommended For You** - suggestions based on what you search for and click. Select one to see *why* it was recommended.
- **Priority Announcements** - the most urgent announcements first.
- **Recent Searches** - your latest searches. Double-click one to repeat it.
- **Next Upcoming Event** - steps through upcoming events one at a time.

---

## 4. Data Structure

The application uses a List data structure to store reported issues.

A generic class called `IssueManager<T>` is used to manage the collection of issues. When the application uses `IssueManager<Issue>`, the generic type `T` represents the `Issue` class.

The list allows multiple issues to be stored dynamically as citizens submit reports.

The data structure supports operations such as:

- Adding issues
- Retrieving issues
- Counting issues
- Removing issues
- Clearing issues

Each issue is represented by an `Issue` object containing information such as the reference number, location, category, description, priority, attachment path, status and submission date.

---

### Part 3 data structures (`ServiceRequestService.cs` and the `Generic` folder)

| Data structure | Class | Used for |
|---|---|---|
| General tree | `GeneralTree<T>` | The department hierarchy (Municipality > Department > Category) shown in the tree view. Selecting a branch filters the requests of all categories below it. |
| Binary tree | `BinaryTree<T>` | An overview tree of request IDs filled level by level. Used to demonstrate the four traversals. |
| Binary search tree | `BinarySearchTree<TKey, TValue>` | Index of requests by date submitted. Powers the From / To date filter with a range search. |
| AVL tree | `AvlTree<TKey, TValue>` | Index of requests by unique ID. Powers **Track a request by ID** with guaranteed O(log n) lookups. Balanced with rotations. |
| Red-black tree | `RedBlackTree<TKey, TValue>` | Index of requests by category. Powers the category counts and the category filter. |
| Heap | `MinPriorityQueue<T>` | The priority queue: the most urgent open request is always on top. |
| Graph | `Graph<T>` | Service areas (vertices) joined by roads (edges, in km). |
| Graph traversal | `Graph<T>.BreadthFirst / DepthFirst` | Nearby areas (BFS) and a coverage route (DFS). |
| Minimum spanning tree | `Graph<T>.MinimumSpanningTree` | Kruskal's algorithm finds the shortest set of roads that connects every area. |
| Hash table | `Dictionary<string, string>` | Links the reference of a Part 1 issue (ISS-...) to its service request ID. |

The three search trees share the code in `SearchTreeBase<TKey, TValue>` (traversals, range search, height) and only differ in how they insert and balance.

### Part 2 data structures (`EventService.cs`)

| Data structure | Used for |
|---|---|
| `SortedDictionary<DateTime, List<LocalEvent>>` | Keeps events organised in date order |
| `Dictionary<int, LocalEvent>` | Fast lookup of an event by its ID |
| `Dictionary<string, List<LocalEvent>>` | Fast lookup of events by category (used by the category filter) |
| `Dictionary<string, int>` (x3) | Counts category searches, category views and searched keywords for recommendations |
| `HashSet<string>` | Unique event categories (fills the category drop-down) |
| `SortedSet<DateTime>` | Unique event dates in order |
| `HashSet<int>` | Events the user has already viewed (recommendations show unseen events first) |
| `Stack<string>` | Search history - the most recent search is on top |
| `Queue<LocalEvent>` | The "Next Upcoming Event" queue (first in, first out) |
| `MinPriorityQueue<LocalEvent>` (custom, `Generic` folder) | Priority announcements - priority 1 (High) leaves the queue before 2 (Medium) and 3 (Low) |

### Recommendation feature

Every search and click is recorded. Each upcoming event is then scored:

- +3 for each time its **category** was searched
- +2 for each time its **category** was viewed (clicked)
- +2 for each time a **searched keyword** appears in its title, category, location or description

The highest scoring events (that the user has not yet viewed) are shown in *Recommended For You*, together with a short reason such as *"Because you searched the Roads category and you searched for 'pothole'."* Before any search is made, the page suggests the most important upcoming events.

---

## 5. Project Structure

The application is organised into several folders:

### Forms

Contains the Windows Forms used by the application.

- `ReportIssuesForm.cs`
- `ManageIssuesForm.cs`
- `IssueDetailsForm.cs`
- `LocalEventsForm.cs` (Part 2)
- `ServiceRequestStatusForm.cs` (Part 3)

### Models

Contains the data models.

- `Issue.cs`
- `LocalEvent.cs` (Part 2)
- `EventRecommendation.cs` (Part 2)
- `ServiceRequest.cs` (Part 3 - request, status and history)

### Services

Contains the services responsible for the application logic.

- `IssueService.cs`
- `EventService.cs` (Part 2 - searching, data structures and recommendations)
- `ServiceRequestService.cs` (Part 3 - trees, heap, graph and request tracking)

### Generic

Contains the generic classes.

- `IssueManager.cs`
- `MinPriorityQueue.cs` (Part 2 - generic priority queue / heap)
- `GeneralTree.cs`, `BinaryTree.cs` (Part 3)
- `SearchTreeBase.cs`, `BinarySearchTree.cs`, `AvlTree.cs`, `RedBlackTree.cs` (Part 3)
- `Graph.cs` (Part 3 - graph, BFS, DFS and Kruskal)

### UI

Contains the shared look and feel of the application (Part 3).

- `Theme.cs` - all colours and the styling of buttons and grids. Change a colour here and every form follows.
- `AppHeader.cs` - the header banner shown at the top of every form. Set its `Title` and `Subtitle` in the designer.
- `TileButton.cs` - the large card buttons on the main menu.
- `BufferedPanel.cs` - a flicker-free panel used for the progress tracker and the network diagram.

### Main Form

- `MainForm.cs`

The Main Form provides access to the three municipal service functions and shows a live summary of issues, events and open service requests.

---

## 6. How to Compile and Run

### Requirements

The following software is required:

- Windows operating system
- Visual Studio
- .NET Framework compatible with the project

### Steps

1. Open Visual Studio.
2. Open the Municipal Services Application solution.
3. Allow Visual Studio to load the project and restore any required components.
4. Build the solution by selecting:

   `Build → Build Solution`

5. If the build completes successfully, run the application by selecting:

   `Debug → Start Without Debugging`

   or press:

   `Ctrl + F5`

---

## 7. How to Use the Application

### Step 1: Open the Application

When the application starts, the Main Menu is displayed.

The menu contains:

- Report Issues
- Local Events and Announcements
- Service Request Status

Report Issues and Local Events & Announcements are enabled. Service Request Status is disabled because it is planned for future implementation.

### Step 2: Report an Issue

Select **Report Issues**.

Enter the required information:

1. Enter the location.
2. Select an issue category.
3. Select the priority.
4. Enter a description.
5. Optionally attach a file.
6. Click **Submit**.

### Step 3: Confirmation

After a successful submission, the application displays a confirmation message containing the generated issue reference number.

### Step 4: View Submitted Issues

Select **View Submitted Issues** to display the issues that have been submitted during the current application session.

The search function can be used to find specific issues.

### Step 5: Local Events and Announcements

1. From the main menu select **Local Events & Announcements**.
2. Browse the upcoming events. Click an event to see its details.
3. To search, type a keyword, choose a category and/or tick a date and choose it, then click **Search** (or press Enter). Click **Clear** to reset the filters.
4. Look at **Recommended For You** - the more you search and click, the more relevant the suggestions become. Select a recommendation to see why it was suggested.
5. Check **Priority Announcements** for the most urgent notices.
6. Double-click an entry in **Recent Searches** to repeat that search.
7. Click **Next Upcoming Event** to step through the events in the queue.
8. Click **Back to Main Menu** to return.

### Step 6: Service Request Status

1. From the main menu select **Service Request Status**.
2. **Track a request:** type a request ID (for example `SR-1004`, or just `1004`) or the reference number of an issue you reported, then click **Track** or press Enter. The request is found with the AVL tree and selected in the list.
3. **Browse by department:** click a branch of the department tree on the left (for example *Roads & Transport*) to see its requests.
4. **Filter:** choose a status, a priority and/or tick a From / To date, then click **Apply**. Click **Reset** to clear the filters.
5. **Read the progress:** select a request to see its details, the four-step progress tracker, its status history and how many other open requests are in nearby areas.
6. **Update a status (demo):** click **Move to: ...** to move the selected request to its next stage. The history, the dashboard cards and the other tabs update straight away.
7. **Priority Queue (Heap) tab:** see which request is next and click **Process next request** to move it forward.
8. **Service Network (Graph) tab:** choose a start area, then click one of the three buttons to see the nearby areas, a coverage route or the minimum spanning network drawn on the map.
9. **Data Structures tab:** choose a data structure and a traversal and click **Run** to see the result and read how that structure is used.
10. Click **Back to Main Menu** to return.

---

## 8. Validation

The application validates important fields before an issue can be submitted.

The following information is required:

- Location
- Category
- Priority
- Description

If required information is missing, the application displays a warning message and asks the user to complete the missing information.

---

## 9. User Interface Design

The application follows a consistent user interface design.

The design focuses on:

- Clear labels
- Easy-to-understand buttons
- Consistent colours and layouts (a shared theme in `UI/Theme.cs`)
- A header banner on every page with the South African flag colours
- Large card buttons on the main menu
- Colour-coded status and priority, a drawn progress tracker and a drawn network map
- User feedback messages
- Simple navigation
- A progress indicator to encourage users to complete their reports

---

## 10. Current Scope

The current implementation covers all three parts of the Municipal Services Application: Part 1 (Report Issues), Part 2 (Local Events and Announcements) and Part 3 (Service Request Status).

The following features are currently implemented:

- Main Menu
- Report Issues
- Issue validation
- Issue categories
- Issue priorities
- File attachments
- Issue submission
- Reference number generation
- Issue storage using a List
- Issue searching
- Viewing submitted issues
- Progress and engagement feedback
- Local Events and Announcements page (Part 2)
- Event search by keyword, category and date
- Stack, queue, priority queue, dictionaries and sets
- Search-based event recommendations
- Service Request Status page (Part 3)
- General tree, binary tree, binary search tree, AVL tree and red-black tree
- Heap (priority queue)
- Graph, breadth-first search, depth-first search and minimum spanning tree
- Header banner and shared theme on every form

---

## 11. Important Note

Issues are currently stored in memory using a List data structure. Service requests are sample data created when the application starts, plus one for every issue reported on the Report Issues page. Events are sample data created when the application starts (their dates are always set relative to today so they remain upcoming). Search history and recommendation data are also kept in memory only. This means that submitted issues are available while the application is running, but they are not permanently saved after the application is closed.
