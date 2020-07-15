using ControlMedico.AccesoDatos.ContextoBD;
using ControlMedico.Modelos.Modelos;
using ControlMedico.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ControlMedico.AccesoDatos.Repositorios
{
    public class RepositorioCita : Repositorio<Cita>, IRepositorioCita
    {
        public ContextoBaseDatos ContextoBaseDatos
        {
            get { return DatabaseContext as ContextoBaseDatos; }
        }

        public RepositorioCita(ContextoBaseDatos context) : base(context) { }

        public IEnumerable<Cita> ObtenerCitasPorCriterio(Cita filtroCita)
        {
            return base.ObtenerDatos()
                .Join(ContextoBaseDatos.Paciente,
                cita => cita.IdPaciente,
                paciente => paciente.IdPaciente,
                (cita, paciente) => new Cita
                {
                    Cancelada = cita.Cancelada,
                    FechaCita = cita.FechaCita,
                    IdCita = cita.IdCita,
                    TipoCita = cita.TipoCita,
                    IdPaciente = paciente.IdPaciente,
                    InfoPaciente = new Paciente
                    {
                        NombreCompleto = paciente.NombreCompleto,
                        FechaNacimiento = paciente.FechaNacimiento,
                        Genero = paciente.Genero,
                        Identificacion = paciente.Identificacion,
                        Residencia = paciente.Residencia,
                        Telefono = paciente.Telefono,
                        TipoIdentificacion = paciente.TipoIdentificacion
                    }
                })
                .Where(citaPaciente => (filtroCita.FechaCita == null || citaPaciente.FechaCita == filtroCita.FechaCita) && (filtroCita.InfoPaciente?.Identificacion == null
                || citaPaciente.InfoPaciente?.Identificacion == filtroCita.InfoPaciente?.Identificacion) && (filtroCita.TipoCita == null || citaPaciente.TipoCita == filtroCita.TipoCita)).ToList();
        }

        private bool ExisteCita(string identificacion, DateTime fechaCita)
        {
            return ObtenerCitasPorCriterio(new Cita
            {
                FechaCita = fechaCita,
                InfoPaciente = new Paciente
                {
                    Identificacion = identificacion
                }
            }).Any();

        }

        public bool RegistrarCita(Cita cita)
        {
            if (ExisteCita(cita.InfoPaciente.Identificacion, cita.FechaCita.Value))
            {
                return false;
            }
            base.Insertar(cita);
            return true;
        }

        private bool CancelacionEsValida(Cita cita)
        {
            return (cita.FechaCita.Value - DateTime.Today).TotalHours >= 24;
        }

        public bool CancelarCita(Cita cita)
        {

            if (CancelacionEsValida(cita))
            {
                base.Actualizar(cita);
                return true;
            }
            return false;
        }

        public void Commit()
        {
            ContextoBaseDatos.SaveChanges();
        }
    }
}
