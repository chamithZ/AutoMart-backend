using System;
using Microsoft.EntityFrameworkCore;

namespace AutoStore.Entities;

public class Part
{
public int Id {get; set;}
public string? Name {get; set;}  // use  required in C# 11
public decimal price{get; set;}
public DateTime date{get; set;}
public int PartTypeId {get; set;}

public PartType? PartType {get; set;}
}
