using ControlMedico.AccesoDatos.ContextoBD;
using ControlMedico.AccesoDatos.Repositorios;
using ControlMedico.Interfaces.Base;
using ControlMedico.Modelos.Modelos;
using System.Collections.Generic;

namespace ControlMedico.AccesoDatos.Util
{
    public class UnidadTrabajo
    {
        private ContextoBaseDatos _contextoBaseDatos;
        private RepositorioPaciente _pacientes;
        private RepositorioCita _cita;

        public UnidadTrabajo(ContextoBaseDatos contextoBaseDatos)
        {
            _contextoBaseDatos = contextoBaseDatos;
        }

        public RepositorioPaciente Pacientes
        {
            get
            {
                return _pacientes ??
                    (_pacientes = new RepositorioPaciente(_contextoBaseDatos));
            }
        }

        public RepositorioCita Citas
        {
            get
            {
                return _cita ??
                    (_cita = new RepositorioCita(_contextoBaseDatos));
            }
        }

        public void Commit()
        {
            _contextoBaseDatos.SaveChanges();
        }
    }
}
