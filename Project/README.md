# Task Manager with SQLite

## Purpose

This is a simple console-based C# application that allows users to manage their personal tasks. Each task includes a description, completion status, and creation date. Data is persisted using a local SQLite database (`tasks.db`), so tasks are saved between runs.

---

## Features

- Add new tasks
- View all tasks
- Mark tasks as complete
- Delete tasks
- Persistent storage using SQLite

---

## Sample Data Used

| ID  | Description       | Completed | Created At          |
| --- | ----------------- | --------- | ------------------- |
| 1   | Submit assignment | No        | 2025-06-21 10:15 AM |
| 2   | Buy groceries     | Yes       | 2025-06-20 06:30 PM |
| 3   | Finish C# project | No        | 2025-06-21 08:45 AM |

---

## Tested Scenarios

- Adding multiple tasks
- Completing non-existent task IDs
- Deleting tasks that have already been marked as complete
- Restarting the program with saved data

---

## How to Run

### Prerequisites

- [.NET 6 SDK or newer](https://dotnet.microsoft.com/en-us/download)
- Run this command to add the required SQLite library:

```bash
dotnet add package Microsoft.Data.Sqlite
```
