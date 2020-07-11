using ControlMedico.AccesoDatos.ContextoBD;
using ControlMedico.Modelos.Modelos;
using ControlMedico.Repositorios;
using System.Collections.Generic;
using System.Linq;

namespace ControlMedico.AccesoDatos.Repositorios
{
    public class RepositorioPaciente : Repositorio<Paciente>, IRepositorioPaciente
    {
        public ContextoBaseDatos ContextoBaseDatos
        {
            get { return DatabaseContext as ContextoBaseDatos; }
        }

        public RepositorioPaciente(ContextoBaseDatos context) : base(context) { }

        public IEnumerable<Paciente> ObtenerPacientes()
        {
            return ContextoBaseDatos.Pacientes.ToList();
        }

        public IEnumerable<Paciente> ObtenerPacientePorID(int id)
        {
            return ContextoBaseDatos.Pacientes.Where(b => b.IdPaciente == id).ToList();
        }
    }
}
