using System;
using System.ComponentModel.DataAnnotations;

namespace AutoStore.DTOs;

public record class CreateOrderDTO
{
    [Required]
    public int partId { get; set; } // Add { get; set; }

    [Required]
    public int quantity { get; set; } // Add { get; set; }

    [Required]
    public decimal totalPrice { get; set; } // Add { get; set; }

    [Required]
    public DateTime date { get; set; } // Add { get; set; }
}