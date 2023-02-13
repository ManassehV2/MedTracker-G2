namespace MedAdvisor.Models.Models
{
    public class UserAllergy
    {
        public int UserId { get; set; }
        public int AllergyId { get; set; }

        public User User { get; set; } = null!;

        public Allergy Allergy { get; set; } = null!;
    }
}
