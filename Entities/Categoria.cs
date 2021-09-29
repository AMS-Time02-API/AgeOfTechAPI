using System.Collections.Generic;

namespace AgeOfTechAPI.Entities
{
    public class Categoria : BaseEntity
    {  
        public IEnumerable<Produto> Produtos { get; set; }
    }
}