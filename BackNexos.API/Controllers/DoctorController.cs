using System;
using System.Threading.Tasks;
using AutoMapper;
using BackNexos.API.Data;
using BackNexos.API.Dto;
using BackNexos.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackNexos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IControlInformacion _controlInfo;
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public DoctorController(IControlInformacion controlInfo, DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            _controlInfo = controlInfo;

        }

        [HttpPost]
        public async Task<IActionResult> RegistrarDoctor([FromBody] Doctor doctor)
        {

            if (await _controlInfo.DoctorExists(doctor.NumeroCredencial))
                return BadRequest("Ya existe un doctor con ese numero de credencial.");

            var doctorReturn = await _controlInfo.RegistrarDoctor(doctor);
            return Ok(doctorReturn);
            
        }

        [AllowAnonymous]
        [HttpGet("getDoctores")]
        public async Task<IActionResult> GetDoctores()
        {
            var doctores = await _context.Doctores.ToListAsync();

            return Ok(doctores);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctor(int id)
        {
            var doctor = await _controlInfo.GetDoctor(id);

            return Ok(doctor);
        }

        [HttpPut("ActualizarDoctor/{id:int}")]
        public async Task<IActionResult> ActualizarPaciente(int id, [FromBody] DoctorParaActualizarDto doctorParaActualizarDto)
        {
            var doctorActual = await _controlInfo.GetDoctor(id);
            _mapper.Map(doctorParaActualizarDto, doctorActual);
            _context.SaveChanges();
            return NoContent();

            throw new Exception($"Updating Doctor {id} failed on save");
        }

        [HttpDelete("EliminarDoctor/{id:int}")]
        public async Task<IActionResult> EliminarDoctor(int id)
        {
            var doctorActual = await _controlInfo.GetDoctor(id);
            _context.Doctores.Remove(doctorActual);

            _context.SaveChanges();
            return NoContent();

            throw new Exception($"Deleting Doctor {id} failed on delete"); 
        }
    }
}