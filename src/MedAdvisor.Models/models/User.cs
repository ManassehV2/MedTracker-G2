namespace MedAdvisor.Models.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public byte[] HashedPassword { get; set; } = null!;
        public byte[] Salt { get; set; } = null!;

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
        public string? Ssn { get; set; } 
        public string? Nationality { get; set; } 
        public string? Telephone { get; set; } 
        public bool OrganDonor { get; set; }
        public string? Postnr { get; set; } 
        public string? City { get; set; } 
        public string? Land { get; set; } 
        public string? StreetAddress { get; set; } 
        public string? TypeOfInsurance { get; set; } 
        public string? InsuranceCompany { get; set; } 
        public string? AlarmTel { get; set; } 
        public string? EmergencyContactName1 { get; set; } 
        public string? EmergencyContactPhone1 { get; set; } 
        public string? EmergencyContactRel1 { get; set; } 

        public string? EmergencyContactName2 { get; set; } 
        public string? EmergencyContactPhone2 { get; set; } 
        public string? EmergencyContactRel2 { get; set; } 

        public string? Other { get; set; } 

        public ICollection<UserAllergy> UserAllergies { get; set; } = null!;

        public ICollection<UserDiagnosis> UserDiagnoses { get; set; } = null!;

        public ICollection<UserMedicine> UserMedicines { get; set; } = null!;

        public ICollection<UserVaccine> UserVaccines { get; set; } = null!;

        public ICollection<Document> Documents { get; set; } = null!;
    }
}