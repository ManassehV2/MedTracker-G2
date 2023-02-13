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
        public Document Create(Document document)
        {
            var created = _context.Documents.Add(document).Entity;
            _context.SaveChanges();
            return created;
        }

        public bool Delete(int userId, int documentId)

        {
            try
            {
                var document = _context.Documents.Where(doc => doc.Id == documentId && doc.UserId == userId).FirstOrDefault();
                if (document == null)
                {
                    throw new Exception("Specified Document doesn't exist");
                }
                _context.Documents.Remove(document);
                return _context.SaveChanges();
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

            if (oldDoc == null)
            {
                throw new Exception("Specified Document doesn't exist");
            }
            _context.Remove(oldDoc);
            _context.Add(document);

            return _context.SaveChanges();
        }
    }
}