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

        public Paciente ObtenerPacientePorIdentificacion(string identificacion)
        {
            return ContextoBaseDatos.Paciente.Where(b => b.Identificacion == identificacion).FirstOrDefault();
        }
    }
}
