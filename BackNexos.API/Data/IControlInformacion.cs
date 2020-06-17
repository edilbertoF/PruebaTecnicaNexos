using System.Collections.Generic;
using System.Threading.Tasks;
using BackNexos.API.Dto;
using BackNexos.API.Models;

namespace BackNexos.API.Data
{
    public interface IControlInformacion
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveAll();         
        Task<IEnumerable<Paciente>> GetPacientes(int id);
        Task<bool> DoctorExists(int numCredencial);
        Task<Doctor> RegistrarDoctor(Doctor doctor);
        Task<Doctor> GetDoctor(int id);
        Task<bool> PacienteExists(int numSeguroSocial);
        Task<Paciente> RegistrarPaciente(Paciente paciente);
        Task<Paciente> GetPaciente(int id);
        void ActualizarPaciente(int id, PacienteParaActualizarDto pacienteParaActializarDto);
    }
}