using System;
using AutoStore.DTOs;
using AutoStore.Entities;

namespace AutoStore.Mappings;

public static class PartTypeMapping
{
public static PartTypeDTO ToDTO(this PartType partType)
{
    return new PartTypeDTO(partType.Id,partType.Name);
} 



}
