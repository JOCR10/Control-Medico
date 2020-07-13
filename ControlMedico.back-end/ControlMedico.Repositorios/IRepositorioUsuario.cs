using ControlMedico.Modelos.Modelos;
using ControlMedico.Repositorios.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlMedico.Repositorios
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        Usuario ObtenerUsuarioPorCodigo(string codUsuario);
        Usuario Autenticar(string codUsuario, string contrasena);
    }
}
