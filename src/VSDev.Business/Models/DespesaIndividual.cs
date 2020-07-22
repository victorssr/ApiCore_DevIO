using System;

namespace VSDev.Business.Models
{
    public class DespesaIndividual : MainEntity
    {
        public Guid MoradorId { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }

        // RELACIONAMENTOS
        public Morador Morador { get; set; }
    }
}
