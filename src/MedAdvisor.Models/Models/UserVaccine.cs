namespace MedAdvisor.Models.Models
{
    public class UserVaccine
    {
        public int UserId { get; set; }
        public int VaccineId { get; set; }

        public User User { get; set; }

        public Vaccine Vaccine { get; set; }

    }
}
