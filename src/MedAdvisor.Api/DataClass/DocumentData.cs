using static MedAdvisor.Models.Models.Document;

namespace MedAdvisor.Api.DataClass
{
    public class DocumentData
    {

        public IFormFile file { get; set; }
        public string title { get; set; }

        public Documenttypes type { get; set; }

        public string? description { get; set; }

    }
}