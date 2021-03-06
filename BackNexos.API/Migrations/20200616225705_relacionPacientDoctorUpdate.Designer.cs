﻿// <auto-generated />
using BackNexos.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace BackNexos.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200616225705_relacionPacientDoctorUpdate")]
    partial class relacionPacientDoctorUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BackNexos.API.Models.Doctor", b =>
                {
                    b.Property<int>("IdDoctor")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Especialidad");

                    b.Property<string>("HospitalTrabaja");

                    b.Property<string>("NombreCompleto");

                    b.Property<int>("NumeroCredencial");

                    b.HasKey("IdDoctor");

                    b.ToTable("Doctores");
                });

            modelBuilder.Entity("BackNexos.API.Models.Paciente", b =>
                {
                    b.Property<int>("IdPaciente")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CodigoPostal");

                    b.Property<string>("NombreCompleto");

                    b.Property<int>("NumSeguroSocial");

                    b.Property<string>("telefono");

                    b.HasKey("IdPaciente");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("BackNexos.API.Models.RelacionPacienteDoctor", b =>
                {
                    b.Property<int>("PacienteId");

                    b.Property<int>("DoctorId");

                    b.HasKey("PacienteId", "DoctorId");

                    b.HasAlternateKey("DoctorId", "PacienteId");

                    b.ToTable("relacionPacienteDoctor");
                });

            modelBuilder.Entity("BackNexos.API.Models.RelacionPacienteDoctor", b =>
                {
                    b.HasOne("BackNexos.API.Models.Doctor", "Doctor")
                        .WithMany("RelacionPacienteDoctor")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BackNexos.API.Models.Paciente", "Paciente")
                        .WithMany("RelacionPacienteDoctor")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
