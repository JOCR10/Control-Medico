using ControlMedico.Modelos.Modelos;
using ControlMedico.Repositorios.Base;
using System.Collections.Generic;
namespace ControlMedico.Repositorios
{
    public interface IRepositorioPaciente : IRepositorio<Paciente>
    {
        Paciente ObtenerPacientePorIdentificacion(string identificacion);
    }
}
