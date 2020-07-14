using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlMedico.API.IntegrationTests
{
    public class AutenticacionTest : IClassFixture<TestAPI<Startup>>
    {
        private HttpClient Client;

        public AutenticacionTest(TestAPI<Startup> api)
        {
            Client = api.Client;
        }

        [Fact]
        public async Task TestLogin()
        {
            // Arrange
            var request = new
            {
                Url = "/api/Autenticacion/Login",
                Body = new
                {
                    CodUsuario= "admin",
                    Contrasena="admin123"
                }
            };
            // Act
            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestCancelarCita()
        {
            // Arrange
            var request = new
            {
                Url = "/api/citas/cancelarCita",
                Body = new
                {
                    IdCita = 1,
                    TipoCita = Modelos.Util.EnumTipoCita.MedicinaGeneral,
                    FechaCita = DateTime.Today.AddDays(10),
                    Cancelada = false,
                    IdPaciente = 1
                }
            };

            // Act
            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
