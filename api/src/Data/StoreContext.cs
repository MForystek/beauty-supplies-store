using Microsoft.EntityFrameworkCore;
namespace beauty_supplies_store.Data;

public class StoreContext : DbContext
{
    public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }
    public DbSet<Models.Product>? Products { get; set; }
}