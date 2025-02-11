using System;
using System.ComponentModel.DataAnnotations;

namespace AutoStore.DTOs;

public class CreateOrderDTO
{
[Required] public int itemId ;
 [Required] public int quantity ;

 [Required] public  decimal totalPrice ;

 [Required] public DateTime date ;

}
