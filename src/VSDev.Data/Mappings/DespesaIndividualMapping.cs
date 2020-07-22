using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSDev.Business.Models;

namespace VSDev.Data.Mappings
{
    public class DespesaIndividualMapping : IEntityTypeConfiguration<DespesaIndividual>
    {
        public void Configure(EntityTypeBuilder<DespesaIndividual> builder)
        {
            builder.SetMainEntityConfiguration("DESPESA_INDIVIDUAL");
            builder.HasOne(p => p.Morador).WithMany(p => p.DespesasIndividuais).HasForeignKey(p => p.MoradorId);

            builder.Property(p => p.MoradorId)
                .HasColumnName("ID_MORADOR")
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasColumnName("DSC_DESPESA")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.Valor)
                .HasColumnName("VLR_DESPESA")
                .HasColumnType("DECIMAL(9, 2)")
                .IsRequired();

            builder.Property(p => p.DataVencimento)
                .HasColumnName("DAT_VENCIMENTO")
                .IsRequired();

            builder.Property(p => p.DataPagamento)
                .HasColumnName("DAT_PAGAMENTO");

            builder.Property(p => p.Mes)
                .HasColumnName("NUM_MES")
                .IsRequired();

            builder.Property(p => p.Ano)
                .HasColumnName("NUM_ANO")
                .IsRequired();
        }
    }
}
