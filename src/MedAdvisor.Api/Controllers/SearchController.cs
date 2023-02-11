using Microsoft.AspNetCore.Mvc;

using System.Security.Cryptography;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using MedAdvisor.Models.Models;
using MedAdvisor.DataAccess.MySql.Interfaces;

namespace MedAdvisor.Api.Controllers;

[ApiController]
[Route("api/search")]
public class SearchController : ControllerBase
{
    private readonly IMedicineRepository _medicineRepository;
    private readonly IAllergyRepository _allergyRepository;
    private readonly IDiagnosisRepository _diagnosisRepository;
    private readonly IVaccineRepository _vaccineRepository;

    public SearchController(IMedicineRepository medicineRepository, IAllergyRepository allergyRepository, IDiagnosisRepository diagnosisRepository, IVaccineRepository vaccineRepository)
    {
        _medicineRepository = medicineRepository;
        _allergyRepository = allergyRepository;
        _diagnosisRepository = diagnosisRepository;
        _vaccineRepository = vaccineRepository;
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<object>>> Search(SearchModel search)
    {
        if (search.Type.ToLower() == "medicine")
        {
            var medicines = await _medicineRepository.GetAllergies(search.Query);
            return Ok(medicines);
        }
        else if (search.Type.ToLower() == "allergy")
        {
            var allergies = await _allergyRepository.GetAllergies(search.Query);
            return Ok(allergies);
        }
        else if (search.Type.ToLower() == "diagnosis")
        {
            var diagnoses = await _diagnosisRepository.GetAllergies(search.Query);
            return Ok(diagnoses);
        }
        else if (search.Type.ToLower() == "vaccine")
        {
            var vaccines = await _vaccineRepository.GetAllergies(search.Query);
            return Ok(vaccines);
        }
        else
        {
            return BadRequest("Invalid search type");
        }
    }
}
