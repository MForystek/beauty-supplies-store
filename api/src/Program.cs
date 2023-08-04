using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;
namespace api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();
        builder.Services.AddDbContext<StoreContext>(options =>
            options.UseNpgsql(GetConnectionStringFromEnvVariables()));

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
                //TODO The following line creates the db if it don't exist. Decide to leave it or delete it.
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

    private static string GetConnectionStringFromEnvVariables()
    {
        var postgresDb = "POSTGRES_DB";
        var postgresUser = "POSTGRES_USER";
        var postgresPassword = "POSTGRES_PASSWORD";
        Dictionary<string, string?> envs = new Dictionary<string, string?>() {
            {postgresDb, Environment.GetEnvironmentVariable(postgresDb)},
            {postgresUser, Environment.GetEnvironmentVariable(postgresUser)},
            {postgresPassword, Environment.GetEnvironmentVariable(postgresPassword)}
        };
        CheckIfEnvVariablesAreSet(envs);

        return $"Host=db;Database={envs[postgresDb]};Username={envs[postgresUser]};Password={envs[postgresPassword]}";
    }

    private static void CheckIfEnvVariablesAreSet(Dictionary<string, string?> envs)
    {
        foreach (var env in envs)
        {
            if (env.Value is null)
            {
                throw new ArgumentNullException($"Env variable {env.Key} is not set.");
            }
        }
    }
}
