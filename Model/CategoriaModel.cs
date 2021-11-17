using System;
using AgeOfTechAPI.Entities;

namespace AgeOfTechAPI.Model
{
  //DTO - DATA TRANSPORT OBJECT
    public class CategoriaModel 
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Descricao { get; set; }
        public bool IsAtivo { get; set; } 
    }
}