using Microsoft.AspNetCore.Mvc;
using webApp.DTOs.Employee;
using webApp.Mappers;
using webApp.Repository;

namespace webApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{ 
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllEmployeesAsync()
    {
        var employees = await _employeeRepository.GetEmployeesAsync();
        var employeesDto = employees.Select(e => e.ToEmployeeDto());
        return Ok(employeesDto);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetEmployeeByIdAsync(int id)
    {
        var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
        if(employee == null) return NotFound();
        var employeeDto = employee.ToEmployeeDto();
        return Ok(employeeDto);
    }
}