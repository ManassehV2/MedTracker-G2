using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedAdvisor.Models.Models
{
    public class UserAllergy
    {
        public int UserId { get; set; }
        public int AllergyId { get; set; }

        public User User { get; set; }

        public Allergy Allergy { get; set; }

    }
}
