namespace AgeOfTechAPI.Entities
{
    public class Produto : BaseEntity
    {
        public string IdCategoria { get; set; }
        public Categoria Categoria { get; }
    }
}