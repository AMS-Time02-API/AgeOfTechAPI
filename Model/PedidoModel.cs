using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class PedidoModel
    {
         public string Id { get; set; } = Guid.NewGuid().ToString();
         
         [Column(TypeName = "decimal(18,2)")]
         public  decimal ValorTotal {get; set;} 
         public DateTime data { get; set; }
         public string idStatus { get; set; }
    }
}