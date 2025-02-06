using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AutoStore.Data;

public static class DataExtension
{
  public static async Task MigrateDbAsync(this WebApplication app) 
  {
    using var scope =app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<AutoStoreContext>();
    await dbContext.Database.MigrateAsync();
  }

}
