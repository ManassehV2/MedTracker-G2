
using System.Net;
using FakeItEasy;
using FluentAssertions;
using MedAdvisor.Api;
using MedAdvisor.Api.Controllers;
using MedAdvisor.DataAccess.MySql;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace MedAdvisor.API.Test;

public class AuthControllerTests
{
    public readonly IConfiguration _config;
    public readonly IUserRepository _repository;
    public AuthControllerTests()
    {
        _config = A.Fake<IConfiguration>();
        _repository = A.Fake<IUserRepository>();

    }

    [Fact]
    public void AuthController_Signup_ReturnOK()
    {
        //arrange
        var authController = new AuthController(_config,_repository);
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
        var authController = new AuthController(_config,_repository);
        var userDto = A.Fake<UserDto>();

        //Act
        var result = authController.login(userDto);

        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(OkResult));
        

    }

    [Fact]
    public void AuthController_LoginWithWrongUsername_ReturnBadRequest()
    {
        //Arrange
        var authController = new AuthController(_config,_repository);
        var userDto = A.Fake<UserDto>();

        //Act
        authController.signup(userDto);

        userDto.Email = "newEmail2@email.com";
        var result = authController.login(userDto);

        //Assert
        result.Should().NotBeNull();

        result.Should().BeOfType(typeof(BadRequestObjectResult));

    }
    [Fact]
    public void AuthController_LoginWithWrongPassword_ReturnBadRequest()
    {
        //Arrange
        var authController = new AuthController(_config,_repository);
        var userDto = A.Fake<UserDto>();

        //Act
        authController.signup(userDto);

        userDto.Password = "newPassword";
        var result = authController.login(userDto);

        //Assert
        result.Should().NotBeNull();

        result.Should().BeOfType(typeof(BadRequestObjectResult));

    }

}
