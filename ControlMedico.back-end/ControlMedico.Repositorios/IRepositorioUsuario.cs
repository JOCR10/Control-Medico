using ControlMedico.Modelos.Modelos;
using ControlMedico.Interfaces.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlMedico.Interfaces
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        Usuario Autenticar(string codUsuario, string contrasena);
    }
}
