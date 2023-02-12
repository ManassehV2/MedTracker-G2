namespace MedAdvisor.Api;

public class UserDto
{
    public UserDto(string email, string password)
    {
        this.Email = email;
        this.Password = password;
    }
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

}