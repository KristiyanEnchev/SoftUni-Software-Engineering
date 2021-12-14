using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {
        }

        public HospitalContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Visitation> Visitations { get; set; }
        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<PatientMedicament> PatientMedicaments { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Integrated Security=true;Database=Hospital");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().HasKey(x => x.PatientId);
            modelBuilder.Entity<Patient>().Property(x => x.FirstName).IsUnicode().HasMaxLength(50);
            modelBuilder.Entity<Patient>().Property(x => x.LastName).IsUnicode().HasMaxLength(50);
            modelBuilder.Entity<Patient>().Property(x => x.Address).IsUnicode().HasMaxLength(250);
            modelBuilder.Entity<Patient>().Property(x => x.Email).IsUnicode(false).HasMaxLength(80);

            modelBuilder.Entity<Visitation>().HasKey(x => x.VisitationId);
            modelBuilder.Entity<Visitation>().Property(x => x.Comments).IsUnicode().HasMaxLength(250);
            modelBuilder.Entity<Visitation>().HasOne(x => x.Patient).WithMany(p => p.Visitations).HasForeignKey(f => f.PatientId);
            modelBuilder.Entity<Visitation>().HasOne(v => v.Doctor).WithMany(d => d.Visitations).HasForeignKey(v => v.DoctorId);

            modelBuilder.Entity<Diagnose>().HasKey(x => x.DiagnoseId);
            modelBuilder.Entity<Diagnose>().Property(x => x.Name).IsUnicode().HasMaxLength(50);
            modelBuilder.Entity<Diagnose>().Property(x => x.Comments).IsUnicode().HasMaxLength(250);
            modelBuilder.Entity<Diagnose>().HasOne(x => x.Patient).WithMany(p => p.Diagnoses).HasForeignKey(f => f.PatientId);

            modelBuilder.Entity<Medicament>().HasKey(x => x.MedicamentId);
            modelBuilder.Entity<Medicament>().Property(x => x.Name).IsUnicode().HasMaxLength(50);

            modelBuilder.Entity<Doctor>().HasKey(x => x.DoctorId);
            modelBuilder.Entity<Doctor>().Property(x => x.Name).IsUnicode().HasMaxLength(100);
            modelBuilder.Entity<Doctor>().Property(x => x.Specialty).IsUnicode().HasMaxLength(100);

            modelBuilder.Entity<PatientMedicament>().HasKey(x => new { x.PatientId, x.MedicamentId });
        }
    }
}
