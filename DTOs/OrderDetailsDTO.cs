using System;

namespace AutoStore.DTOs;

public record class OrderDetailsDTO(
    int id,
    int itemId,
    int quantity,
    decimal totalPrice,
    DateTime date
);
