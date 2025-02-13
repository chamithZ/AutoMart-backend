using System;
using System.Data.Common;
using AutoStore.Data;
using AutoStore.DTOs;
using AutoStore.Entities;
using AutoStore.Mappings;
using Microsoft.EntityFrameworkCore;

namespace AutoStore.EndPoints;

public static class StoreEndpoints
{
    
const String getGame="GetPart";



public static WebApplication MapStoreEndpoints(this WebApplication app)
{
    //get part
app.MapGet("parts/{id}",async (int id, AutoStoreContext dbContext) =>{

 Part? part =await dbContext.Parts.FindAsync(id);

ItemDeatilsDTO itemDeatilsDTO= part.ToItemDetialsDTO();
 return part is null? Results.NotFound() : Results.Ok(itemDeatilsDTO);
 }).WithName(getGame);


app.MapGet("/",(AutoStoreContext dbContext)=>
        dbContext.Parts
        .Include(part =>part.PartType)
        .Select(part=>part.ToItemDetialsDTO())
        .AsNoTracking()
        .ToListAsync()
        );
     

//create parts
app.MapPost("parts",async (CreateItem newItem,AutoStoreContext dbContext )=>{

    Part item= newItem.ToEntity();
    item.PartType=dbContext.PartTypes.Find(newItem.partTypeId);

    dbContext.Parts.Add(item);
    await dbContext.SaveChangesAsync();

    return Results.CreatedAtRoute(getGame,new {id=item.Id},item.ToDto());
});


//update part
app.MapPut("parts/{id}",async (int id,UpdateItemDTO updateItem,AutoStoreContext dbContext)=>{
   // var index = parts.FindIndex(part=> part.id==id);
    var existingItem= await dbContext.Parts.FindAsync(id);
    if(existingItem is null)
    {
        return Results.NotFound();
    }
    
   dbContext.Entry(existingItem)
    .CurrentValues
    .SetValues(updateItem.ToEntity(id));

await dbContext.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("items/{id}", async(int id, AutoStoreContext dbContext) =>
{
    await dbContext.Parts.Where(part =>part.Id==id)
    .ExecuteDeleteAsync();
    return Results.NoContent(); // If the item is not found, return HTTP 404
});


return app;
}
}
