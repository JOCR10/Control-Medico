using ControlMedico.Modelos.Util;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlMedico.Modelos.Modelos
{
    public partial class Cita
    {
        [Key]
        public int IdCita { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaCita { get; set; }
        public int IdPaciente { get; set; }
        public EnumTipoCita TipoCita { get; set; }
        public bool Cancelada { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        [InverseProperty(nameof(Paciente.Cita))]
        public virtual Paciente IdPacienteNavigation { get; set; }
    }
}
