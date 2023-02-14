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
    public IActionResult updateUser([FromHeader] string Authorization,UserProfileData profile)
    {
        try
        {
            int userId = UserFromToken.getId(Authorization);
            var newUser = new User()
            {
                Id = profile.Id,
                FirstName = profile.FirstName,
                LastName = profile.LastName,

                DateOfBirth = profile.DateOfBirth,

                Gender = (User.Gendertypes)(Gendertypes)profile.Gender,
                Ssn = profile.Ssn,
                Nationality = profile.Nationality,
                Telephone = profile.Telephone,

                OrganDonor = profile.OrganDonor,

                Postnr = profile.Postnr,
                City = profile.City,
                Land = profile.Land,

                StreetAddress = profile.StreetAddress,

                TypeOfInsurance = profile.TypeOfInsurance,
                InsuranceCompany = profile.InsuranceCompany,
                AlarmTel = profile.AlarmTel,

                EmergencyContactName1 = profile.EmergencyContactName1,

                EmergencyContactPhone1 = profile.EmergencyContactPhone1,
                EmergencyContactRel1 = profile.EmergencyContactRel1,
                EmergencyContactName2 = profile.EmergencyContactName2,

                EmergencyContactPhone2 = profile.EmergencyContactPhone2,
                EmergencyContactRel2 = profile.EmergencyContactRel2,
                Other = profile.Other,

            };

            bool result = _userRepository.UpdateUser(userId, newUser);

            if (!result)
            {
                ModelState.AddModelError("", "bad request");
                return BadRequest(ModelState);

            }

            return Ok();
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);

        }
    }
}