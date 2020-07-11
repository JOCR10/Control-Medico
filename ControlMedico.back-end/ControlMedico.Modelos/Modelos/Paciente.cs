using ControlMedico.Modelos.Util;
using System;
using System.ComponentModel.DataAnnotations;

namespace ControlMedico.Modelos.Modelos
{
    public class Paciente
    {
        [Key]
        [Required]
        public int IdPaciente { get; set; }

        [Required]
        [StringLength(12)]
        public string Identificacion { get; set; }

        [Required]
        public EnumTipoIdentificacion TipoIdentificacion { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreCompleto { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public EnumGenero Genero{ get; set; }

        [Required]
        [StringLength(250)]
        public string Residencia { get; set; }

        [Required]
        [StringLength(8)]
        public string Telefono { get; set; }
    }
}
