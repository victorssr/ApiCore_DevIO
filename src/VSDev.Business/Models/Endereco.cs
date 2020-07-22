using System;

namespace VSDev.Business.Models
{
    public class Endereco : MainEntity
    {
        public Guid CasaId { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }

        // RELACIONAMENTOS
        public Casa Casa { get; set; }
    }
}
