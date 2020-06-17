using BackNexos.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BackNexos.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options){}

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Doctor> Doctores{get; set; }
        public DbSet<RelacionPacienteDoctor> relacionPacienteDoctor { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RelacionPacienteDoctor>().HasKey(k => new { k.PacienteId, k.DoctorId });

            modelBuilder.Entity<RelacionPacienteDoctor>()
                .HasOne(x => x.Paciente)
                .WithMany(x => x.RelacionPacienteDoctor)
                .HasForeignKey(x => x.PacienteId);

            modelBuilder.Entity<RelacionPacienteDoctor>()
                .HasOne(x => x.Doctor)
                .WithMany(x => x.RelacionPacienteDoctor)
                .HasForeignKey(x => x.DoctorId);

            base.OnModelCreating(modelBuilder);
        }
    }
}