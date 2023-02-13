using System.ComponentModel.DataAnnotations;

namespace MedAdvisor.Models.Models
{
    public class Allergy
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Code { get; set; } = null!;

        public ICollection<UserAllergy> UserAllergies { get; set; } = null!;
    }
}
