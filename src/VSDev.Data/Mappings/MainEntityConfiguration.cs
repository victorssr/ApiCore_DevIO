using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSDev.Business.Models;

namespace VSDev.Data.Mappings
{
    public static class MainEntityConfiguration
    {
        public static EntityTypeBuilder<TEntity> SetMainEntityConfiguration<TEntity>(this EntityTypeBuilder<TEntity> builder, string tableName)
            where TEntity : MainEntity
        {
            builder.ToTable(tableName);
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("ID_" + tableName)
                .IsRequired();

            return builder;
        }
    }
}
