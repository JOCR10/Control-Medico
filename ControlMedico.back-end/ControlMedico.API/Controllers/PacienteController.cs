using ControlMedico.AccesoDatos.Repositorios;
using ControlMedico.API.Controllers.Base;
using ControlMedico.Modelos.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("[action]/{identificacion}")]
        public Paciente ObtenerPorIdentificacion(string identificacion)
        {
            return base.Repositorio.ObtenerPacientePorIdentificacion(identificacion);
        }

        [HttpGet("[action]/{id}")]
        public Paciente ObtenerPorID(int id)
        {
            return base.Repositorio.ObtenerPorID(id);
        }
    }
}