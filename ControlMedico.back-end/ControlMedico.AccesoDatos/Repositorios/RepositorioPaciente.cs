using ControlMedico.AccesoDatos.ContextoBD;
using ControlMedico.Modelos.Modelos;
using ControlMedico.Interfaces;
using System.Linq;
using System.Collections.Generic;

namespace ControlMedico.AccesoDatos.Repositorios
{
    public class RepositorioPaciente : Repositorio<Paciente>, IRepositorioPaciente
    {
        public ContextoBaseDatos ContextoBaseDatos
        {
            get { return DatabaseContext as ContextoBaseDatos; }
        }

        public RepositorioPaciente(ContextoBaseDatos context) : base(context) { }

        public IEnumerable<Paciente> ObtenerPacientePorCriterio(Paciente filtroPaciente)
        {
            return base.ObtenerDatos().Where(paciente => (filtroPaciente.Identificacion == null || paciente.Identificacion == filtroPaciente.Identificacion)
               && (filtroPaciente.NombreCompleto == null || paciente.NombreCompleto.Contains(filtroPaciente.NombreCompleto)));
        }

        public void RegistrarPaciente(Paciente paciente)
        {
            if (!ExistePaciente(paciente.Identificacion))
            {
                base.Insertar(paciente);
            }
        }

        private bool ExistePaciente(string identificacion)
        {
            return ObtenerPacientePorCriterio(new Paciente
            {
                Identificacion = identificacion
            }).Any();
        }

        public void Commit()
        {
            ContextoBaseDatos.SaveChanges();
        }


    }
}
