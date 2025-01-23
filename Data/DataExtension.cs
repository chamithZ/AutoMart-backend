using System;
using Microsoft.EntityFrameworkCore;

namespace AutoStore.Data;

public static class DataExtension
{
  public static void MigrateDb(this WebApplication app) 
  {
    using var scope =app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<AutoStoreContext>();
    dbContext.Database.Migrate();
  }

}
