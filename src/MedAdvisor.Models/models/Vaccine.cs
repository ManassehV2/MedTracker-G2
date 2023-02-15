using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedAdvisor.Models.Models
{
    public class Vaccine
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public ICollection<UserVaccine> UserVaccines { get; set; } = null!;

    }
}
