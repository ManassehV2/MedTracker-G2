using Microsoft.AspNetCore.Mvc;

using System.Security.Cryptography;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using MedAdvisor.Models.Models;
using MedAdvisor.DataAccess.MySql;

namespace MedAdvisor.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    
    private readonly IConfiguration _config;
    private readonly IUserRepository _userRepository;

    public AuthController(IConfiguration config,IUserRepository userRepository)

    {
        _config = config;
        _userRepository = userRepository;
    }

    public User createUserDto(UserDto request){
        var encoder = new HMACSHA512();
        byte[] passwordSalt = encoder.Key;
        byte[] passwordHash = encoder.ComputeHash(System.Text.Encoding.UTF8.GetBytes(request.Password));
        var newUser = new User(){
            Email = request.Email,
            HashedPassword = passwordHash,
            Salt = passwordSalt
        };

        return newUser;
    }


    [HttpPost("signup")]
    public IActionResult signup(UserDto request)
    {
        var newUser = createUserDto(request);

        _userRepository.CreateUser(newUser);

        return Ok();
    }

     string CreateToken(User user)
    {
        List<Claim> claims = new List<Claim>{
            new Claim(ClaimTypes.Name, user.Id.ToString())
        };

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:JWTToken").Value != "" ? _config.GetSection("AppSettings:JWTToken").Value : "some key which Is strong" ));

        var cred = new SigningCredentials( key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires : DateTime.Now.AddDays(45),
            signingCredentials: cred
        );  
        string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

        return jwtToken;
    }
    }
}
