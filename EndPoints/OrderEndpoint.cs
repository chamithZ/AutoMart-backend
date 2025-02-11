using System;
using AutoStore.Data;
using AutoStore.DTOs;
using AutoStore.Entities;
using AutoStore.Mappings;

namespace AutoStore.EndPoints;

public static class OrderEndpoint
{
const String getOrder="GetOrder";
public static WebApplication MapStoreEndpoints(this WebApplication app)
{
    app.MapPost("order",async (CreateOrderDTO newOrder, AutoStoreContext dbContext)=>{
        Order order = newOrder.ToEntity();
        order.partId=dbContext.Parts.Find(newOrder.itemId).Id;

        dbContext.Orders.Add(order);
        await dbContext.SaveChangesAsync();

        return Results.CreatedAtRoute(getOrder, new {id=order.orderId},order);

    });

    app.MapGet("order/{id}",async(int id, AutoStoreContext dbContext)=>{
        Order? order= await dbContext.Orders.FindAsync(id);
        OrderDetailsDTO orderDetailsDTO= order.ToDTO();
        return order is null? Results.NotFound() : Results.Ok(orderDetailsDTO);

    });

    return app ;
}



}
