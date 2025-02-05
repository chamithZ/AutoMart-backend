using AutoStore.Entities;

namespace AutoStore.DTOs;

public record class ItemDTO( int id,string name,string partType,decimal price,DateTime date );

