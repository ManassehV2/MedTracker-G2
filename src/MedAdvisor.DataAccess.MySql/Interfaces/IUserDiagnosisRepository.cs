using MedAdvisor.Models.Models;


namespace MedAdvisor.DataAccess.MySql.Interfaces
{
    public interface IUserDiagnosisRepository
    {
        ICollection<Diagnosis> GetUserDiagnoses(int id);

        bool AddDiagnoses(int id, List<Diagnosis> diagnoses);

        bool RemoveDiagnosis(int id, int diagnosis_id);
    }
}

