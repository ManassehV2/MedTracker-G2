using MedAdvisor.Models.Models;


namespace MedAdvisor.DataAccess.MySql
{
    public interface IDocumentRepository
    {
        Document Create(Document document);

        bool Update(Document document);

        bool Delete(int UserId, int DocumentId);


        ICollection<Document> GetMyDocuments(int userId);


        Document GetById(int id);

    }
}

