using ControlMedico.Repositorios.Base;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ControlMedico.API.Controllers.Base
{
    public abstract class BaseController<TModelo, TRepositorio> : ControllerBase where TModelo : class where TRepositorio : IRepositorio<TModelo>
    {
        protected readonly TRepositorio Repositorio;

        public BaseController(TRepositorio repository)
        {
            this.Repositorio = repository;
        }

        [HttpGet]
        public IEnumerable<TModelo> ObtenerDatos()
        {
            return Repositorio.ObtenerDatos();
        }

        [HttpPost]
        public void InsertarDatos([FromBody] TModelo item)
        {
            Repositorio.Insertar(item);
        }

        [HttpPost]
        public void ActualizarDatos([FromBody] TModelo item)
        {
            Repositorio.Actualizar(item);
        }
    }
}
