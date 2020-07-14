using ControlMedico.AccesoDatos.ContextoBD;
using ControlMedico.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlMedico.API.UnitTest
{
    public static class ExtensionesContextoBaseDatos
    {
        public static void CargarDatosSimulados(this ContextoBaseDatos contexto)
        {

            contexto.Paciente.Add(new Paciente
            {
                FechaNacimiento = Convert.ToDateTime("5/31/2016 11:11:00 PM"),
                Genero = Modelos.Util.EnumGenero.Masculino,
                Identificacion = "114270541",
                IdPaciente = 1,
                NombreCompleto = "José Luis Rodríguez",
                Residencia = "San José, San José, Pavas",
                Telefono = "84107796",
                TipoIdentificacion = Modelos.Util.EnumTipoIdentificacion.Fisica
            });
            contexto.Paciente.Add(new Paciente
            {
                FechaNacimiento = Convert.ToDateTime("5/31/2016 11:11:00 PM"),
                Genero = Modelos.Util.EnumGenero.Masculino,
                Identificacion = "123456789",
                IdPaciente = 2,
                NombreCompleto = "Luis Arroyo",
                Residencia = "San José, San José, Pavas",
                Telefono = "84107796",
                TipoIdentificacion = Modelos.Util.EnumTipoIdentificacion.Fisica
            });
            contexto.Paciente.Add(new Paciente
            {
                FechaNacimiento = Convert.ToDateTime("5/31/2016 11:11:00 PM"),
                Genero = Modelos.Util.EnumGenero.Masculino,
                Identificacion = "987654321",
                IdPaciente = 3,
                NombreCompleto = "José Fernández",
                Residencia = "San José, San José, Pavas",
                Telefono = "87942456",
                TipoIdentificacion = Modelos.Util.EnumTipoIdentificacion.Extranjero
            });
            contexto.Paciente.Add(new Paciente
            {
                FechaNacimiento = Convert.ToDateTime("5/31/2016 11:11:00 PM"),
                Genero = Modelos.Util.EnumGenero.Masculino,
                Identificacion = "123789456",
                IdPaciente = 4,
                NombreCompleto = "Marco Salas",
                Residencia = "San José, San José, Pavas",
                Telefono = "84107796",
                TipoIdentificacion = Modelos.Util.EnumTipoIdentificacion.Fisica
            });
            contexto.Paciente.Add(new Paciente
            {
                FechaNacimiento = Convert.ToDateTime("5/31/2016 11:11:00 PM"),
                Genero = Modelos.Util.EnumGenero.Femenino,
                Identificacion = "114270541",
                IdPaciente = 5,
                NombreCompleto = "Sandra Vargas",
                Residencia = "San José, San José, Pavas",
                Telefono = "84107796",
                TipoIdentificacion = Modelos.Util.EnumTipoIdentificacion.Fisica
            });

            contexto.Cita.Add(new Cita
            {
                TipoCita = Modelos.Util.EnumTipoCita.MedicinaGeneral,
                FechaCita = DateTime.Today.AddHours(-24),
                Cancelada = false,
                IdPaciente = 1
            });

            contexto.SaveChanges();
        }
    }
}
