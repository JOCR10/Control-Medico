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
            //hacer join con repositorio de pacientes para obtener el nombre completo del paciente, refactorizar este método para devolver todas las citas o bien dependiendo de filtro utilizado: 
            //por nombre de paciente (like), por fecha de cita, por tipo de cita.
            return ContextoBaseDatos.Cita.Where(b => b.FechaCita == fechaCita).ToList();
        }

        //TO-DO validación de inserción de citas , tomar en cuenta que para el mismo paciente no se puede agendar una cita el mismo día.
        //TO-DO validación de cancelación de citas, con un mínimo de 24 horas de antelación.
    }
}
