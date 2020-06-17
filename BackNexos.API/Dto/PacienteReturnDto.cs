namespace BackNexos.API.Dto
{
    public class PacienteReturnDto
    {
        public int IdPaciente { get; set; }
        public string NombreCompleto { get; set; }
        public int NumSeguroSocial { get; set; }
        public string CodigoPostal { get; set; }
        public string telefono { get; set; }
        
    }
}