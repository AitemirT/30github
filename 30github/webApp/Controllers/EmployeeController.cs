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
    public async Task<IActionResult> GetEmployee(int id)
    {
        var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
        if(employee == null) return NotFound();
        var employeeDto = employee.ToEmployeeDto();
        return Ok(employeeDto);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateEmployeeAsync([FromBody] CreateEmployeeDto createEmployeeDto)
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);
        var employee = createEmployeeDto.ToEmployeeFromCreateEmployeeDto();
        var createdEmployee = await _employeeRepository.CreateEmployeeAsync(employee);
        return createdEmployee == null ? StatusCode(500, "Не удалось создать сотрудника") : CreatedAtAction(nameof(GetEmployee), new {id = createdEmployee.Id}, employee.ToEmployeeDto());
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateEmployee(int id, [FromBody] UpdateEmployeeDto updateEmployeeDto)
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);
        var employee = await _employeeRepository.UpdateEmployeeAsync(id, updateEmployeeDto);
        return employee == null ? StatusCode(500, "Ну удалось обновить сотрудника") : Ok(employee.ToEmployeeDto());
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        var employee = await _employeeRepository.DeleteEmployeeAsync(id);
        if(employee == null) return NotFound();
        return NoContent();
    }
    
}