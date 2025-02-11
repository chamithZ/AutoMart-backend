using System;
using AutoStore.DTOs;
using AutoStore.Entities;

namespace AutoStore.Mappings;

public static class OrderMapping
{

public static Order ToEntity(this CreateOrderDTO order)
{
    return new Order
    {
        partId = order.itemId,
        quantity = order.quantity,
        totalPrice = order.totalPrice,
        date = order.date   
    };
}

public static OrderDetailsDTO ToDTO(this Order order)
{
        return new OrderDetailsDTO
        {
        id = order.orderId,
        itemId = order.partId,
        quantity = order.quantity,
        totalPrice = order.totalPrice,
        date = order.date
    };
}



}
