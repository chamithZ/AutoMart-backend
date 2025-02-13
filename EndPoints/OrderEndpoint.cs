using System;
using AutoStore.Data;
using AutoStore.DTOs;
using AutoStore.Entities;
using AutoStore.Mappings;
using Microsoft.EntityFrameworkCore;

namespace AutoStore.EndPoints;

public static class OrderEndpoint
{
const String getOrder="GetOrder";
public static WebApplication MapOrderEndpoints(this WebApplication app)
{
      app.MapPost("orders", async (CreateOrderDTO newOrder, AutoStoreContext dbContext) =>
{
    // Validate the input
    if (newOrder == null)
    {
        return Results.BadRequest("Order data is required.");
    }

    // Check if the Part exists
    var part = await dbContext.Parts.FindAsync(newOrder.partId);
    if (part == null)
    {
        return Results.BadRequest($"Part with ID {newOrder.partId} not found.");
    }

    // Map the DTO to an Order entity
    var order = newOrder.ToEntity();
    order.Part = part; // Assign the fetched Part

    // Add the order to the database
    dbContext.Orders.Add(order);
    try
    {
        await dbContext.SaveChangesAsync();
    }
    catch (DbUpdateException ex)
    {
        // Log the exception and return a 500 error
        return Results.Problem("An error occurred while saving the order. Please try again later.");
    }

    // Return the created order with a 201 status code
    return Results.CreatedAtRoute(getOrder, new { id = order.orderId }, order.ToDTO());
});

    app.MapGet("orders/{id}",async(int id, AutoStoreContext dbContext)=>{
        Order? order= await dbContext.Orders.FindAsync(id);
        OrderDetailsDTO orderDetailsDTO= order.ToDTO();
        return order is null? Results.NotFound() : Results.Ok(orderDetailsDTO);

    }).WithName(getOrder);

app.MapPut("orders/{id}",async( int id,UpdateOrderDTO updateOrderDTO, AutoStoreContext dbContext)=>{
    var existingOrder= await dbContext.Orders.FindAsync(id);
    if(existingOrder is null)
    {
        return Results.NotFound();
    }
    dbContext.Entry(existingOrder)
    .CurrentValues
    .SetValues(updateOrderDTO.ToEntity(id));

    await dbContext.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("orders/{id}",async(int id, AutoStoreContext dbContext)=>
{
 await dbContext.Orders.Where(order =>order.orderId==id)
 .ExecuteDeleteAsync();
 return Results.NoContent();
});
    return app ;
}






}
