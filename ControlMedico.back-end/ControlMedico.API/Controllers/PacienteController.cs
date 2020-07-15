using ControlMedico.AccesoDatos.Repositorios;
using ControlMedico.AccesoDatos.Util;
using ControlMedico.API.Controllers.Base;
using ControlMedico.Modelos.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ControlMedico.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : BaseController<Paciente, RepositorioPaciente>
    {
        public PacientesController(RepositorioPaciente repositorioPaciente) : base(repositorioPaciente)
        {
        }

        [HttpPost("[action]")]
        public IEnumerable<Paciente> ObtenerPorCriterio([FromBody]Paciente paciente)
        {
            return base.Repositorio.ObtenerPacientePorCriterio(paciente);
        }
        [HttpGet("[action]")]
        public IEnumerable<Paciente> ObtenerPacientes()
        {
            return base.Repositorio.ObtenerDatos();
        }
    }
}