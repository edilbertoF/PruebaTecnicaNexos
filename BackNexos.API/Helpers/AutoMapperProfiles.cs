using System.Linq;
using AutoMapper;
using BackNexos.API.Dto;
using BackNexos.API.Models;

namespace BackNexos.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<PacienteParaActualizarDto, Paciente>();
            CreateMap<DoctorParaActualizarDto, Doctor>();
            CreateMap<Paciente, PacienteDetalleDto>();            
        }
    }
}