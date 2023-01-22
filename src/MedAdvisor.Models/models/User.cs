namespace MedAdvisor.Models.Models
{
    public class User
    {
        public string Username { get; set; } = string.Empty;
        public byte[] HashedPassword { get; set; }
        public byte[] Salt { get; set; }

    }
}