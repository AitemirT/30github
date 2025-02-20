using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApp.Data;
using webApp.Mappers;
using webApp.Models;

namespace webApp.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CompanyController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CompanyController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Company>>> GetCompany()
    {
        var companies = await _context.Companies
            .Include(c => c.CustomerProjects)
            .Include(c => c.ExecutorProjects).ToListAsync();
        var companiesDto = companies.Select(c => c.ToCompanyDto()).ToList();
        return Ok(companiesDto);
    }
}