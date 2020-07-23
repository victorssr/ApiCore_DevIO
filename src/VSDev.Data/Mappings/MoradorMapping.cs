using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSDev.Business.Models;

namespace VSDev.Data.Mappings
{
    public class MoradorMapping : IEntityTypeConfiguration<Morador>
    {
        public void Configure(EntityTypeBuilder<Morador> builder)
        {
            builder.SetMainEntityConfiguration("MORADOR");
            builder.HasOne(p => p.Casa).WithMany(p => p.Moradores).HasForeignKey(p => p.CasaId);

            builder.Property(p => p.CasaId)
                .HasColumnName("ID_CASA")
                .IsRequired();

            builder.Property(p => p.NomeCompleto)
                .HasColumnName("NOM_MORADOR")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.ReceitaMensal)
                .HasColumnName("VLR_RECEITA_MENSAL")
                .HasColumnType("DECIMAL(9, 2)");

            builder.Property(p => p.Contribuicao)
                .HasColumnName("VLR_CONTRIBUICAO")
                .HasColumnType("DECIMAL(9, 2)");

            builder.Property(p => p.Foto)
                .HasColumnName("NOM_FOTO")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.DataNascimento)
                .HasColumnName("DAT_NASCIMENTO")
                .IsRequired();

            builder.Property(p => p.TipoMorador)
                .HasColumnName("COD_TIPO_MORADOR")
                .IsRequired();
        }
    }
}
