using Microsoft.EntityFrameworkCore;

public class Database : DbContext {
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public Database(DbContextOptions options) : base(options) {
        //
    }
    //hubungan category dengan product
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //data seeding
        modelBuilder.Entity<Category>().HasData(
            new Category() {
                CategoryId =1,
                CategoryName = "Fruits",
                Description = "Cherries, Apples"
            },
            new Category() {
                CategoryId =2,
                CategoryName = "Dairy",
                Description = "Milk, Yoghurt"
            }
        );
    }
    //defines two primary keys on order detail
}