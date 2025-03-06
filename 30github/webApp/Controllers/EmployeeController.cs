using Microsoft.AspNetCore.Mvc;
using webApp.DTOs.Employee;
using webApp.Mappers;
using webApp.Repository;
using webApp.Services;

namespace webApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{ 
    private readonly EmployeeService _employeeService;

    public EmployeeController(EmployeeService employeeService)
    {
       _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllEmployeesAsync()
    {
        var employees = await _employeeService.GetEmployeesAsync();
        return Ok(employees);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetEmployee(int id)
    {
        var employee = await _employeeService.GetEmployeeAsync(id);
        return employee == null ? NotFound() : Ok(employee);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateEmployeeAsync([FromBody] CreateEmployeeDto createEmployeeDto)
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);
        var employeeDto = await _employeeService.CreateEmployeeAsync(createEmployeeDto);
        return employeeDto == null ? StatusCode(500, "Не удалось создать сотрудника") : CreatedAtAction(nameof(GetEmployee), new {id = employeeDto.Id}, employeeDto);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateEmployee(int id, [FromBody] UpdateEmployeeDto updateEmployeeDto)
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);
        var employeeDto = await _employeeService.UpdateEmployeeAsync(id, updateEmployeeDto);
        return employeeDto == null ? StatusCode(500, "Ну удалось обновить сотрудника") : Ok(employeeDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        var employee = await _employeeService.DeleteEmployeeAsync(id);
        return employee == null ? NotFound() : Ok(employee);
    }
    
}