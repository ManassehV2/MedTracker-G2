using Microsoft.AspNetCore.Mvc;
using MedAdvisor.Api.Models;
using MedAdvisor.Api;
using System.Security.Cryptography;

namespace MedAdvisor.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    public static UserModel user = new UserModel();

    [HttpPost("signup")]
    public ActionResult<UserModel> signup(UserDto request)
    {
        string usersPass = request.Password;

        var encoder = new HMACSHA512();
        byte[] passwordSalt = encoder.Key;
        byte[] passwordHash = encoder.ComputeHash(System.Text.Encoding.UTF8.GetBytes(request.Password));
        
        user.Username = request.Username;
        user.Salt = passwordSalt;
        user.HashedPassword = passwordHash;

        return Ok(user);
    }

    [HttpPost("login")]
    public ActionResult<string> login(UserDto request)
    {
        if (user.Username != request.Username)
            return BadRequest("Invalid Credentials");

        var encoder = new HMACSHA512(user.Salt);
        var computedHash = encoder.ComputeHash(System.Text.Encoding.UTF8.GetBytes(request.Password));
        if (!computedHash.SequenceEqual(user.HashedPassword))
            return BadRequest("Invalid Credentials!");

        
        return Ok("some token");
    }

    [HttpGet]
    public ActionResult working()
    {
        return Ok();
    }
    // private static readonly string[] Summaries = new[]
    // {
    //     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    // };

    // private readonly ILogger<WeatherForecastController> _logger;

    // public WeatherForecastController(ILogger<WeatherForecastController> logger)
    // {
    //     _logger = logger;
    // }

    // [HttpGet(Name = "GetWeatherForecast")]
    // public IEnumerable<WeatherForecast> Get()
    // {
    //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //     {
    //         Date = DateTime.Now.AddDays(index),
    //         TemperatureC = Random.Shared.Next(-20, 55),
    //         Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    //     })
    //     .ToArray();
    // }
}
