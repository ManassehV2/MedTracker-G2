namespace MedAdvisor.Api;

public class UserDto
{
    public UserDto(string username, string password)
    {
        this.Username = username;
        this.Password = password;
    }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

}