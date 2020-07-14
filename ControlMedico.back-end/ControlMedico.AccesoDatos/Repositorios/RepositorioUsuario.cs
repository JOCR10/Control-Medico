using ControlMedico.AccesoDatos.ContextoBD;
using ControlMedico.AccesoDatos.Util;
using ControlMedico.Modelos.Modelos;
using ControlMedico.Interfaces;
using System.Linq;
using System.Collections.Generic;

namespace ControlMedico.AccesoDatos.Repositorios
{
    public class RepositorioUsuario : Repositorio<Usuario>, IRepositorioUsuario
    {
        public ContextoBaseDatos ContextoBaseDatos
        {
            get { return DatabaseContext as ContextoBaseDatos; }
        }

        public RepositorioUsuario(ContextoBaseDatos context) : base(context) { }

        public Usuario Autenticar(string codUsuario, string contrasena)
        {
            Usuario usuario = ContextoBaseDatos.Usuario.Where(b => b.CodUsuario == codUsuario && b.Contrasena == contrasena).FirstOrDefault();
            if (usuario == null)
            {
                return null;
            }
            return usuario.SinContrasena();
        }



        public void Commit()
        {
            ContextoBaseDatos.SaveChanges();
        }
    }
    public static class ExtensionUsuario
    {
        public static IEnumerable<Usuario> SinContrasenas(this IEnumerable<Usuario> usuarios)
        {
            return usuarios.Select(x => x.SinContrasena());
        }

        public static Usuario SinContrasena(this Usuario usuario)
        {
            usuario.Contrasena = null;
            return usuario;
        }
    }
}
