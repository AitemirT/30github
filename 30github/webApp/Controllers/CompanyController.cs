using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApp.Data;
using webApp.DTOs.Company;
using webApp.Mappers;
using webApp.Models;
using webApp.Repository;
using webApp.Services;

namespace webApp.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CompanyController : ControllerBase
{
    private readonly CompanyService _companyService;

    public CompanyController(CompanyService companyService)
    {
       _companyService = companyService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCompanies()
    {
        var companies = await _companyService.GetAllCompaniesAsync();
        return Ok(companies);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCompanyById(int id)
    {
        var company = await _companyService.GetCompanyByIdAsync(id);
        return company == null ? NotFound() : Ok(company);
    }
    [HttpPost]
    public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyDto createCompanyDto)
    {
        if(!ModelState.IsValid) return BadRequest();
        var company = await _companyService.CreateCompanyAsync(createCompanyDto);
        return company == null ? StatusCode(500, "Не удалось создать компанию") : CreatedAtAction(nameof(GetCompanyById), new { id = company.Id }, company);
    }
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCompany(int id, [FromBody] UpdateCompanyDto updateCompanyDto)
    {
        if(!ModelState.IsValid) return BadRequest();
        var company = await _companyService.UpdateCompanyAsync(id, updateCompanyDto);
        return company == null ? NotFound() : Ok(company);
    }
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCompany(int id)
    {
        var company = await _companyService.DeleteCompanyAsync(id);
        return company ? NoContent() : NotFound();
    }
}