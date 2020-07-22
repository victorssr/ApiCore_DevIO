using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSDev.Business.Models;

namespace VSDev.Data.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.SetMainEntityConfiguration("ENDERECO");
            builder.HasOne(p => p.Casa).WithOne(p => p.Endereco);

            builder.Property(p => p.CasaId)
                .HasColumnName("ID_CASA")
                .IsRequired();

            builder.Property(p => p.Logradouro)
                .HasColumnName("DSC_LOGRADOURO")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.Numero)
                .HasColumnName("NUM_ENDERECO")
                .IsRequired();

            builder.Property(p => p.Complemento)
                .HasColumnName("DSC_COMPLEMENTO")
                .HasMaxLength(10);

            builder.Property(p => p.Bairro)
                .HasColumnName("NOM_BAIRRO")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.Cidade)
                .HasColumnName("NOM_CIDADE")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.Estado)
                .HasColumnName("SGL_ESTADO")
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(p => p.Cep)
                .HasColumnName("COD_CEP")
                .HasMaxLength(10)
                .IsRequired();
        }
    }
}
