using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace ControlMedico.Modelos.Util
{
    public enum EnumTipoIdentificacion
    {
        [Description("Física nacional")]
        Fisica = 1,
        [Description("Extranjero")] 
        Extranjero,
        [Description("Diplomático")] 
        Diplomatico
    }

    public enum EnumGenero
    {
        [Description("Femenino")]
        Femenino = 1, 
        [Description("Masculino")] 
        Masculino=2
    }
    public enum EnumTipoCita
    {
        [Description("Medicina General")]
        MedicinaGeneral = 1,
        [Description("Odontología")]
        Odontologia = 2,
        [Description("Pediatría")] 
        Pediatria = 3,
        [Description("Neurología")] 
        Neurologia = 4
    }

    public class ExtensionEnum
    {
        public static string ObtenerDescripcionEnum(Enum valor)
        {
            FieldInfo info = valor.GetType().GetField(valor.ToString());

            DescriptionAttribute[] atributos = info.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (atributos != null && atributos.Any())
            {
                return atributos.First().Description;
            }

            return valor.ToString();
        }
    }

}
