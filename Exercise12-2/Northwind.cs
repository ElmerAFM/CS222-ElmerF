using Microsoft.EntityFrameworkCore;
using Exercise02.Models;

namespace Exercise02
{
  public class Northwind : DbContext
  {
    public DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite("Data Source=northwind.db");
    }
  }
}