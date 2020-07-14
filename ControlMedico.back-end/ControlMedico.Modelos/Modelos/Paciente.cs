using ControlMedico.Modelos.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlMedico.Modelos.Modelos
{
    public partial class Paciente
    {
        [Key]
        public int IdPaciente { get; set; }
        [StringLength(12)]
        public string Identificacion { get; set; }
        public EnumTipoIdentificacion TipoIdentificacion { get; set; }
        public string DesTipoIdentificacion { get { return ExtensionEnum.ObtenerDescripcionEnum((EnumTipoIdentificacion)TipoIdentificacion); } }
        [StringLength(100)]
        public string NombreCompleto { get; set; }
        [Column(TypeName = "date")]
        public DateTime FechaNacimiento { get; set; }
        public EnumGenero Genero { get; set; }
        public string DesGenero { get { return ExtensionEnum.ObtenerDescripcionEnum((EnumGenero)Genero); } }
        [Required]
        [StringLength(250)]
        public string Residencia { get; set; }
        [Required]
        [StringLength(8)]
        public string Telefono { get; set; }

        //[InverseProperty("IdPacienteNavigation")]
        //public virtual ICollection<Cita> Cita { get; set; }




    }
}
