using ControlMedico.Modelos.Modelos;
using ControlMedico.Interfaces.Base;
using System.Collections.Generic;
namespace ControlMedico.Interfaces
{
    public interface IRepositorioPaciente : IRepositorio<Paciente>
    {
        IEnumerable<Paciente> ObtenerPacientePorCriterio(Paciente filtroPaciente);
    }
}
