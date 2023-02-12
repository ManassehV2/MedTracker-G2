using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedAdvisor.Models.Models
{
    public class Document
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
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
        public string Description { get; set; } = string.Empty;
        public ICollection<FileContent> Files { get; set; } = null!;
    }
}