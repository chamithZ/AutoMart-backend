using System.ComponentModel.DataAnnotations;

namespace AutoStore.DTOs;

public record class UpdateOrderDTO
(
     int orderId,
     int partId,  
     int quantity,
     decimal totalPrice ,
     DateTime date 
);