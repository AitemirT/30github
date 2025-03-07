using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using webApp.Repository;
using webApp.Services;

namespace webApp.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProjectEmployee : ControllerBase
{
    private readonly ProjectEmployeeService _projectEmployeeService;

    public ProjectEmployee(ProjectEmployeeService projectEmployeeService)
    {
        _projectEmployeeService = projectEmployeeService;
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddEmployeeToProject([FromQuery] int projectId, [FromQuery] int employeeId)
    {
        try
        {
            string result = await _projectEmployeeService.AddEmployeeToProject(projectId, employeeId);
            return Ok(new { message = result });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "Произошла ошибка не сервере", Details = ex.Message});
        }
    }
    
    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteEmployeeFromProject([FromQuery]int projectId, [FromQuery]int employeeId)
    {
        try
        {
            string result = await _projectEmployeeService.RemoveEmployeeFromProject(projectId, employeeId);
            return Ok(new { Message = result });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }
}