namespace MedAdvisor.Models.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public ICollection<UserMedicine> UserMedicines { get; set; } = null!;
    }
}

