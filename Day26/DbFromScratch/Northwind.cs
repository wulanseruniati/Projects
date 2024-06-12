using Microsoft.EntityFrameworkCore;

public class Northwind : DbContext {
    public DbSet<Category> Categories {get; set;}
    public DbSet<Product> Products {get; set;}
    //mau disimpan dimana
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Northwind.db");
    }
    //fluent API, set tanpa menggunakan attribute
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(cat => {
            cat.HasKey(c => c.CategoryId);
            cat.Property(c => c.Description).HasColumnType("TEXT");
            cat.HasMany<Product>(c => c.Products).WithOne(p => p.Category).OnDelete(DeleteBehavior.Cascade); 
        });

        modelBuilder.Entity<Product>(cat => {
            cat.HasKey(c => c.ProductID);
            cat.Property(c => c.ProductDesc).HasColumnType("TEXT"); 
            cat.Property(c => c.Price).IsRequired(false);
        });
    }
}