using Microsoft.EntityFrameworkCore;
using MedAdvisor.Models.Models;
using System.Security.Cryptography;

namespace MedAdvisor.DataAccess.MySql
{
    public class MedTrackerContext : DbContext
    {

        public MedTrackerContext(DbContextOptions<MedTrackerContext> options) : base(options) { }


        public DbSet<User> Users { get; set; }
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<Diagnosis> Diagnosis { get; set; }
        public DbSet<Document> Documents { get; set; }

        public DbSet<UserAllergy> UserAllergies { get; set; }
        public DbSet<UserMedicine> UserMedicines { get; set; }
        public DbSet<UserVaccine> UserVaccines { get; set; }
        public DbSet<UserDiagnosis> UserDiagnoses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var encoder = new HMACSHA512();
            byte[] passwordSalt = encoder.Key;
            byte[] passwordHash = encoder.ComputeHash(System.Text.Encoding.UTF8.GetBytes("Password"));

            modelBuilder.Entity<UserMedicine>()
                    .HasKey(ua => new { ua.UserId, ua.MedicineId });
            modelBuilder.Entity<UserMedicine>()
                    .HasOne(u => u.User)
                    .WithMany(ua => ua.UserMedicines)
                    .HasForeignKey(u => u.UserId);
            modelBuilder.Entity<UserMedicine>()
                    .HasOne(a => a.Medicine)
                    .WithMany(ua => ua.UserMedicines)
                    .HasForeignKey(a => a.MedicineId);


            modelBuilder.Entity<UserVaccine>()
                    .HasKey(ua => new { ua.UserId, ua.VaccineId });
            modelBuilder.Entity<UserVaccine>()
                    .HasOne(u => u.User)
                    .WithMany(ua => ua.UserVaccines)
                    .HasForeignKey(u => u.UserId);
            modelBuilder.Entity<UserVaccine>()
                    .HasOne(a => a.Vaccine)
                    .WithMany(ua => ua.UserVaccines)
                    .HasForeignKey(a => a.VaccineId);


            modelBuilder.Entity<UserDiagnosis>()
                    .HasKey(ua => new { ua.UserId, ua.DiagnosisId });
            modelBuilder.Entity<UserDiagnosis>()
                    .HasOne(u => u.User)
                    .WithMany(ua => ua.UserDiagnoses)
                    .HasForeignKey(u => u.UserId);
            modelBuilder.Entity<UserDiagnosis>()
                    .HasOne(a => a.Diagnosis)
                    .WithMany(ua => ua.UserDiagnoses)
                    .HasForeignKey(a => a.DiagnosisId);


            modelBuilder.Entity<UserAllergy>()
                    .HasKey(ua => new { ua.UserId, ua.AllergyId });
            modelBuilder.Entity<UserAllergy>()
                    .HasOne(u => u.User)
                    .WithMany(ua => ua.UserAllergies)
                    .HasForeignKey(u => u.UserId);
            modelBuilder.Entity<UserAllergy>()
                    .HasOne(a => a.Allergy)
                    .WithMany(ua => ua.UserAllergies)
                    .HasForeignKey(a => a.AllergyId);




        }

    }
}
