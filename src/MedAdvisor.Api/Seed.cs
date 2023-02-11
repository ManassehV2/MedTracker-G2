using MedAdvisor.Models.Models;
using MedAdvisor.DataAccess.MySql;
using System.Security.Cryptography;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace MedAdvisor.Api
{
    public class Seed
    {
        private readonly MedTrackerContext _context;

        public Seed(MedTrackerContext context)
        {
            _context = context;
        }
        public void SeedDataContext()
        {
            if (!_context.Users.Any())
            {
                var encoder = new HMACSHA512();
                byte[] passwordSalt = encoder.Key;
                byte[] passwordHash = encoder.ComputeHash(System.Text.Encoding.UTF8.GetBytes("Password"));
                var user = new User()
                {
                    Username = "Henok",
                    HashedPassword = passwordHash,
                    Salt = passwordSalt,
                    FirstName = "Henok",
                    LastName = "Matheas"

                };

                var diagnoses = new List<Diagnosis>(){
                    new Diagnosis()
                    {
                        Name = "Diagnosis1",
                        Code = "232323"
                    },
                    new Diagnosis()
                    {
                        Name = "Diagnosis2",
                        Code = "2324323"
                    },
                    new Diagnosis()
                    {
                        Name = "Diagnosis3",
                        Code = "2323243"
                    },
                };

                _context.Users.Add(user);
                _context.Diagnosis.AddRange(diagnoses);

                _context.SaveChanges();
            }
        }
    }
}