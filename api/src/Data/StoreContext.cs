using Microsoft.EntityFrameworkCore;
namespace api.Data;

public class StoreContext : DbContext
{
    public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }
    public DbSet<Models.Product>? Products { get; set; }
}