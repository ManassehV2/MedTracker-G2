using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedAdvisor.Models.Models
{
    public class FileContent
    {
        public int Id { get; set; }
        public string FileName { get; set; }
    }
}