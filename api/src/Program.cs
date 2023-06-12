namespace beauty_supplies_store;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        var products = new[] { "Cream", "Shampoo", "Foam" };

        app.MapGet("/products", (HttpContext httpContext) =>
        {
            var productsData = Enumerable.Range(1, 3).Select(index =>
                new Product
                {
                    Name = products[Random.Shared.Next(products.Length)],
                    Price = Random.Shared.Next(20, 70),
                    ExpiryDate = DateTime.Now.AddDays(index)
                })
                .ToArray();
            return productsData;
        })
        .WithName("GetProductsData");

        app.Run();
    }
}
