namespace MedAdvisor.Models.Models
{
    public class UserMedicine
    {
        public int UserId { get; set; }
        public int MedicineId { get; set; }

        public User User { get; set; }

        public Medicine Medicine { get; set; }

    }
}
