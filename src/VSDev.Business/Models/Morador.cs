using System;
using System.Collections.Generic;

namespace VSDev.Business.Models
{
    public class Morador : MainEntity
    {
        public Guid CasaId { get; set; }
        public string NomeCompleto { get; set; }
        public decimal? ReceitaMensal { get; set; }
        public decimal? Contribuicao { get; set; }

        // RELACIONAMENTOS
        public Casa Casa{ get; set; }
        public IEnumerable<DespesaIndividual> DespesasIndividuais { get; set; }
    }
}
