namespace AutoStore.DTOs;

public record class CreateItem(
     string name,
     decimal price,
     DateTime date 
);
