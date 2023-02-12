using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.EntityFrameworkCore;
using MedAdvisor.Models.Models;
using System.Security.Cryptography;

namespace MedAdvisor.DataAccess.MySql
{
    public class MedTrackerContext : DbContext
    {

        public MedTrackerContext(DbContextOptions<MedTrackerContext> options): base(options){}


        public DbSet<User> Users { get; set; }
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<Diagnosis> Diagnosis { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<FileContent> Files { get; set; }

        public DbSet<UserAllergy> UserAllergies { get; set; }
        public DbSet<UserMedicine> UserMedicines { get; set; }
        public DbSet<UserVaccine> UserVaccines { get; set; }
        public DbSet<UserDiagnosis> UserDiagnoses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var encoder = new HMACSHA512();
            byte[] passwordSalt = encoder.Key;
            byte[] passwordHash = encoder.ComputeHash(System.Text.Encoding.UTF8.GetBytes("Password"));
            modelBuilder.Entity<User>()
            .HasData(new User()
            {
                Id = -1,
                Email = "Henok@gmail.com",
                HashedPassword = passwordHash,
                Salt = passwordSalt,
                FirstName = "Henok",
                LastName = "Matheas"

            },
            new User()
            {
                Id = 2,
                Email = "Naty@gmail.com",
                HashedPassword = passwordHash,
                Salt = passwordSalt,
                FirstName = "Nathnael",
                LastName = "Tadele"

            },
            new User()
            {
                Id = 3,
                Email = "Feven@gmail.com",
                HashedPassword = passwordHash,
                Salt = passwordSalt,
                FirstName = "Feven",
                LastName = "Belay"

            }
            );

            modelBuilder.Entity<Allergy>()
            .HasData(new Allergy()
            {
                Id = 1,
                Name = "Egg Yolk",
                Code = "WMCX0018",
            },
            new Allergy()
            {
                Id = 2,
                Name = "DATE",
                Code = "WMCX0013",
            },
            new Allergy()
            {
                Id = 3,
                Name = "Grape",
                Code = "WMCX0015",
            },
            new Allergy()
            {
                Id = 4,
                Name = "Apple",
                Code = "WMCX0020",
            },
            new Allergy()
            {
                Id = 5,
                Name = "pea",
                Code = "WMCX0021",
            },
            new Allergy()
            {
                Id = 6,
                Name = "Rat",
                Code = "WMCX0007",
            },
            new Allergy()
            {
                Id = 7,
                Name = "Kemiri nut",
                Code = "WMCX0011",
            }
            );


            modelBuilder.Entity<Diagnosis>()
            .HasData(new Diagnosis()
            {
                Id = 1,
                Name = "Cholera, unspecified",
                Code = "A009",
            },
            new Diagnosis()
            {
                Id = 2,
                Name = "Paratyphoid fever C",
                Code = "A013",
            },
            new Diagnosis()
            {
                Id = 3,
                Name = "Localized salmonella infections",
                Code = "A022",
            },
            new Diagnosis()
            {
                Id = 4,
                Name = "Bacterial intestinal infection, unspecified",
                Code = "A049",
            },
            new Diagnosis()
            {
                Id = 5,
                Name = "Acute amoebic dysentery",
                Code = "A060",
            },
            new Diagnosis()
            {
                Id = 6,
                Name = "Foodborne Vibrio parahaemolyticus intoxication",
                Code = "A053",
            },
            new Diagnosis()
            {
                Id = 7,
                Name = "Amoebic liver abscess",
                Code = "A064",
            }
            );

            modelBuilder.Entity<Vaccine>()
           .HasData(new Vaccine()
           {
               Id = 1,
               Name = "Anthrax",
               Code = "24",
           },
           new Vaccine()
           {
               Id = 2,
               Name = "dengue fever",
               Code = "56",
           },
           new Vaccine()
           {
               Id = 3,
               Name = "botulinum antitoxin",
               Code = "27",
           },
           new Vaccine()
           {
               Id = 4,
               Name = "DTAP-Hib",
               Code = "50",
           },
           new Vaccine()
           {
               Id = 5,
               Name = "Moderna COVID-19",
               Code = "221",
           },
           new Vaccine()
           {
               Id = 6,
               Name = "DTaP",
               Code = "20",
           },
           new Vaccine()
           {
               Id = 7,
               Name = "cholera, unspecified formulation",
               Code = "26",
           }
           );


            modelBuilder.Entity<Medicine>()
       .HasData(new Medicine()
       {
           Id = 1,
           Name = "Etanercept",
           Code = "L04AA11",
       },
       new Medicine()
       {
           Id = 2,
           Name = "Trovast",
           Code = "C10AA05",
       },
       new Medicine()
       {
           Id = 3,
           Name = "Jeprolol",
           Code = "C07AB02",
       },
       new Medicine()
       {
           Id = 4,
           Name = "Pinex Major",
           Code = "N02AA59",
       },
       new Medicine()
       {
           Id = 5,
           Name = "Cardizem inj",
           Code = "H02AB10",
       },
       new Medicine()
       {
           Id = 6,
           Name = "Zarator",
           Code = "c10AA05",
       },
       new Medicine()
       {
           Id = 7,
           Name = "Esomerprazole",
           Code = "A02BC05",
       }
       );

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