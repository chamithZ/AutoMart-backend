using AutoStore.Entities;

namespace AutoStore.DTOs;

public record class UpdateItemDTO(
     string name,
     int partTypeId,
     decimal price,
     DateTime date 
);
