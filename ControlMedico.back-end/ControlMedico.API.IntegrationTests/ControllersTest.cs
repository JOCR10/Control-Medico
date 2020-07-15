using ControlMedico.Modelos.Modelos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlMedico.API.IntegrationTests
{
    public class ControllersTest : IClassFixture<TestAPI<Startup>>
    {
        private HttpClient Client;

        public class Auth
        {
            public Usuario userDetails { get; set; }
            public string token { get; set; }
        }

        public ControllersTest(TestAPI<Startup> api)
        {
            Client = api.Client;
        }

        private async Task<string> GetToken(string userName, string password)
        {
            var user = new Usuario
            {
                CodUsuario = userName,
                Contrasena = password
            };

            var res = await Client.PostAsJsonAsync("api/autenticacion/login", user);

            //var a = JsonConvert.DeserializeObject(res.Content.ReadAsStringAsync().Result);
            var content = await res.Content.ReadAsStringAsync();
            Auth infoauth = JsonConvert.DeserializeObject<Auth>(content);

            return infoauth.token;
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
                    CodUsuario = "admin",
                    Contrasena = "admin123"
                }
            };
            // Act
            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestObtenerPacientes()
        {
            var token = await GetToken("admin", "admin123");
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            // Arrange
            var request = new
            {
                Url = "/api/pacientes/ObtenerPacientes"
            };



            // Act
            var response = await Client.GetAsync(request.Url);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestCancelarCita()
        {
            var token = await GetToken("admin", "admin123");
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

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
