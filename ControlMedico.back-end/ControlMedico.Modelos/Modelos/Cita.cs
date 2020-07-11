using ControlMedico.Modelos.Util;
using System;
using System.ComponentModel.DataAnnotations;

namespace ControlMedico.Modelos.Modelos
{
    public class Cita
    {
        [Key]
        [Required]
        public int IdCita { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaCita { get; set; }

        [Required]
        public EnumTipoCita TipoCita { get; set; }

        [Required]
        public bool Cancelada { get; set; }
    }
}
