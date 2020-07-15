using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlMedico.AccesoDatos.Models
{
    public partial class Paciente
    {
        public Paciente()
        {
            Cita = new HashSet<Cita>();
        }

        [Key]
        public int IdPaciente { get; set; }
        [Required]
        [StringLength(12)]
        public string Identificacion { get; set; }
        public byte TipoIdentificacion { get; set; }
        [Required]
        [StringLength(100)]
        public string NombreCompleto { get; set; }
        [Column(TypeName = "date")]
        public DateTime FechaNacimiento { get; set; }
        public byte Genero { get; set; }
        [Required]
        [StringLength(250)]
        public string Residencia { get; set; }
        [Required]
        [StringLength(8)]
        public string Telefono { get; set; }

        [InverseProperty("IdPacienteNavigation")]
        public virtual ICollection<Cita> Cita { get; set; }
    }
}
