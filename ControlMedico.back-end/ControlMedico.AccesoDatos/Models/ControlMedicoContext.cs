using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ControlMedico.AccesoDatos.Models
{
    public partial class ControlMedicoContext : DbContext
    {
        public ControlMedicoContext()
        {
        }

        public ControlMedicoContext(DbContextOptions<ControlMedicoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cita> Cita { get; set; }
        public virtual DbSet<Paciente> Paciente { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=ControlMedico;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cita>(entity =>
            {
                entity.HasKey(e => e.IdCita)
                    .HasName("PK_CMCita");

                entity.Property(e => e.TipoCita).HasComment(@"1-Medicina General
2-Odontología
3-Pediatría
4-Neurología");

                entity.HasOne(d => d.InfoPaciente)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.IdPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CMCita_CMPaciente");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.IdPaciente)
                    .HasName("PK_CMPaciente");

                entity.Property(e => e.Genero).HasComment(@"1-Femenino
 2-Masculino");

                entity.Property(e => e.Identificacion).IsUnicode(false);

                entity.Property(e => e.NombreCompleto).IsUnicode(false);

                entity.Property(e => e.Residencia).IsUnicode(false);

                entity.Property(e => e.Telefono).IsUnicode(false);

                entity.Property(e => e.TipoIdentificacion).HasComment(@"1-Física.
2-Extranjero
3-Diplomático");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasIndex(e => e.CodUsuario)
                    .HasName("UK_Usuario_CodUsuario")
                    .IsUnique();

                entity.Property(e => e.CodUsuario).IsUnicode(false);

                entity.Property(e => e.Contrasena).IsUnicode(false);

                entity.Property(e => e.Rol).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
