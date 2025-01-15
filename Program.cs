using AutoStore.DTOs;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

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
app.MapGet("games/{id}",(int id) => parts.Find(part=>part.id==id));

app.MapGet("items" ,()=> parts);
app.Run();
