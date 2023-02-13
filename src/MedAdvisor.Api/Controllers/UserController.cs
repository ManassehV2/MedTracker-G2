using Microsoft.AspNetCore.Mvc;

using AutoMapper;
using MedAdvisor.DataAccess.MySql;
using MedAdvisor.Models.Models;
using static MedAdvisor.Api.UserProfileData;

namespace MedAdvisor.Api.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
     private readonly IConfiguration _config;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserController(IConfiguration config, IUserRepository userRepository, IMapper mapper)

    {
        _config = config;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    [HttpGet]

    public IActionResult getUser([FromHeader] string Authorization)
    {
        try
        {
            int userId = UserFromToken.getId(Authorization);
            var user = _userRepository.GetUser(userId);
            // UserProfileData userMap = _mapper.Map<UserProfileData>(_userRepository.GetUser(userId));
            
            if (user == null)
            {
                ModelState.AddModelError("", "bad request");
                return BadRequest(ModelState);
            }
            
            return Ok(user);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("Error", ex.Message);
            return BadRequest(ModelState);

        }
        
    }

    [HttpPatch]
    public IActionResult updateUser(UserProfileData profile, [FromHeader] string Authorization)
    {
        
    }

    

   
}