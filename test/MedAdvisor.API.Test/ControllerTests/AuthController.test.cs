using FakeItEasy;
using FluentAssertions;
using MedAdvisor.Api;
using MedAdvisor.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace MedAdvisor.API.Test.ControllerTests;

public class AuthControllerTests
{
    public readonly IConfiguration _config;
    public AuthControllerTests()
    {
         _config = A.Fake<IConfiguration>();

    }

    [Fact]
    public void AuthController_Signup_ReturnOK()
    {
        //arrange
        var authController = new AuthController(_config);
        var userDto = A.Fake<UserDto>();

        //Act
        var result = authController.signup(userDto);

        //Assert
        result.Should().NotBeNull();
        
        result.Should().BeOfType(typeof(OkResult));
        

    }
    [Fact]
    public void AuthController_Login_ReturnOK()
    {
        //Arrange
        var authController = new AuthController(_config);
        var userDto = A.Fake<UserDto>();

        //Act
        authController.signup(userDto);
        var result = authController.login(userDto);

        //Assert
        result.Should().NotBeNull();

        result.Should().BeOfType(typeof(ActionResult<string>));


    }
    
}