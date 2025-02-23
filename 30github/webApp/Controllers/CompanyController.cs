using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApp.Data;
using webApp.DTOs.Company;
using webApp.Mappers;
using webApp.Models;
using webApp.Repository;

namespace webApp.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CompanyController : ControllerBase
{
    private readonly ICompanyRepository _companyRepository;

    public CompanyController(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetCompanies()
    {
        var companies = await _companyRepository.GetAllCompaniesAsync();
        var companiesDto = companies.Select(c => c.ToCompanyDto());
        return Ok(companiesDto);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCompanyById(int id)
    {
        Company? company = await _companyRepository.GetCompanyByIdAsync(id);
        return company == null ? NotFound() : Ok(company.ToCompanyDto());
    }

    public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyDto createCompanyDto)
    {
        if(!ModelState.IsValid) return BadRequest();
        var company = createCompanyDto.ToCompanyFromCreate();
        var result = await _companyRepository.CreateCompanyAsync(company);
        return result == null ? StatusCode(500, "Не удалось сохранить компанию") : CreatedAtAction(nameof(GetCompanyById), new { id = company.Id }, result.ToCompanyDto());
    }

    public async Task<IActionResult> UpdateCompany(int id, [FromBody] UpdateCompanyDto updateCompanyDto)
    {
        if(!ModelState.IsValid) return BadRequest();
        var company = await _companyRepository.UpdateCompanyAsync(id, updateCompanyDto);
        return company == null ? NotFound() : Ok(company.ToCompanyDto());
    }

    public async Task<IActionResult> DeleteCompany(int id)
    {
        var company = await _companyRepository.DeleteCompanyAsync(id);
        if(company == null) return NotFound();
        return NoContent();
    }
}