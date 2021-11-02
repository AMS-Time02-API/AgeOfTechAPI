using System.ComponentModel.DataAnnotations.Schema;
using AgeOfTechAPI.Entities;

namespace Model
{
    public class ProdutoModel:BaseEntity
    {
        public string IdCategoria { get; set; }
        
          [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }
    }
}