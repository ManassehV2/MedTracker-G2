namespace MedAdvisor.Models.Models
{
    public class UserMedicine
    {
        public int UserId { get; set; }
        public int MedicineId { get; set; }

        public User User { get; set; } = null!;

        public Medicine Medicine { get; set; } = null!;
    }
}
