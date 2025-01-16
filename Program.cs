using AutoStore.DTOs;
using Microsoft.AspNetCore.Http.Features;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const String getGame="GetPart";

app.MapGet("/", () => "Hello World!");


List<ItemDTO> parts = new List<ItemDTO>
{
    new ItemDTO(
        1,
        "Brake pads",
        2000.00M,
        new DateTime(2024, 12, 02)
    ),
    new ItemDTO(
        2,
        "Ac cable",
        3000.00M,
        new DateTime(2024, 12, 02)
    ),
    new ItemDTO(
        3,
        "Brake cable",
        3500.00M,
        new DateTime(2024, 12, 02)
    )
};

//get part
app.MapGet("parts/{id}",(int id) =>{

 ItemDTO? part =parts.Find(part=>part.id==id);

 return part is null? Results.NotFound() : Results.Ok(part);
 }).WithName(getGame);

//get all parts
app.MapGet("items" ,()=> parts);

//create parts
app.MapPost("parts",(CreateItem newItem)=>{
    ItemDTO item=new (
        parts.Count+1,
         newItem.name,
         newItem.price,
        newItem.date
    );
    parts.Add(item);
    return Results.CreatedAtRoute(getGame,new {id=item.id},item);
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

app.Run();
