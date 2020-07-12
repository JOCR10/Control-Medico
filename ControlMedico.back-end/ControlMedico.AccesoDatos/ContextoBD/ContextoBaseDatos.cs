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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cita>(entity =>
            {
                entity.HasKey(e => e.IdCita)
                    .HasName("PK_CMCita");

                entity.Property(e => e.TipoCita).HasConversion(x => (byte)x, x => (EnumTipoCita)x).HasComment(@"1-Medicina General
2-Odontología
3-Pediatría
4-Neurología");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.IdPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CMCita_CMPaciente");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.IdPaciente)
                    .HasName("PK_CMPaciente");

                entity.Property(e => e.Genero).HasConversion(x => (byte)x, x => (EnumGenero)x).HasComment(@"1-Femenino
 2-Masculino");

                entity.Property(e => e.Identificacion).IsUnicode(false);

                entity.Property(e => e.NombreCompleto).IsUnicode(false);

                entity.Property(e => e.Residencia).IsUnicode(false);

                entity.Property(e => e.Telefono).IsUnicode(false);

                entity.Property(e => e.TipoIdentificacion).HasConversion(x => (byte)x, x => (EnumTipoIdentificacion)x).HasComment(@"1-Física.
2-Extranjero
3-Diplomático");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
