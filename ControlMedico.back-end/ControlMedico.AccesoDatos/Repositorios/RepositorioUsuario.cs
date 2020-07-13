using ControlMedico.AccesoDatos.ContextoBD;
using ControlMedico.AccesoDatos.Util;
using ControlMedico.Modelos.Modelos;
using ControlMedico.Repositorios;
using System.Linq;
using System.Threading.Tasks;

namespace ControlMedico.AccesoDatos.Repositorios
{
    public class RepositorioUsuario : Repositorio<Usuario>, IRepositorioUsuario
    {
        public ContextoBaseDatos ContextoBaseDatos
        {
            get { return DatabaseContext as ContextoBaseDatos; }
        }

        public RepositorioUsuario(ContextoBaseDatos context) : base(context) { }

        public Usuario ObtenerUsuarioPorCodigo(string codUsuario)
        {
            return ContextoBaseDatos.Usuario.Where(b => b.CodUsuario == codUsuario).FirstOrDefault();
        }

        public Usuario Autenticar(string codUsuario, string contrasena)
        {
            Usuario usuario = ContextoBaseDatos.Usuario.Where(b => b.CodUsuario == codUsuario && b.Contrasena == contrasena).FirstOrDefault();
            if (usuario == null)
            {
                return null;
            }
            return usuario.WithoutPassword();
        }
    }
}
