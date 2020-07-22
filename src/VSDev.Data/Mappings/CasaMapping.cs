using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSDev.Business.Models;

namespace VSDev.Data.Mappings
{
    public class CasaMapping : IEntityTypeConfiguration<Casa>
    {
        public void Configure(EntityTypeBuilder<Casa> builder)
        {
            builder.SetMainEntityConfiguration("CASA");

            builder.Property(p => p.ValorDespesas)
                .HasColumnName("VLR_TOTAL_DESPESA")
                .HasColumnType("DECIMAL(9, 2)")
                .IsRequired();
        }
    }
}
