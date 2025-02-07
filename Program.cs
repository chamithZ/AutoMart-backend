using AutoStore.Data;
using AutoStore.EndPoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Get the connection string from configuration
var connString = builder.Configuration.GetConnectionString("AutoStore");

// Register the DbContext
builder.Services.AddDbContext<AutoStoreContext>(options =>
    options.UseSqlite(connString));

// Build the app
var app = builder.Build();

// Map the endpoints
app.MapStoreEndpoints();
app.MapsPartTypeEndpoints();

await app.MigrateDbAsync();
// Run the app
app.Run();
