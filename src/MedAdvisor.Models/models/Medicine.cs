using System.ComponentModel.DataAnnotations;

namespace MedAdvisor.Models.Models
{
    public class Medicine
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Code { get; set; } = null!;
        public ICollection<UserMedicine> UserMedicines { get; set; } = null!;
    }
}
