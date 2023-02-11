using MedAdvisor.Models.Models;


namespace MedAdvisor.DataAccess.MySql.Interfaces
{
    public interface IDiagnosisRepository
    {

        ICollection<Diagnosis> GetDiagnoses(string query);
    }
}

