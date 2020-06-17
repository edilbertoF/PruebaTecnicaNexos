using System.Collections.Generic;
using BackNexos.API.Models;

namespace BackNexos.API.Dto
{
    public class PacienteDetalleDto
    {
        public int IdPaciente { get; set; }
        public string NombreCompleto { get; set; }
        public int NumSeguroSocial { get; set; }
        public string CodigoPostal { get; set; }
        public string telefono { get; set; }
        public ICollection<Doctor> DoctoresAtiende { get; set; }
    }
}