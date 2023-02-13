namespace MedAdvisor.Models.Models
{
    public class UserDiagnosis
    {
        public int UserId { get; set; }
        public int DiagnosisId { get; set; }

        public User User { get; set; } = null!;

        public Diagnosis Diagnosis { get; set; } = null!;
    }
}
