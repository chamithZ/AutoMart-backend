namespace AutoStore.DTOs;

public record class UpdateItemDTO(
     string name,
     decimal price,
     DateTime date 
);
