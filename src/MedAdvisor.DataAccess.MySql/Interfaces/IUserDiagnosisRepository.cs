using MedAdvisor.Models.Models;


namespace MedAdvisor.DataAccess.MySql.Interfaces
{
    public interface IUserDiagnosisRepository
    {
        ICollection<Diagnosis> GetUserDiagnoses(int id);

        bool AddDiagnosis(int userId, int diagnosisId);

        bool RemoveDiagnoses(int userId, List<int> diagnoses);
    }
}

