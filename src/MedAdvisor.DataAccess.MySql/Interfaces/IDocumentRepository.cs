using MedAdvisor.Models.Models;


namespace MedAdvisor.DataAccess.MySql
{
    public interface IDocumentRepository
    {
        Document Create(Document document);

        bool Update(Document document);

        bool Delete(Document document);

        ICollection<Document> GetMyDocuments(int userId);


        Document GetById(int id);

    }
}

