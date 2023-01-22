using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.EntityFrameworkCore;
using MedAdvisor.Models.Models;

namespace MedAdvisor.DataAccess.MySql
{
    public class MedTrackerContext : DbContext
    {
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<Diagnosis> Diagnosis { get; set; }
        public DbSet<Document> Documents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=MedTracker;Trusted_Connection=True;TrustServerCertificate=true;");
        }
    }
}