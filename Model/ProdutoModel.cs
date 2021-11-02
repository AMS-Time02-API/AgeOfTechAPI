using System.ComponentModel.DataAnnotations.Schema;
using AgeOfTechAPI.Entities;

namespace AgeOfTechAPI.Model
{
    public class ProdutoModel : BaseEntity
    {
            public string IdCategoria { get; set; }
            
            //public Categoria Categoria { get; }

            [Column(TypeName = "decimal(18,2)")]
            public decimal Valor {get; set;}
    }
}