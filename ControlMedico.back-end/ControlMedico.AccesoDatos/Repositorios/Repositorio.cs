using ControlMedico.Repositorios.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ControlMedico.AccesoDatos.Repositorios
{
    public abstract class Repositorio<TModelo> : IRepositorio<TModelo> where TModelo : class
    {
        protected readonly DbContext DatabaseContext;

        public Repositorio(DbContext context)
        {
            this.DatabaseContext = context;
        }

        public void Actualizar(TModelo modelo)
        {
            DatabaseContext.Set<TModelo>().Update(modelo);
        }

        public void Eliminar(TModelo modelo)
        {
            DatabaseContext.Set<TModelo>().Remove(modelo);
        }

        public void Insertar(TModelo modelo)
        {
            DatabaseContext.Set<TModelo>().Add(modelo);
        }

        public IEnumerable<TModelo> ObtenerDatos()
        {
            return DatabaseContext.Set<TModelo>().ToList();
        }

        public TModelo ObtenerPorID(int id)
        {
            return DatabaseContext.Set<TModelo>().Find(id);
        }

    }
}
