using System;
using AutoStore.Data;
using AutoStore.DTOs;
using AutoStore.Entities;
using AutoStore.Mappings;

namespace AutoStore.EndPoints;

public static class StoreEndpoints
{
    
const String getGame="GetPart";

private static readonly List<ItemDTO> parts = new List<ItemDTO>
{
    new ItemDTO(
        1,
        "Brake pads",
        "brake",
        2000.00M,
        new DateTime(2024, 12, 02)
    ),
    new ItemDTO(
        2,
        "Ac cable",
        "brake",
        3000.00M,
        new DateTime(2024, 12, 02)
    ),
    new ItemDTO(
        3,
        "brake",
        "Brake cable",
        3500.00M,
        new DateTime(2024, 12, 02)
    )
};

public static WebApplication MapStoreEndpoints(this WebApplication app){
    //get part
    
app.MapGet("parts/{id}",(int id, AutoStoreContext dbContext) =>{

 Part? part =dbContext.Parts.Find(id);

ItemDeatilsDTO itemDeatilsDTO= part.ToItemDetialsDTO();
 return part is null? Results.NotFound() : Results.Ok(itemDeatilsDTO);
 }).WithName(getGame);

//get all parts
app.MapGet("items" ,()=> parts);


//create parts
app.MapPost("parts",(CreateItem newItem,AutoStoreContext dbContext )=>{

    Part item= newItem.ToEntity();
   // item.PartType=dbContext.PartTypes.Find(newItem.partTypeId);

    dbContext.Parts.Add(item);
    dbContext.SaveChanges();

    return Results.CreatedAtRoute(getGame,new {id=item.Id},item.ToDto());
});


//update part
app.MapPut("parts/{id}",(int id,UpdateItemDTO updateItem)=>{
    var index = parts.FindIndex(part=> part.id==id);

    if(index==-1)
    {
        return Results.NotFound();
    }
    
    parts[index]= new ItemDTO(
        id,
        updateItem.name,
        updateItem.partType.Name,
        updateItem.price,
        updateItem.date
    );

    return Results.NoContent();
});

app.MapDelete("items/{id}", (int id) =>
{
    var itemToRemove = parts.FirstOrDefault(item => item.id == id);
    if (itemToRemove != null)
    {
        parts.Remove(itemToRemove);
        return Results.NoContent(); // Correctly returns an HTTP 204 response
    }

    return Results.NotFound(); // If the item is not found, return HTTP 404
});

return app;
}
}
