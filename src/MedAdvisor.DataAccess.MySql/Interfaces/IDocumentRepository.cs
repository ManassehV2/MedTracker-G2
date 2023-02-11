using MedAdvisor.Models.Models;


namespace MedAdvisor.DataAccess.MySql.Interfaces
{
    public interface IDocumentRepository
    {
        ICollection<Document> GetDocuments(string query);
    }
}

