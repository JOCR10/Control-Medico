using ControlMedico.Modelos.Modelos;
using ControlMedico.Modelos.Util;
using Microsoft.EntityFrameworkCore;

namespace ControlMedico.AccesoDatos.ContextoBD
{
    public partial class ContextoBaseDatos : DbContext
    {
        public ContextoBaseDatos()
        {
        }

        public ContextoBaseDatos(DbContextOptions<ContextoBaseDatos> options)
            : base(options)
        {
        }

        public virtual DbSet<Cita> Cita { get; set; }
        public virtual DbSet<Paciente> Paciente { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cita>(entity =>
            {
                entity.Property(e => e.TipoCita).HasConversion(x => (byte)x, x => (EnumTipoCita)x);
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.Property(e => e.Genero).HasConversion(x => (byte)x, x => (EnumGenero)x);
                entity.Property(e => e.TipoIdentificacion).HasConversion(x => (byte)x, x => (EnumTipoIdentificacion)x);
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
