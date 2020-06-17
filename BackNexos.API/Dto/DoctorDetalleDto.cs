using System.Collections.Generic;
using BackNexos.API.Models;

namespace BackNexos.API.Dto
{
    public class DoctorDetalleDto
    {
        public int IdDoctor { get; set; }
        public string NombreCompleto { get; set; }
        public string Especialidad { get; set; }
        public int NumeroCredencial { get; set; }
        public string HospitalTrabaja { get; set; }
        public ICollection<Paciente> PacientesAtiende { get; set; }
    }
}