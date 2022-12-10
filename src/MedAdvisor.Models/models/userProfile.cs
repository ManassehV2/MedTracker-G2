namespace MedAdvisor.Models;
public class userProfile
{
    public string userId{get;set;}
    public string FirstName { get; set;}
    public string SecondName { get; set;}
    public string dateofbirth{ get; set;}
    public enum Gendertypes
    {
        Female,
        Male
    }
    public Gendertypes Gender{ get; set;}
    public string ssn {get; set;}
    public string Nationality { get; set;}
    public string Telephone {get;set;}
    public bool organDonor{ get; set;}
    public string postnr{get; set;}
    public string city{get; set;}
    public string land{ get; set;}
    public string street_address{ get; set;}
    public string typeofinsurance{ get; set;}
    public string insurance_company { get; set;}
    public string AlarmTel{ get; set;}
    public string EmergencyContacts {get; set;}
    public string other {get; set;}
}
