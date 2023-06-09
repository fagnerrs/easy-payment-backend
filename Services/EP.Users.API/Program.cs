using EP.Shared.Domain.EntityFramework;
using EP.Shared.Infrastructure.EntityFramework;
using EP.User.Domain.Services;
using EP.User.Domain.Services.Interfaces;
using EP.User.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

builder.Services.AddDbContext<UserContext>(opt => opt.UseInMemoryDatabase("user"));
builder.Services.AddScoped<IOrganizerService, OrganizerService>();
builder.Services.AddScoped<IUserUnitOfWork, UserUnitOfWork>();

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