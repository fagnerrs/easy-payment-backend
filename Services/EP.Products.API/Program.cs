using EP.Products.Domain.Services;
using EP.Products.Domain.Services.Interfaces;
using EP.Products.Infrastructure.Database;
using EP.Shared.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ProductsContext>(opt => opt.UseMySQL("server=127.0.0.1;database=ep-products;user=root;password=test1234"));
builder.Services.AddScoped<IRifaService, RifaService>();
builder.Services.AddScoped<IProductUnitOfWork, ProductsUnitOfWork>();
builder.Services.AddTransient<DbInitializer<ProductsContext>>();

var app = builder.Build();

    app.UseSwagger();
    app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// prometheus
app.UseRouting();
app.UseHttpMetrics();
app.UseEndpoints(endpoints =>
{
    endpoints.MapMetrics();
});

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var databaseInitializer = services.GetRequiredService<DbInitializer<ProductsContext>>();
databaseInitializer.Run();


app.Run();