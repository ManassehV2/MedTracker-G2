using MedAdvisor.Models.Models;

namespace MedAdvisor.DataAccess.MySql.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly MedTrackerContext _context;

        public DocumentRepository(MedTrackerContext context)
        {
            _context = context;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
        public Document Create(Document document)
        {
            var created = _context.Documents.Add(document).Entity;
            Save();
            return created;
        }

        public bool Delete(int userId, int documentId)

        {
            try
            {
                var document = _context.Documents.Where(doc => doc.Id == documentId && doc.UserId == userId).FirstOrDefault();
                _context.Documents.Remove(document);
                return Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public Document GetById(int id)
        {
            return _context.Documents.Where(x => x.Id == id).FirstOrDefault()!;
        }

        public ICollection<Document> GetMyDocuments(int userId)
        {
            return _context.Documents.Where(x => x.UserId == userId).ToList();
        }

        public bool Update(Document document)
        {
            var oldDoc = _context.Documents.Where(x => x.Id == document.Id).FirstOrDefault();

            _context.Remove(oldDoc);
            _context.Add(document);

            return Save();
        }
    }
}