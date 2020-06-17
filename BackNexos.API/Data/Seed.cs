using System.Collections.Generic;
using System.Linq;
using BackNexos.API.Models;

namespace BackNexos.API.Data
{
    public class Seed
    {
        public static void SeedData(DataContext context){
            if (!context.Pacientes.Any()){
                
                var paciente = new Paciente{
                     NombreCompleto = "edilberto florez",
                     NumSeguroSocial = 123,
                     CodigoPostal = "123",
                     telefono = "1234"
                };
                var doctor = new Doctor{
                     NombreCompleto = "edilberto florez doc",
                     Especialidad = "neuro cirujano",
                     NumeroCredencial = 1234,
                     HospitalTrabaja = "bosa"
                };              

                context.SaveChanges();
            }
        }
     
    }
}