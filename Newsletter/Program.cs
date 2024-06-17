using Microsoft.EntityFrameworkCore;
using Newsletter.Data;
using Newsletter.Service.Interfaces;
using Newsletter.Service;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Configure connection string
var connectionString = builder.Configuration.GetConnectionString("NewsletterConnection");

// Register services
builder.Services.AddTransient<ISubscriptionService, SubscriptionService>();

// Configure DbContext
builder.Services.AddDbContext<NewsletterContext>(opts =>
    opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Add controllers
builder.Services.AddControllers();

// Configure Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // TODO: Achar um jeito de documentar o swagger sem gerar warnings

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Map controller endpoints
app.MapControllers();

app.Run();
