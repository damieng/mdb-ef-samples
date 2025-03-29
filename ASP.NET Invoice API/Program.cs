using Microsoft.EntityFrameworkCore;
using MongoEFSample.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var dbConnectionString = builder.Configuration.GetConnectionString("MongoDbConnection") ?? "mongodb://localhost:27017";
builder.Services.AddDbContext<InvoicingDataContext>(o => o.UseMongoDB(dbConnectionString, "Invoicing"));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
