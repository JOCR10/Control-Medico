using System.ComponentModel.DataAnnotations;

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
       
        public string Rol { get; set; }
    }
}
