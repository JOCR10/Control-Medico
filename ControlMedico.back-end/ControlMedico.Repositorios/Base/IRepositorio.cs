using System.Collections.Generic;

namespace ControlMedico.Interfaces.Base
{
    public interface IRepositorio<TModelo> where TModelo : class
    {
        void Insertar(TModelo entity);
        void Eliminar(TModelo entity);
        TModelo ObtenerPorID(int id);
        IEnumerable<TModelo> ObtenerDatos();
        void Actualizar(TModelo entity);

    }
}
