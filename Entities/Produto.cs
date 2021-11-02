using System.ComponentModel.DataAnnotations.Schema;

namespace AgeOfTechAPI.Entities
{
    public class Produto : BaseEntity
    {
        public string IdCategoria { get; set; }
        
        public Categoria Categoria { get; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor {get; set;} 
    }
}