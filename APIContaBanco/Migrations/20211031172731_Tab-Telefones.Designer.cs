// <auto-generated />
using System;
using APIContaBanco.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APIContaBanco.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211031172731_Tab-Telefones")]
    partial class TabTelefones
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("APIContaBanco.Models.Cliente", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FotoPath")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("NomePreferencia")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("APIContaBanco.Models.TelefoneContato", b =>
                {
                    b.Property<long?>("ClienteId")
                        .HasColumnType("bigint");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TipoTelefone")
                        .HasColumnType("int");

                    b.HasIndex("ClienteId");

                    b.ToTable("TelefonesContato");
                });

            modelBuilder.Entity("APIContaBanco.Models.TelefoneContato", b =>
                {
                    b.HasOne("APIContaBanco.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.Navigation("Cliente");
                });
#pragma warning restore 612, 618
        }
    }
}
