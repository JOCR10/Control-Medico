using ControlMedico.Modelos.Modelos;
using ControlMedico.Repositorios.Base;
using System.Collections.Generic;
namespace ControlMedico.Repositorios
{
    public interface IRepositorioPaciente : IRepositorio<Paciente>
    {
        IEnumerable<Paciente> ObtenerPacientes();
        IEnumerable<Paciente> ObtenerPacientePorID(int id);
    }
}
