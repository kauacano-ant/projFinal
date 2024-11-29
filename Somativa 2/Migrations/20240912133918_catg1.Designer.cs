﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Somativa_2.Data;

#nullable disable

namespace Somativa_2.Migrations
{
    [DbContext(typeof(SprintContext))]
    [Migration("20240912133918_catg1")]
    partial class catg1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Somativa_2.Models.Categ", b =>
                {
                    b.Property<Guid>("CategId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategId");

                    b.ToTable("Categ", (string)null);
                });

            modelBuilder.Entity("Somativa_2.Models.ConsultasModel", b =>
                {
                    b.Property<Guid>("ConsultaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ConsultorioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataConsultas")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Hora")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PacienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PacientesPacienteId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ConsultaId");

                    b.HasIndex("ConsultorioId");

                    b.HasIndex("PacientesPacienteId");

                    b.ToTable("Consultas", (string)null);
                });

            modelBuilder.Entity("Somativa_2.Models.ConsultoriosModel", b =>
                {
                    b.Property<Guid>("ConsultorioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Especialidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ConsultorioId");

                    b.HasIndex("CategId");

                    b.ToTable("Consultorios", (string)null);
                });

            modelBuilder.Entity("Somativa_2.Models.FeedbackModel", b =>
                {
                    b.Property<Guid>("FeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ConsultaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Nota")
                        .HasColumnType("int");

                    b.HasKey("FeedbackId");

                    b.HasIndex("ConsultaId");

                    b.ToTable("feedback", (string)null);
                });

            modelBuilder.Entity("Somativa_2.Models.PacientesModel", b =>
                {
                    b.Property<Guid>("PacienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Data_de_nascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PlanodeSaudeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RG")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PacienteId");

                    b.HasIndex("PlanodeSaudeId");

                    b.ToTable("Pacientes", (string)null);
                });

            modelBuilder.Entity("Somativa_2.Models.PlanodeSaudeModel", b =>
                {
                    b.Property<Guid>("PlanodeSaudeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("img")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlanodeSaudeId");

                    b.ToTable("Planos_de_Saude", (string)null);
                });

            modelBuilder.Entity("Somativa_2.Models.ConsultasModel", b =>
                {
                    b.HasOne("Somativa_2.Models.ConsultoriosModel", "Consultorio")
                        .WithMany()
                        .HasForeignKey("ConsultorioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Somativa_2.Models.PacientesModel", "Pacientes")
                        .WithMany()
                        .HasForeignKey("PacientesPacienteId");

                    b.Navigation("Consultorio");

                    b.Navigation("Pacientes");
                });

            modelBuilder.Entity("Somativa_2.Models.ConsultoriosModel", b =>
                {
                    b.HasOne("Somativa_2.Models.Categ", "Categ")
                        .WithMany("Consultorios")
                        .HasForeignKey("CategId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categ");
                });

            modelBuilder.Entity("Somativa_2.Models.FeedbackModel", b =>
                {
                    b.HasOne("Somativa_2.Models.ConsultasModel", "Consulta")
                        .WithMany()
                        .HasForeignKey("ConsultaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Consulta");
                });

            modelBuilder.Entity("Somativa_2.Models.PacientesModel", b =>
                {
                    b.HasOne("Somativa_2.Models.PlanodeSaudeModel", "PlanodeSaude")
                        .WithMany()
                        .HasForeignKey("PlanodeSaudeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlanodeSaude");
                });

            modelBuilder.Entity("Somativa_2.Models.Categ", b =>
                {
                    b.Navigation("Consultorios");
                });
#pragma warning restore 612, 618
        }
    }
}
