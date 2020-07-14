using ControlMedico.AccesoDatos.Repositorios;
using ControlMedico.AccesoDatos.Util;
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
    public class CitasController : BaseController<Cita, RepositorioCita>
    {

        UnidadTrabajo _unidadTrabajo;
        public CitasController(RepositorioCita repositorioCita) : base(repositorioCita)
        {
            _unidadTrabajo = new UnidadTrabajo(repositorioCita.ContextoBaseDatos);
        }

        [HttpPost("[action]")]
        public IEnumerable<Cita> ObtenerPorCriterio([FromBody]Cita cita)
        {
            return _unidadTrabajo.Citas.ObtenerCitasPorCriterio(cita);
        }

        [HttpGet("[action]")]
        public IEnumerable<Cita> ObtenerCitas()
        {
            return _unidadTrabajo.Citas.ObtenerCitasPorCriterio(new Cita());
        }


        [HttpPost("[action]")]
        public bool RegistrarCita([FromBody]Cita cita)
        {
            _unidadTrabajo.Pacientes.RegistrarPaciente(cita.InfoPaciente);
            if (_unidadTrabajo.Citas.RegistrarCita(cita))
            {
                _unidadTrabajo.Commit();
                return true;
            }
            return false;
        }


        [HttpPost("[action]")]
        public bool CancelarCita([FromBody]Cita cita)
        {
            var citaCancelada = _unidadTrabajo.Citas.CancelarCita(cita);
            _unidadTrabajo.Commit();
            return citaCancelada;
        }

    }
}