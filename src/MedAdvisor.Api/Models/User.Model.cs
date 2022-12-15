namespace MedAdvisor.Api.Models;

public class UserModel
{
    public string Username {get; set;} = string.Empty;
    public byte[] HashedPassword {get; set;}
    public byte[] Salt { get; set; }

} 