using System;

namespace Model
{
    public class ClienteModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
    }
}