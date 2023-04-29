using BLL.Services;
using DLL.Entities;
using DLL.Interfaces;
using DLL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IGenericRepository<User>, UserRepository>();
builder.Services.AddScoped<UserService>();

builder.Services.AddSwaggerGen();

var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

var appConfiguration = configuration.Build();
var a = appConfiguration.GetSection("ConnectionStrings:DefaultConnection").Value;
builder.Services.AddDbContext<HarryPotterContext>(options => options.UseSqlServer(a));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();