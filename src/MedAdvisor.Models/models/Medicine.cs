using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedAdvisor.Models.Models
{
    public class Medicine
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }
        public ICollection<UserMedicine> UserMedicines { get; set; } = null!;
    }
}

