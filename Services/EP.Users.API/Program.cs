using EP.Shared.Infrastructure.EntityFramework;
using EP.Users.Domain.Services;
using EP.Users.Domain.Services.Interfaces;
using EP.Users.Infrastructure;
using EP.Users.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

builder.Services.AddDbContext<UserContext>(opt => opt.UseMySQL("server=127.0.0.1;database=ep-users;user=root;password=test1234"));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserUnitOfWork, UserUnitOfWork>();
builder.Services.AddTransient<DbInitializer<UserContext>>();

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
var databaseInitializer = services.GetRequiredService<DbInitializer<UserContext>>();
databaseInitializer.Run();

app.Run();