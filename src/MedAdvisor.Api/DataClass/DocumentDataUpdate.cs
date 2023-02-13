using static MedAdvisor.Models.Models.Document;

namespace MedAdvisor.Api.DataClass
{
    public class DocumentDataUpdate
    {

        public IFormFile file { get; set; }
        public string title { get; set; }
        public int Id { get; set; }
        public Documenttypes type { get; set; }

        public string? description { get; set; }

    }
}