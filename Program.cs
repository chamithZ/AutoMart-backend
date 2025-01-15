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
app.MapGet("games/{id}",(int id) => parts.Find(part=>part.id==id)).WithName(getGame);

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


app.Run();
