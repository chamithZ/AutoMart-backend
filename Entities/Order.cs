using System;

namespace AutoStore.Entities;

public class Order
{
public int orderId {get; set;}

public int quantity {get; set;}

public decimal totalPrice {get; set;}

public DateTime date {get; set;}

public int partId {get; set;}
public Part? Part {get; set;}

}
