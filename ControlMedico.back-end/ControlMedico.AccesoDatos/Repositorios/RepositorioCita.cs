using ControlMedico.AccesoDatos.ContextoBD;
using ControlMedico.Modelos.Modelos;
using ControlMedico.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControlMedico.AccesoDatos.Repositorios
{
    public class RepositorioCita : Repositorio<Cita>, IRepositorioCita
    {
        public ContextoBaseDatos ContextoBaseDatos
        {
            get { return DatabaseContext as ContextoBaseDatos; }
        }

        public RepositorioCita(ContextoBaseDatos context) : base(context) { }

        public IEnumerable<Cita> ObtenerCitasPorFecha(DateTime fechaCita)
        {
            return ContextoBaseDatos.Cita.Where(b => b.FechaCita == fechaCita).ToList();
        }
    }
}
