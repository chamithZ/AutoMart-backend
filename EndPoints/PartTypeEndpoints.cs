using System;
using AutoStore.Data;
using AutoStore.Entities;
using AutoStore.Mappings;
using Microsoft.EntityFrameworkCore;

namespace AutoStore.EndPoints;

public static class PartTypeEndpoints
{

public static RouteGroupBuilder MapsPartTypeEndpoints(this WebApplication app)
{

var group =app.MapGroup("partType");

group.MapGet("/",async (AutoStoreContext dbContext)=>
    await dbContext.PartTypes
    .Select(PartType=>PartType.ToDTO())
    .AsNoTracking()
    .ToListAsync()
);
return group;
}
}
