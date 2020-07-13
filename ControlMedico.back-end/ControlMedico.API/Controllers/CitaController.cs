using ControlMedico.AccesoDatos.Repositorios;
using ControlMedico.API.Controllers.Base;
using ControlMedico.Modelos.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ControlMedico.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : BaseController<Cita, RepositorioCita>
    {
        public CitaController(RepositorioCita repositorioCita) : base(repositorioCita)
        {
        }

        [HttpGet("[action]/{fecha}")]
        public IEnumerable<Cita> ObtenerPorFecha(DateTime fecha)
        {
            return base.Repositorio.ObtenerCitasPorFecha(fecha);
        }
    }
}