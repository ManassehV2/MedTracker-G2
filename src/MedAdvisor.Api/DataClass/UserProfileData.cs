namespace MedAdvisor.Api;

public class UserProfileData
{
    public UserProfileData(
    int Id,
    string FirstName,
    string LastName,
    DateTime DateOfBirth,
    Gendertypes Gender,
    string Ssn,
    string Nationality,
    string Telephone,
    bool OrganDonor,
    string Postnr,
    string City,
    string Land,
    string StreetAddress,
    string TypeOfInsurance,
    string InsuranceCompany,
    string AlarmTel,
    string EmergencyContactName1,
    string EmergencyContactPhone1,
    string EmergencyContactRel1,
    string EmergencyContactName2,
    string EmergencyContactPhone2,
    string EmergencyContactRel2,
    string Other
    )
    {
        this.Id = Id;
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.DateOfBirth = DateOfBirth;
        this.Gender = Gender;
        this.Ssn = Ssn;
        this.Nationality = Nationality;
        this.Telephone = Telephone;
        this.OrganDonor = OrganDonor;
        this.Postnr = Postnr;
        this.City = City;
        this.Land = Land;
        this.StreetAddress = StreetAddress;
        this.TypeOfInsurance = TypeOfInsurance;
        this.InsuranceCompany = InsuranceCompany;
        this.AlarmTel = AlarmTel;
        this.EmergencyContactName1 = EmergencyContactName1;
        this.EmergencyContactPhone1 = EmergencyContactPhone1;
        this.EmergencyContactRel1 = EmergencyContactRel1;
        this.EmergencyContactName2 = EmergencyContactName2;
        this.EmergencyContactPhone2 = EmergencyContactPhone2;
        this.EmergencyContactRel2 = EmergencyContactRel2;
        this.Other = Other;
    }

    public int Id { get; set; }
    public string? FirstName { get; set; }

    public string? LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }

    public DateTime? CreatedAt { get; set; }
    public enum Gendertypes
    {
        Female,
        Male
    }
    public Gendertypes? Gender { get; set; }
    public string? Ssn { get; set; }
    public string? Nationality { get; set; }
    public string? Telephone { get; set; }
    public bool? OrganDonor { get; set; }
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
}
