using ControlMedico.Modelos.Modelos;
using ControlMedico.Repositorios.Base;
using System;
using System.Collections.Generic;
namespace ControlMedico.Repositorios
{
    public interface IRepositorioCita : IRepositorio<Cita>
    {
        IEnumerable<Cita> ObtenerCitasPorFecha(DateTime fechaCita);
    }
}
