﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VSDev.Data.Context;

namespace VSDev.Data.Migrations
{
    [DbContext(typeof(ContextBase))]
    partial class ContextBaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VSDev.Business.Models.Casa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_CASA")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("ValorDespesas")
                        .HasColumnName("VLR_TOTAL_DESPESA")
                        .HasColumnType("DECIMAL(9, 2)");

                    b.HasKey("Id");

                    b.ToTable("CASA");
                });

            modelBuilder.Entity("VSDev.Business.Models.DespesaIndividual", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_DESPESA_INDIVIDUAL")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Ano")
                        .HasColumnName("NUM_ANO")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataPagamento")
                        .HasColumnName("DAT_PAGAMENTO")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnName("DAT_VENCIMENTO")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnName("DSC_DESPESA")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<int>("Mes")
                        .HasColumnName("NUM_MES")
                        .HasColumnType("int");

                    b.Property<Guid>("MoradorId")
                        .HasColumnName("ID_MORADOR")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Valor")
                        .HasColumnName("VLR_DESPESA")
                        .HasColumnType("DECIMAL(9, 2)");

                    b.HasKey("Id");

                    b.HasIndex("MoradorId");

                    b.ToTable("DESPESA_INDIVIDUAL");
                });

            modelBuilder.Entity("VSDev.Business.Models.Endereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_ENDERECO")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnName("NOM_BAIRRO")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<Guid>("CasaId")
                        .HasColumnName("ID_CASA")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnName("COD_CEP")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnName("NOM_CIDADE")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Complemento")
                        .HasColumnName("DSC_COMPLEMENTO")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnName("SGL_ESTADO")
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnName("DSC_LOGRADOURO")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<int>("Numero")
                        .HasColumnName("NUM_ENDERECO")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CasaId")
                        .IsUnique();

                    b.ToTable("ENDERECO");
                });

            modelBuilder.Entity("VSDev.Business.Models.Morador", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_MORADOR")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CasaId")
                        .HasColumnName("ID_CASA")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("Contribuicao")
                        .HasColumnName("VLR_CONTRIBUICAO")
                        .HasColumnType("DECIMAL(9, 2)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnName("DAT_NASCIMENTO")
                        .HasColumnType("datetime2");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnName("DSC_DOCUMENTO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnName("NOM_FOTO")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasColumnName("NOM_MORADOR")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<decimal?>("ReceitaMensal")
                        .HasColumnName("VLR_RECEITA_MENSAL")
                        .HasColumnType("DECIMAL(9, 2)");

                    b.Property<int>("TipoDocumento")
                        .HasColumnName("COD_TIPO_DOCUMENTO")
                        .HasColumnType("int");

                    b.Property<int>("TipoMorador")
                        .HasColumnName("COD_TIPO_MORADOR")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CasaId");

                    b.ToTable("MORADOR");
                });

            modelBuilder.Entity("VSDev.Business.Models.DespesaIndividual", b =>
                {
                    b.HasOne("VSDev.Business.Models.Morador", "Morador")
                        .WithMany("DespesasIndividuais")
                        .HasForeignKey("MoradorId")
                        .IsRequired();
                });

            modelBuilder.Entity("VSDev.Business.Models.Endereco", b =>
                {
                    b.HasOne("VSDev.Business.Models.Casa", "Casa")
                        .WithOne("Endereco")
                        .HasForeignKey("VSDev.Business.Models.Endereco", "CasaId")
                        .IsRequired();
                });

            modelBuilder.Entity("VSDev.Business.Models.Morador", b =>
                {
                    b.HasOne("VSDev.Business.Models.Casa", "Casa")
                        .WithMany("Moradores")
                        .HasForeignKey("CasaId")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
