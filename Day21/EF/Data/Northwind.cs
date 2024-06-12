using Microsoft.EntityFrameworkCore;

public class Northwind : DbContext {
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=./Northwind.db");
    }
    //hubungan category dengan product
    /*protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //satu kategori banyak produk, satu produk satu category
        modelBuilder.Entity<Category>( cat => {
           cat.HasMany<Product>(c => c.Products).WithOne(p => p.Category).OnDelete(DeleteBehavior.Cascade); 
        });
    }*/
    //defines two primary keys on order detail
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderDetail>()
            .HasKey(od => new { od.OrderId, od.ProductID });
    }
}