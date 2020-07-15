using System;
using System.Threading.Tasks;
using ControlMedico.Modelos.Modelos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ControlMedico.API.IntegrationTests
{
    [TestClass]
    public class ControllersTest : IntegrationTestInitializer
    {

        private async Task<string> GetToken(string userName, string password)
        {
            var user = new Usuario
            {
                CodUsuario = userName,
                Contrasena = password
            };

            var res = await _client.PostAsJsonAsync("/api/Autenticacion/Login", user);

            if (!res.IsSuccessStatusCode) return null;

            var userModel = await res.Content.ReadAsAsync<Usuario>();

            return userModel?.CodUsuario;

        }
        [TestMethod]
        public async Task TestLogin()
        {
            // Arrange
            var request = new
            {
                Url = "/api/Autenticacion/Login",
                Body = new
                {
                    CodUsuario = "admin",
                    Contrasena = "admin123"
                }
            };
            // Act
            var response = await _client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [TestMethod]
        public async Task TestObtenerPacientes()
        {
            var token = await GetToken("foo", "bar");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Arrange
            var request = new
            {
                Url = "/api/pacientes/ObtenerPacientes"
            };
            // Act
            var response = await _client.GetAsync(request.Url);

            // Assert
            response.EnsureSuccessStatusCode();
        }
        [TestMethod]
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
            var response = await _client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
