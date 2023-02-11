using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedAdvisor.Models.Models
{
    public class Vaccine
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Must be at least 4 characters long.")]
        public string? Name { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Must be at least 4 characters long.")]
        public string? Code { get; set; }

        public ICollection<UserVaccine> UserVaccines { get; set; } = null!;

    }
}
