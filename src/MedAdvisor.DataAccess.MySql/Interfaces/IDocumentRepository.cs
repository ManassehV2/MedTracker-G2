using MedAdvisor.Models.Models;


namespace MedAdvisor.DataAccess.MySql
{
    public interface IDocumentRepository
    {
        Document Create(Document document);

        bool Update(Document document);

        bool Delete(int userId, int documentId);


        ICollection<Document> GetMyDocuments(int userId);


        Document GetById(int id);

    }
}

