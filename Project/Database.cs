using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

public class Database
{
  private const string ConnectionString = "Data Source=tasks.db";

  public static void Initialize()
  {
    using var conn = new SqliteConnection(ConnectionString);
    conn.Open();

    var cmd = conn.CreateCommand();
    cmd.CommandText = @"
        CREATE TABLE IF NOT EXISTS Tasks (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Description TEXT NOT NULL,
            IsComplete INTEGER NOT NULL,
            CreatedAt TEXT NOT NULL
        );";
    cmd.ExecuteNonQuery();
  }

  public static void AddTask(string description)
  {
    using var conn = new SqliteConnection(ConnectionString);
    conn.Open();

    var cmd = conn.CreateCommand();
    cmd.CommandText = "INSERT INTO Tasks (Description, IsComplete, CreatedAt) VALUES ($desc, 0, $created)";
    cmd.Parameters.AddWithValue("$desc", description);
    cmd.Parameters.AddWithValue("$created", DateTime.Now.ToString("s"));
    cmd.ExecuteNonQuery();
  }

  public static List<TaskItem> GetAllTasks()
  {
    var tasks = new List<TaskItem>();
    using var conn = new SqliteConnection(ConnectionString);
    conn.Open();

    var cmd = conn.CreateCommand();
    cmd.CommandText = "SELECT Id, Description, IsComplete, CreatedAt FROM Tasks";

    using var reader = cmd.ExecuteReader();
    while (reader.Read())
    {
      tasks.Add(new TaskItem
      {
        Id = reader.GetInt32(0),
        Description = reader.GetString(1),
        IsComplete = reader.GetInt32(2) == 1,
        CreatedAt = DateTime.Parse(reader.GetString(3))
      });
    }
    return tasks;
  }

  public static void MarkTaskComplete(int id)
  {
    using var conn = new SqliteConnection(ConnectionString);
    conn.Open();

    var cmd = conn.CreateCommand();
    cmd.CommandText = "UPDATE Tasks SET IsComplete = 1 WHERE Id = $id";
    cmd.Parameters.AddWithValue("$id", id);
    cmd.ExecuteNonQuery();
  }

  public static void DeleteTask(int id)
  {
    using var conn = new SqliteConnection(ConnectionString);
    conn.Open();

    var cmd = conn.CreateCommand();
    cmd.CommandText = "DELETE FROM Tasks WHERE Id = $id";
    cmd.Parameters.AddWithValue("$id", id);
    cmd.ExecuteNonQuery();
  }
}
