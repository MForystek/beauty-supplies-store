using beauty_supplies_store.Data;
using beauty_supplies_store.Models;
using Microsoft.EntityFrameworkCore;
namespace beauty_supplies_store;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();
        builder.Services.AddDbContext<StoreContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("StoreContext")));

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<StoreContext>();
                var created = context.Database.EnsureCreated();
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occured creating the DB.");
            }
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseExceptionHandler("/Error");
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapGet("/products", (HttpContext httpContext, StoreContext storeContext) =>
        {
            var productsData = storeContext.Products?.AsEnumerable<Product>().ToArray();
            return productsData;
        })
        .WithName("GetProductsData");

        app.Run();
    }
}
