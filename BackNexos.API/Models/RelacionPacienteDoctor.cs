using System.ComponentModel.DataAnnotations;

namespace BackNexos.API.Models
{
    public class RelacionPacienteDoctor
    {
        [Key]
        public int PacienteId { get; set; }        
        public virtual Paciente Paciente { get; set; }

        [Key]
        public int DoctorId { get; set; }        
        public virtual Doctor Doctor { get; set; }
    }
}