using System;

namespace AgeOfTechAPI.Entities
{
    public class Endereco
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; } 
        public string ClienteId { get; set; }
    }
}