using ControlMedico.API.Controllers;
using ControlMedico.Modelos.Modelos;
using Xunit;

namespace ControlMedico.API.UnitTest
{
    public class PacientesControllerUnitTest
    {
        [Fact]
        public void TestObtenerPorCriterio()
        {
            var dbContext = SimuladorContextoBaseDatos.ObtenerContextoBaseDatos(nameof(TestObtenerPorCriterio));
            var controller = new PacientesController(new AccesoDatos.Repositorios.RepositorioPaciente(dbContext));
            var response = controller.ObtenerPorCriterio(new Paciente
            {
                Identificacion = "114270541"
            });
            dbContext.Dispose();
            Assert.True(response != null);
        }

        [Fact]
        public void TestObtenerPacientes()
        {
            var dbContext = SimuladorContextoBaseDatos.ObtenerContextoBaseDatos(nameof(TestObtenerPacientes));
            var controller = new PacientesController(new AccesoDatos.Repositorios.RepositorioPaciente(dbContext));
            var response = controller.ObtenerDatos();
            dbContext.Dispose();
            Assert.True(response != null);
        }
    }
}
