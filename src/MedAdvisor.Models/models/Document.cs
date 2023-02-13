using System.ComponentModel.DataAnnotations;

namespace MedAdvisor.Models.Models
{
    public class Document
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; } = null!;

        [Required]
        public string? Title { get; set; }

        public enum Documenttypes
        {
            Certificate,
            Discharge_Summary,
            Insurance,
            Living_Will,
            Passport,
            Prescription,
            Travel_Document,
            X_ray,
            Other
        }
        public Documenttypes Type { get; set; }
        public string? Description { get; set; } 
        public string FileName { get; set; } = null!;
    }
}