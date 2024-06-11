using Microsoft.EntityFrameworkCore;

public class Northwind : DbContext {
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=./Northwind.db");
    }
}