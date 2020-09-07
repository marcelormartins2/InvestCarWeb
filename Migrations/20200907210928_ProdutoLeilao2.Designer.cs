﻿// <auto-generated />
using System;
using InvestCarWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InvestCarWeb.Migrations
{
    [DbContext(typeof(IdentyDbContext))]
    [Migration("20200907210928_ProdutoLeilao2")]
    partial class ProdutoLeilao2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("InvestCarWeb.Models.Despesa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<double>("Valor")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Despesa");
                });

            modelBuilder.Entity("InvestCarWeb.Models.Leilao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<double>("TaxaAvaliacao")
                        .HasColumnType("double");

                    b.Property<double>("TaxaVenda")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Leilao");
                });

            modelBuilder.Entity("InvestCarWeb.Models.LeilaoProduto", b =>
                {
                    b.Property<string>("ProdutoId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("LeilaoId")
                        .HasColumnType("int");

                    b.Property<int>("Lote")
                        .HasColumnType("int");

                    b.Property<int?>("ProdutoId1")
                        .HasColumnType("int");

                    b.Property<double>("VlAvalicao")
                        .HasColumnType("double");

                    b.Property<double>("VlCondicional")
                        .HasColumnType("double");

                    b.Property<double>("VlVenda")
                        .HasColumnType("double");

                    b.HasKey("ProdutoId", "LeilaoId");

                    b.HasIndex("LeilaoId");

                    b.HasIndex("ProdutoId1");

                    b.ToTable("LeilaoProduto");
                });

            modelBuilder.Entity("InvestCarWeb.Models.Leiloeiro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("LeilaoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Site")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<double>("TaxaAvaliacaoPadrao")
                        .HasColumnType("double");

                    b.Property<double>("TaxaVendaPadrao")
                        .HasColumnType("double");

                    b.Property<string>("Telefone")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("LeilaoId");

                    b.ToTable("Leiloeiro");
                });

            modelBuilder.Entity("InvestCarWeb.Models.Parceiro", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Celular")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Endereco")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("InvestCarWeb.Models.Participacao", b =>
                {
                    b.Property<string>("ParceiroId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("VeiculoId")
                        .HasColumnType("int");

                    b.Property<double>("PorcentagemCompra")
                        .HasColumnType("double");

                    b.Property<double>("PorcentagemLucro")
                        .HasColumnType("double");

                    b.HasKey("ParceiroId", "VeiculoId");

                    b.HasIndex("VeiculoId");

                    b.ToTable("Participacao");
                });

            modelBuilder.Entity("InvestCarWeb.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Anuncio")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Bairro")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Endereco")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Localizacao")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Telefone")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Vendedor")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<double>("VlAnunciado")
                        .HasColumnType("double");

                    b.Property<double>("VlPago")
                        .HasColumnType("double");

                    b.Property<double>("VlVendido")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("InvestCarWeb.Models.Responsavel", b =>
                {
                    b.Property<string>("ParceiroId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("DespesaId")
                        .HasColumnType("int");

                    b.Property<double>("Valor")
                        .HasColumnType("double");

                    b.HasKey("ParceiroId", "DespesaId");

                    b.HasIndex("DespesaId");

                    b.ToTable("Responsavel");
                });

            modelBuilder.Entity("InvestCarWeb.Models.Veiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AnoFab")
                        .HasColumnType("int");

                    b.Property<int>("AnoModelo")
                        .HasColumnType("int");

                    b.Property<string>("Chassis")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Cor")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("DespesaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DtCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Dut")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("Hodometro")
                        .HasColumnType("int");

                    b.Property<string>("Modelo_Fabricante")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("NumConsultas")
                        .HasColumnType("int");

                    b.Property<string>("Origem")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Placa")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("Renavam")
                        .HasColumnType("int");

                    b.Property<double?>("ValorFipe")
                        .HasColumnType("double");

                    b.Property<double?>("ValorPago")
                        .HasColumnType("double");

                    b.Property<double?>("ValorVenda")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("DespesaId");

                    b.ToTable("Veiculo");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(128) CHARACTER SET utf8mb4")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(128) CHARACTER SET utf8mb4")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(128) CHARACTER SET utf8mb4")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("varchar(128) CHARACTER SET utf8mb4")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("InvestCarWeb.Models.LeilaoProduto", b =>
                {
                    b.HasOne("InvestCarWeb.Models.Leilao", "Leilao")
                        .WithMany()
                        .HasForeignKey("LeilaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InvestCarWeb.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId1");
                });

            modelBuilder.Entity("InvestCarWeb.Models.Leiloeiro", b =>
                {
                    b.HasOne("InvestCarWeb.Models.Leilao", null)
                        .WithMany("Leiloeiro")
                        .HasForeignKey("LeilaoId");
                });

            modelBuilder.Entity("InvestCarWeb.Models.Participacao", b =>
                {
                    b.HasOne("InvestCarWeb.Models.Parceiro", "Parceiro")
                        .WithMany("Participacao")
                        .HasForeignKey("ParceiroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InvestCarWeb.Models.Veiculo", "Veiculo")
                        .WithMany("Participacao")
                        .HasForeignKey("VeiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InvestCarWeb.Models.Responsavel", b =>
                {
                    b.HasOne("InvestCarWeb.Models.Despesa", "Despesa")
                        .WithMany("Responsavel")
                        .HasForeignKey("DespesaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InvestCarWeb.Models.Parceiro", "Parceiro")
                        .WithMany("Responsavel")
                        .HasForeignKey("ParceiroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InvestCarWeb.Models.Veiculo", b =>
                {
                    b.HasOne("InvestCarWeb.Models.Despesa", "Despesa")
                        .WithMany("Veiculo")
                        .HasForeignKey("DespesaId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("InvestCarWeb.Models.Parceiro", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("InvestCarWeb.Models.Parceiro", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InvestCarWeb.Models.Parceiro", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("InvestCarWeb.Models.Parceiro", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}