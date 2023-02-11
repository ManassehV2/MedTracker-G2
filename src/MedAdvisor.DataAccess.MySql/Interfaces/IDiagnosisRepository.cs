using MedAdvisor.Models.Models;

namespace MedAdvisor.DataAccess.MySql
{
    public interface IDiagnosisRepository
    {

        ICollection<Diagnosis> GetDiagnoses(string query);
    }
}

