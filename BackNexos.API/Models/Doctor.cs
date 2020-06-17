using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackNexos.API.Models
{
    public class Doctor
    {
        [Key]
        public int IdDoctor { get; set; }
        public string NombreCompleto { get; set; }
        public string Especialidad { get; set; }
        public int NumeroCredencial { get; set; }
        public string HospitalTrabaja { get; set; }
        public virtual List<RelacionPacienteDoctor> RelacionPacienteDoctor { get; set; } = new List<RelacionPacienteDoctor>();

    }
}