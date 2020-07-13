using ControlMedico.Modelos.Modelos;
using System.Collections.Generic;
using System.Linq;

namespace ControlMedico.AccesoDatos.Util
{
    public static class ExtensionMethods
    {
        public static IEnumerable<Usuario> WithoutPasswords(this IEnumerable<Usuario> usuarios)
        {
            return usuarios.Select(x => x.WithoutPassword());
        }

        public static Usuario WithoutPassword(this Usuario usuario)
        {
            usuario.Contrasena = null;
            return usuario;
        }
    }
}