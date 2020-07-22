using System.Collections.Generic;

namespace VSDev.Business.Models
{
    public class Casa : MainEntity
    {
        public decimal ValorDespesas { get; set; }

        // RELACIONAMENTOS
        public IEnumerable<Morador> Moradores { get; set; }
        public Endereco Endereco { get; set; }
    }
}
