using ControlMedico.API.Controllers;
using ControlMedico.Modelos.Modelos;
using System;
using System.Linq;
using Xunit;

namespace ControlMedico.API.UnitTest
{
    public class CitasControllerUnitTest
    {
        [Fact]
        public void TestObtenerPorCriterio()
        {
            var dbContext = SimuladorContextoBaseDatos.ObtenerContextoBaseDatos(nameof(TestObtenerPorCriterio));
            var controller = new CitasController(new AccesoDatos.Repositorios.RepositorioCita(dbContext));
            var response = controller.ObtenerPorCriterio(new Cita
            {
                FechaCita = DateTime.Now.AddHours(-24),
                InfoPaciente = new Paciente
                {
                    Identificacion = "114270541"
                }
            });
            dbContext.Dispose();
            Assert.True(response != null && response.Count() > 0);
        }

        [Fact]
        public void TestObtenerCitas()
        {
            var dbContext = SimuladorContextoBaseDatos.ObtenerContextoBaseDatos(nameof(TestObtenerCitas));
            var controller = new CitasController(new AccesoDatos.Repositorios.RepositorioCita(dbContext));
            var response = controller.ObtenerDatos();
            dbContext.Dispose();
            Assert.True(response != null);
        }

        [Fact]
        public void TestRegistrarCita()
        {
            var dbContext = SimuladorContextoBaseDatos.ObtenerContextoBaseDatos(nameof(TestRegistrarCita));
            var controller = new CitasController(new AccesoDatos.Repositorios.RepositorioCita(dbContext));
            var response = controller.RegistrarCita(new Cita
            {
                IdCita = 1,
                TipoCita = Modelos.Util.EnumTipoCita.MedicinaGeneral,
                FechaCita = DateTime.Today.AddHours(-24),
                Cancelada = false,
                IdPaciente = 1,
                InfoPaciente = new Paciente
                {
                    FechaNacimiento = Convert.ToDateTime("5/31/2016 11:11:00 PM"),
                    Genero = Modelos.Util.EnumGenero.Masculino,
                    Identificacion = "114270541",
                    IdPaciente = 1,
                    NombreCompleto = "José Luis Rodríguez",
                    Residencia = "San José, San José, Pavas",
                    Telefono = "84107796",
                    TipoIdentificacion = Modelos.Util.EnumTipoIdentificacion.Fisica
                }
            });
            dbContext.Dispose();
            Assert.True(response);
        }

        [Fact]
        public void TestCancelarCita()
        {
            var dbContext = SimuladorContextoBaseDatos.ObtenerContextoBaseDatos(nameof(TestCancelarCita));
            var controller = new CitasController(new AccesoDatos.Repositorios.RepositorioCita(dbContext));
            var cita = controller.ObtenerPorCriterio(new Cita
            {
                FechaCita = DateTime.Today.AddHours(-24),
                InfoPaciente = new Paciente
                {
                    Identificacion = "114270541"
                }
            }).FirstOrDefault();
            cita.Cancelada = true;
            cita.InfoPaciente = null;
            var response = controller.CancelarCita(cita);
            dbContext.Dispose();
            Assert.True(response);
        }
    }
}
