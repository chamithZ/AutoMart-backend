using System;

namespace AutoStore.DTOs;

public record class ItemDeatilsDTO
(
int id,string name,int partTypeId,decimal price,DateTime date 
);