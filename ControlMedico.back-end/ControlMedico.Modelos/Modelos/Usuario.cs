using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlMedico.Modelos.Modelos
{
    public partial class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        [Required]
        [StringLength(20)]
        public string CodUsuario { get; set; }
        [Required]
        [StringLength(100)]
        public string Contrasena { get; set; }
        [Required]
        [StringLength(50)]
        public string Rol { get; set; }
    }
}
