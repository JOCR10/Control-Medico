using ControlMedico.AccesoDatos.ContextoBD;
using ControlMedico.Modelos.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlMedico.API.UnitTest
{
   public static class SimuladorContextoBaseDatos
    {
        public static ContextoBaseDatos ObtenerContextoBaseDatos(string baseDatos)
        {
            var options = new DbContextOptionsBuilder<ContextoBaseDatos>()
                .UseInMemoryDatabase(databaseName: baseDatos)
                .Options;
            var dbContext = new ContextoBaseDatos(options);
            dbContext.CargarDatosSimulados();
            return dbContext;
        }
    }
}
