using ControlMedico.API.Controllers;
using Xunit;

namespace ControlMedico.API.UnitTest
{
    public class PacientesControllerUnitTest
    {
        [Fact]
        public void TestObtenerPorIdentificacion()
        {
            var dbContext = SimuladorContextoBaseDatos.ObtenerContextoBaseDatos(nameof(TestObtenerPorIdentificacion));
            var controller = new PacientesController(new AccesoDatos.Repositorios.RepositorioPaciente(dbContext));
            var response = controller.ObtenerPorIdentificacion("114270541");
            dbContext.Dispose();
            Assert.True(response != null);
        }
    }
}
