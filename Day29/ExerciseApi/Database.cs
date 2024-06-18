using Microsoft.EntityFrameworkCore;

public class Database : DbContext {
    public DbSet<Component> Components { get; set; }
    public DbSet<Item> Items { get; set; }
    public Database(DbContextOptions options) : base(options) {
        //
    }
    //hubungan category dengan product
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