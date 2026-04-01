using CORE.Interface;
using INFRASTRUCTURE.Datas;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<StoreContext>(options =>
{
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
//DB Connection

builder.Services.AddScoped<IProductRepository, ProductRepository>();
//One Interface And That Is Only Used By One Repository 

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
//One Interface And That Is Used By Multiple Repository

var app = builder.Build();

app.MapControllers();

try
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<StoreContext>();
    await context.Database.MigrateAsync();
    await StoreContextSeed.SeedAsync(context);
}
//DataBase Creation And Seeding Automatically When We Run The Application
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    throw;
}
//Stops If Any Error Occurs During The Database Creation And Seeding Process 
//And Displays The Error Message To The Console

app.Run();
//Megaruf Bilal
