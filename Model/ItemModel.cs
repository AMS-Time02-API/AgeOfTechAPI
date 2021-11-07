using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class ItemModel
    {
         public string Id { get; set; } = Guid.NewGuid().ToString();
        public string IdPedido { get; set; }
        public string IdProduto { get; set; }
        public int Quantidade { get; set; }
         
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorUnitario { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal SubTotal { get; set; }
    }
}