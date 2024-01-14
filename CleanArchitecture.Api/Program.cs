using CleanArchitecture.Api.Configurations;
using CleanArchitecture.Infra.Data.Context;
using CleanArchitecture.Infra.IoC;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var universityConnectionString = builder.Configuration.GetConnectionString("UniversityDbConnection") ?? throw new InvalidOperationException("Connection string 'UniversityDbConnection' not found.");

builder.Services.AddDbContext<UniversityDbContext>(options =>
{
    options.UseSqlServer(universityConnectionString);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.RegisterAutoMapper();
DependencyContainer.RegisterServices(builder.Services);


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
