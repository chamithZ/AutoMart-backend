using System;
using AutoStore.DTOs;
using AutoStore.Entities;

namespace AutoStore.Mappings;

public static class ItemMapping
{
    public static Part ToEntity(this CreateItem item) { 
       return new Part{
        Name=item.name,
        PartTypeId=item.partTypeId,
        price=item.price,
        date=item.date
    };
    }

  public static Part ToEntity(this UpdateItemDTO item,int id) { 
       return new Part{
        Id=id,
        Name=item.name,
        PartTypeId=item.partTypeId,
        price=item.price,
        date=item.date
    };
    }

    public static ItemDTO ToDto(this Part part)
    {
         return new(part.Id,part.Name ?? string.Empty,part.PartType!.Name,part.price,part.date);
    }
public static ItemDeatilsDTO ToItemDetialsDTO(this Part part)
{
    return new ItemDeatilsDTO(
        part.Id, 
        part.Name ?? string.Empty, 
        part.PartType!.Id ,  // Use default value if PartType is null
        part.price, 
        part.date
    );
}
}
