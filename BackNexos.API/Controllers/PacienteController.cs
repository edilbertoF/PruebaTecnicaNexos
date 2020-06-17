using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BackNexos.API.Data;
using BackNexos.API.Dto;
using BackNexos.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackNexos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IControlInformacion _controlInfo;
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public PacienteController(IControlInformacion controlInfo, DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            _controlInfo = controlInfo;
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarPaciente([FromBody] Paciente paciente)
        {

            if (await _controlInfo.PacienteExists(paciente.NumSeguroSocial))
                return BadRequest("Ya existe un paciente con ese numero de seguro social.");

            var pacienteReturn = await _controlInfo.RegistrarPaciente(paciente);
            return Ok(pacienteReturn);
            
        }

        [AllowAnonymous]
        [HttpGet("getPacientes")]
        public async Task<IActionResult> GetPacientes()
        {
            var paciente = await _context.Pacientes.ToListAsync();

            return Ok(paciente);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaciente(int id)
        {
             var result = await _controlInfo.GetPaciente(id);

            return Ok(result); 

        }

        [HttpPut("ActualizarPaciente/{id:int}")]
        public async Task<IActionResult> ActualizarPaciente(int id, [FromBody] PacienteParaActualizarDto pacienteParaActualizarDto)
        {
            var pacienteActual = await _controlInfo.GetPaciente(id);
            _mapper.Map(pacienteParaActualizarDto, pacienteActual);
            _context.SaveChanges();
            return NoContent();

            throw new Exception($"Updating Paciente {id} failed on save");            
        }

        [HttpDelete("EliminarPaciente/{id:int}")]
        public async Task<IActionResult> EliminarPaciente(int id)
        {
            var pacienteActual = await _controlInfo.GetPaciente(id);
            _context.Pacientes.Remove(pacienteActual);

            _context.SaveChanges();
            return NoContent();

            throw new Exception($"Deleting Paciente {id} failed on delete"); 
        }
    }
}