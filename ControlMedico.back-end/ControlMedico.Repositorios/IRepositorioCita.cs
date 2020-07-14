using ControlMedico.Modelos.Modelos;
using ControlMedico.Interfaces.Base;
using System;
using System.Collections.Generic;
namespace ControlMedico.Interfaces
{
    public interface IRepositorioCita : IRepositorio<Cita>
    {
        IEnumerable<Cita> ObtenerCitasPorCriterio(Cita filtroCita);
    }
}
