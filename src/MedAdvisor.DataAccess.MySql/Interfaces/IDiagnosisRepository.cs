using MedAdvisor.Models.Models;


namespace MedAdvisor.DataAccess.MySql.Interfaces
{
    public interface IDiagnosisRepository
    {

        ICollection<Diagnosis> GetDiagnosiss();
    }
}

