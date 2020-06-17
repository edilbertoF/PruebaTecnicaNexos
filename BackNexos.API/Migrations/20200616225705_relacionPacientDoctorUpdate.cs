using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BackNexos.API.Migrations
{
    public partial class relacionPacientDoctorUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RelacionPacienteDoctor_Doctores_DoctorId",
                table: "RelacionPacienteDoctor");

            migrationBuilder.DropForeignKey(
                name: "FK_RelacionPacienteDoctor_Pacientes_PacienteId",
                table: "RelacionPacienteDoctor");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_RelacionPacienteDoctor_DoctorId_PacienteId",
                table: "RelacionPacienteDoctor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RelacionPacienteDoctor",
                table: "RelacionPacienteDoctor");

            migrationBuilder.RenameTable(
                name: "RelacionPacienteDoctor",
                newName: "relacionPacienteDoctor");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_relacionPacienteDoctor_DoctorId_PacienteId",
                table: "relacionPacienteDoctor",
                columns: new[] { "DoctorId", "PacienteId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_relacionPacienteDoctor",
                table: "relacionPacienteDoctor",
                columns: new[] { "PacienteId", "DoctorId" });

            migrationBuilder.AddForeignKey(
                name: "FK_relacionPacienteDoctor_Doctores_DoctorId",
                table: "relacionPacienteDoctor",
                column: "DoctorId",
                principalTable: "Doctores",
                principalColumn: "IdDoctor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_relacionPacienteDoctor_Pacientes_PacienteId",
                table: "relacionPacienteDoctor",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "IdPaciente",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_relacionPacienteDoctor_Doctores_DoctorId",
                table: "relacionPacienteDoctor");

            migrationBuilder.DropForeignKey(
                name: "FK_relacionPacienteDoctor_Pacientes_PacienteId",
                table: "relacionPacienteDoctor");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_relacionPacienteDoctor_DoctorId_PacienteId",
                table: "relacionPacienteDoctor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_relacionPacienteDoctor",
                table: "relacionPacienteDoctor");

            migrationBuilder.RenameTable(
                name: "relacionPacienteDoctor",
                newName: "RelacionPacienteDoctor");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_RelacionPacienteDoctor_DoctorId_PacienteId",
                table: "RelacionPacienteDoctor",
                columns: new[] { "DoctorId", "PacienteId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_RelacionPacienteDoctor",
                table: "RelacionPacienteDoctor",
                columns: new[] { "PacienteId", "DoctorId" });

            migrationBuilder.AddForeignKey(
                name: "FK_RelacionPacienteDoctor_Doctores_DoctorId",
                table: "RelacionPacienteDoctor",
                column: "DoctorId",
                principalTable: "Doctores",
                principalColumn: "IdDoctor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RelacionPacienteDoctor_Pacientes_PacienteId",
                table: "RelacionPacienteDoctor",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "IdPaciente",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
