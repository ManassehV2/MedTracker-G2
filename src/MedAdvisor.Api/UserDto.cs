namespace MedAdvisor.Api;

public class UserDto
{
    public UserDto(string Email, string password)
    {
        this.Email = Email;
        this.Password = password;
    }
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

}