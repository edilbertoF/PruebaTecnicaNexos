using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BackNexos.API.Migrations
{
    public partial class relacionPacientDoctor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RelacionPacienteDoctor",
                columns: table => new
                {
                    PacienteId = table.Column<int>(nullable: false),
                    DoctorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelacionPacienteDoctor", x => new { x.PacienteId, x.DoctorId });
                    table.UniqueConstraint("AK_RelacionPacienteDoctor_DoctorId_PacienteId", x => new { x.DoctorId, x.PacienteId });
                    table.ForeignKey(
                        name: "FK_RelacionPacienteDoctor_Doctores_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctores",
                        principalColumn: "IdDoctor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelacionPacienteDoctor_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "IdPaciente",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RelacionPacienteDoctor");
        }
    }
}
