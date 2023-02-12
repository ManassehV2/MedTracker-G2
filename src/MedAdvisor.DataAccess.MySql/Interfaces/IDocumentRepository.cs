using MedAdvisor.Models.Models;


namespace MedAdvisor.DataAccess.MySql
{
    public interface IDocumentRepository
    {
        ICollection<Document> GetDocuments(string query);
    }
}

