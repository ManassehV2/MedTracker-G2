using Microsoft.AspNetCore.Mvc;
using MedAdvisor.Api.Models;
using System.Security.Cryptography;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace MedAdvisor.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    public static readonly UserModel user = new UserModel();
    private readonly IConfiguration _config;

    public AuthController(IConfiguration config)
    {
        _config = config;
    }

    [HttpPost("signup")]
    public IActionResult signup(UserDto request)
    {
        var encoder = new HMACSHA512();
        byte[] passwordSalt = encoder.Key;
        byte[] passwordHash = encoder.ComputeHash(System.Text.Encoding.UTF8.GetBytes(request.Password));
        
        user.Username = request.Username;
        user.Salt = passwordSalt;
        user.HashedPassword = passwordHash;

        return Ok();
    }

    [HttpPost("login")]
    public IActionResult login(UserDto request)
    {
        if (user.Username != request.Username)
            return BadRequest("Invalid Credentials!");

        var encoder = new HMACSHA512(user.Salt);
        var computedHash = encoder.ComputeHash(System.Text.Encoding.UTF8.GetBytes(request.Password));
        if (!computedHash.SequenceEqual(user.HashedPassword))
            return BadRequest("Invalid Credentials!");

        
        return Ok(CreateToken(user));
    }

    public string CreateToken(UserModel user)
    {
        List<Claim> claims = new List<Claim>{
            new Claim(ClaimTypes.Name, user.Username)
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
