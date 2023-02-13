using System.ComponentModel.DataAnnotations;

namespace MedAdvisor.Models.Models
{
    public class Vaccine
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Code { get; set; }

        public ICollection<UserVaccine> UserVaccines { get; set; } = null!;
    }
}
