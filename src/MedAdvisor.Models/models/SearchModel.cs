using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedAdvisor.Models.Models
{
    public class SearchModel
    {
        public string Type { get; set; }
        public string Query { get; set; }
    }

}