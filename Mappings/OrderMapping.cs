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
        partId = order.partId,
        quantity = order.quantity,
        totalPrice = order.totalPrice,
        date = order.date   
    };
}

public static OrderDetailsDTO ToDTO(this Order order)
{
        return new OrderDetailsDTO( order.orderId, order.partId, order.quantity, order.totalPrice, order.date);
}

public static Order ToEntity(this UpdateOrderDTO order,int id)
{
    return new Order
    {
        orderId = id,
        partId = order.partId,
        quantity = order.quantity,
        totalPrice = order.totalPrice,
        date = order.date
    };
}
}
