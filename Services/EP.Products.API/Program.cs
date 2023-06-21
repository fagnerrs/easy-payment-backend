using EP.Products.Domain.Services;
using EP.Products.Domain.Services.Interfaces;
using EP.Products.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ProductsContext>(opt => opt.UseInMemoryDatabase("user"));
builder.Services.AddScoped<IRifaService, RifaService>();
builder.Services.AddScoped<IProductUnitOfWork, ProductsUnitOfWork>();

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


app.Run();