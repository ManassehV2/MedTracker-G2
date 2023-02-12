using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedAdvisor.Models.Models
{
    public class Allergy
    {
        public int Id { get; set; }

        [Required]        
        public string Name { get; set; }

        [Required]        
        public string Code { get; set; }

        public ICollection<UserAllergy> UserAllergies { get; set; } = null!;
    }
}
