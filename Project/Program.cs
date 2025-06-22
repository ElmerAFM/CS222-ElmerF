using System;

class Program
{
  static void Main()
  {
    Database.Initialize();

    while (true)
    {
      Console.WriteLine("\n1. Add Task\n2. View Tasks\n3. Complete Task\n4. Delete Task\n5. Exit");
      Console.Write("Choice: ");
      var input = Console.ReadLine();

      if (input == "1")
      {
        Console.Write("Enter task description: ");
        var desc = Console.ReadLine();
        Database.AddTask(desc);
      }
      else if (input == "2")
      {
        var tasks = Database.GetAllTasks();
        foreach (var task in tasks)
        {
          string status = task.IsComplete ? "✓" : " ";
          Console.WriteLine($"[{status}] {task.Id}: {task.Description} (Created {task.CreatedAt})");
        }
      }
      else if (input == "3")
      {
        Console.Write("Enter task ID to complete: ");
        if (int.TryParse(Console.ReadLine(), out int id))
          Database.MarkTaskComplete(id);
      }
      else if (input == "4")
      {
        Console.Write("Enter task ID to delete: ");
        if (int.TryParse(Console.ReadLine(), out int id))
          Database.DeleteTask(id);
      }
      else if (input == "5")
        break;
    }
  }
}
