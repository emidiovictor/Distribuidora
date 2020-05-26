﻿// <auto-generated />
using System;
using InfraData.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace InfraData.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20181214205414_testao")]
    partial class testao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Domain.Entities.Armazem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("IdRegiao")
                        .HasColumnName("id_regiao");

                    b.Property<string>("Nome")
                        .HasColumnName("nome")
                        .HasColumnType("varchar")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("IdRegiao");

                    b.ToTable("armazens");
                });

            modelBuilder.Entity("Domain.Entities.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnName("bairro")
                        .HasColumnType("varchar")
                        .HasMaxLength(100);

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnName("cep")
                        .HasColumnType("varchar")
                        .HasMaxLength(14);

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnName("cidade")
                        .HasColumnType("varchar")
                        .HasMaxLength(100);

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnName("complemento")
                        .HasColumnType("varchar")
                        .HasMaxLength(100);

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnName("estado")
                        .HasColumnType("varchar")
                        .HasMaxLength(100);

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnName("numero")
                        .HasColumnType("varchar")
                        .HasMaxLength(20);

                    b.Property<string>("Referencia")
                        .IsRequired()
                        .HasColumnName("referencia")
                        .HasColumnType("varchar")
                        .HasMaxLength(100);

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnName("rua")
                        .HasColumnType("varchar")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("enderecos");
                });

            modelBuilder.Entity("Domain.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IdNota")
                        .HasColumnName("id_nota");

                    b.Property<int>("IdProduto")
                        .HasColumnName("id_produto");

                    b.Property<long>("Quantidade")
                        .HasColumnName("quantidade")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("IdNota");

                    b.HasIndex("IdProduto");

                    b.ToTable("item_nota");
                });

            modelBuilder.Entity("Domain.Entities.Nota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataOperacao")
                        .HasColumnName("data_operacao");

                    b.Property<int>("IdParticipante")
                        .HasColumnName("id_particiapnte");

                    b.Property<int>("IdUsuario")
                        .HasColumnName("id_usuario");

                    b.Property<int>("TipoNota")
                        .HasColumnName("tipo_nota")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IdParticipante");

                    b.HasIndex("IdUsuario");

                    b.ToTable("notas");
                });

            modelBuilder.Entity("Domain.Entities.Participante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("IdEndereco")
                        .HasColumnName("id_endereco");

                    b.Property<int>("IdRegiao")
                        .HasColumnName("id_regiao");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("nome")
                        .HasColumnType("varchar")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("IdEndereco");

                    b.HasIndex("IdRegiao");

                    b.ToTable("participantes");
                });

            modelBuilder.Entity("Domain.Entities.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Custo")
                        .HasColumnName("custo");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnName("descricao")
                        .HasColumnType("varchar")
                        .HasMaxLength(200);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("nome")
                        .HasColumnType("varchar")
                        .HasMaxLength(200);

                    b.Property<decimal>("PrecoVenda")
                        .HasColumnName("preco_venda");

                    b.HasKey("Id");

                    b.ToTable("produtos");
                });

            modelBuilder.Entity("Domain.Entities.ProdutoArmazem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IdArmazem")
                        .HasColumnName("id_armazem");

                    b.Property<int>("IdProduto")
                        .HasColumnName("id_produto");

                    b.Property<int>("Quantidade")
                        .HasColumnName("quantidade")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IdArmazem");

                    b.HasIndex("IdProduto");

                    b.ToTable("produto_armazem");
                });

            modelBuilder.Entity("Domain.Entities.Regiao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<decimal>("CoordenadaX")
                        .HasColumnName("coordenada_x");

                    b.Property<decimal>("CoordenadaY")
                        .HasColumnName("coordenada_y");

                    b.Property<string>("Nome")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("regioes");
                });

            modelBuilder.Entity("Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnName("nome")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("nome")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnName("senha")
                        .HasColumnType("varchar")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("usuarios");
                });

            modelBuilder.Entity("Domain.Entities.Armazem", b =>
                {
                    b.HasOne("Domain.Entities.Regiao", "Regiao")
                        .WithMany("Armazens")
                        .HasForeignKey("IdRegiao")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.Item", b =>
                {
                    b.HasOne("Domain.Entities.Nota", "Nota")
                        .WithMany("ListaItem")
                        .HasForeignKey("IdNota")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.Produto", "Produto")
                        .WithMany("Items")
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.Nota", b =>
                {
                    b.HasOne("Domain.Entities.Participante", "Participante")
                        .WithMany("Nota")
                        .HasForeignKey("IdParticipante")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.Usuario", "Usuario")
                        .WithMany("Notas")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.Participante", b =>
                {
                    b.HasOne("Domain.Entities.Endereco", "Endereco")
                        .WithMany("Participante")
                        .HasForeignKey("IdEndereco")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.Regiao", "Regiao")
                        .WithMany("Participantes")
                        .HasForeignKey("IdRegiao")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.ProdutoArmazem", b =>
                {
                    b.HasOne("Domain.Entities.Armazem", "Armazem")
                        .WithMany("ProdutoArmazem")
                        .HasForeignKey("IdArmazem")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.Produto", "Produto")
                        .WithMany("ProdutosArmazens")
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}