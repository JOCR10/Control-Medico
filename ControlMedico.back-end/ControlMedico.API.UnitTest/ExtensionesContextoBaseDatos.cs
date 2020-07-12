using ControlMedico.AccesoDatos.ContextoBD;
using ControlMedico.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlMedico.API.UnitTest
{
   public static class ExtensionesContextoBaseDatos
    {
        public static void Seed(this ContextoBaseDatos contexto)
        {
            // Add entities for DbContext instance

            contexto.Paciente.Add(new Paciente
            {
                FechaNacimiento = Convert.ToDateTime("5/31/2016 11:11:00 PM"),
                Genero = Modelos.Util.EnumGenero.Masculino,
                Identificacion = "114270541",
                IdPaciente=1,
                NombreCompleto = "José Luis Rodríguez",
                Residencia = "San José, San José, Pavas",
                Telefono = "84107796",
                TipoIdentificacion = Modelos.Util.EnumTipoIdentificacion.Fisica
            }); 

            contexto.SaveChanges();
        }
    }
}
