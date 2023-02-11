using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedAdvisor.Models.Models
{
    public class Document
    {
        public int Id { get; set; }
        // public file{get; set;}

        [Required]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Must be at least 4 characters long.")]
        public string Title { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

    }
}
