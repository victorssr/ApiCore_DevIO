using Microsoft.EntityFrameworkCore;
using System.Linq;
using VSDev.Business.Models;

namespace VSDev.Data.Context
{
    public class ContextBase : DbContext
    {
        public ContextBase(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Casa> Casas { get; set; }
        public DbSet<DespesaIndividual> DespesasIndividuais { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Morador> Moradores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContextBase).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
