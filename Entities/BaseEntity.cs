using System;

namespace AgeOfTechAPI.Entities
{
    public abstract class BaseEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Descricao { get; set; }
        public bool IsAtivo { get; set; } = true;
    }
}