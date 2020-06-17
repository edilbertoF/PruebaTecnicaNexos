using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackNexos.API.Dto;
using BackNexos.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BackNexos.API.Data
{
    public class ControlInformacion : IControlInformacion
    {
        public readonly DataContext _context;
        public ControlInformacion(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        
        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }        

        public Task<IEnumerable<Paciente>> GetPacientes(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> DoctorExists(int numCredencial)
        {
            if(await _context.Doctores.AnyAsync(x => x.NumeroCredencial == numCredencial))
                return true;
            
            return false;
        }

        public async Task<Doctor> RegistrarDoctor(Doctor doctor){
            await _context.Doctores.AddAsync(doctor);
            await _context.SaveChangesAsync();
            return doctor;
        }

        public async Task<Doctor> GetDoctor(int id)
        {
            var doctor = await _context.Doctores.FirstOrDefaultAsync(u => u.IdDoctor == id);
            return doctor;
        }

        public async Task<Paciente> RegistrarPaciente(Paciente paciente)
        {
            await _context.Pacientes.AddAsync(paciente);
            await _context.SaveChangesAsync();
            return paciente;
        }

        public async Task<Paciente> GetPaciente(int id)
        {
            var paciente = await _context.Pacientes.FirstOrDefaultAsync(u => u.IdPaciente == id);
            return paciente;
        }

        public async Task<bool> PacienteExists(int numSeguroSocial)
        {
            if(await _context.Pacientes.AnyAsync(x => x.NumSeguroSocial == numSeguroSocial))
                return true;
            
            return false;
        }

        public void ActualizarPaciente(int id, PacienteParaActualizarDto pacienteParaActializarDto)
        {
            throw new System.NotImplementedException();
        }
    }
}