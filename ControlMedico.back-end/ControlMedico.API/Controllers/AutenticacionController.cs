using ControlMedico.AccesoDatos.Repositorios;
using ControlMedico.API.Controllers.Base;
using ControlMedico.Modelos.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ControlMedico.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutenticacionController : BaseController<Usuario, RepositorioUsuario>
    {
        public AutenticacionController(RepositorioUsuario repositorioUsuario) : base(repositorioUsuario)
        {
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public IActionResult Login([FromBody]Usuario login)
        {
            IActionResult response = Unauthorized();
            Usuario usuario = AutenticarUsuario(login);
            if (usuario != null)
            {
                var tokenString = GenerarTokenJWT(usuario);
                response = Ok(new
                {
                    token = tokenString,
                    userDetails = usuario,
                });
            }

            return response;
        }

        private Usuario AutenticarUsuario(Usuario credenciales)
        {

            string AESKey = Startup.StaticConfig["AESKey:Key"];
            var contrasenaEncriptada = NETCore.Encrypt.EncryptProvider.AESEncrypt(credenciales.Contrasena, AESKey);
            return base.Repositorio.Autenticar(credenciales.CodUsuario, contrasenaEncriptada);
        }

        string GenerarTokenJWT(Usuario infoUsuario)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Startup.StaticConfig["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, infoUsuario.IdUsuario.ToString()),
                new Claim("rol",infoUsuario.Rol),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: Startup.StaticConfig["Jwt:Issuer"],
                audience: Startup.StaticConfig["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}