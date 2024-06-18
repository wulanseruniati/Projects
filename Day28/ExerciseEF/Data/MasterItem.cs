using Microsoft.EntityFrameworkCore;

public class MasterItem : DbContext {
    public DbSet<Item> Items {get; set;}
    public DbSet<Component> Components {get; set;}
    //mau disimpan dimana
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=./MasterItem.db");
    }
    //fluent API, set tanpa menggunakan attribute
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>(cat => {
            cat.HasKey(c => c.ItemId);
            cat.Property(c => c.ItemName).HasColumnType("TEXT");
            cat.Property(c => c.Description).HasColumnType("TEXT");
        });

        modelBuilder.Entity<Component>(cat => {
            cat.HasKey(c => c.ComponentID);
            cat.Property(c => c.ComponentDesc).HasColumnType("TEXT"); 
        });
    }
}