using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedAdvisor.Models.Models
{
    public class Diagnosis
    {
        public int Id { get; set; }

        [Required]        
        public string Name { get; set; }

        [Required]        
        public string Code { get; set; }

        public ICollection<UserDiagnosis> UserDiagnoses { get; set; } = null!;

    }
}
