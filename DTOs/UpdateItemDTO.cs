using AutoStore.Entities;

namespace AutoStore.DTOs;

public record class UpdateItemDTO(
     string name,
     PartType partType,
     decimal price,
     DateTime date 
);
