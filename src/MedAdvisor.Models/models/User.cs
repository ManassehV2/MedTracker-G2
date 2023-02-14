using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedAdvisor.Models.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public byte[] HashedPassword { get; set; }
        public byte[] Salt { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public DateTime CreatedAt { get; set; }
        public enum Gendertypes
        {
            Female,
            Male
        }
        public Gendertypes Gender { get; set; }
        public string Ssn { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
        public bool OrganDonor { get; set; }
        public string Postnr { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Land { get; set; } = string.Empty;
        public string StreetAddress { get; set; } = string.Empty;
        public string TypeOfInsurance { get; set; } = string.Empty;
        public string InsuranceCompany { get; set; } = string.Empty;
        public string AlarmTel { get; set; } = string.Empty;
        public string EmergencyContactName1 { get; set; } = string.Empty;
        public string EmergencyContactPhone1{ get; set; } = string.Empty;
        public string EmergencyContactRel1 { get; set; } = string.Empty;

        public string EmergencyContactName2 { get; set; } = string.Empty;
        public string EmergencyContactPhone2 { get; set; } = string.Empty;
        public string EmergencyContactRel2 { get; set; } = string.Empty;



        public string Other { get; set; } = string.Empty;

        public ICollection<UserAllergy> UserAllergies { get; set; } = null!;

        public ICollection<UserDiagnosis> UserDiagnoses { get; set; } = null!;

        public ICollection<UserMedicine> UserMedicines { get; set; } = null!;

        public ICollection<UserVaccine> UserVaccines { get; set; } = null!;

        public ICollection<Document> Documents { get; set; } = null!;
    }
}