using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackNexos.API.Models
{
    public class Paciente
    {
        [Key]
        public int IdPaciente { get; set; }
        public string NombreCompleto { get; set; }
        public int NumSeguroSocial { get; set; }
        public string CodigoPostal { get; set; }
        public string telefono { get; set; }
        public virtual List<RelacionPacienteDoctor> RelacionPacienteDoctor { get; set; } = new List<RelacionPacienteDoctor>();
    }
}