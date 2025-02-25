using System.ComponentModel.DataAnnotations;

namespace AutoStore.DTOs;

public record class CreateItem(
     [Required] [StringLength(50)]string name,
     int partTypeId,
     [Required] [Range(1,1000)]decimal price,

     DateTime date 
);
