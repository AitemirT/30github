using webApp.DTOs.Employee;
using webApp.Mappers;
using webApp.Repository;

namespace webApp.Services;

public class EmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<List<EmployeeDto>> GetEmployeesAsync()
    {
        var employees = await _employeeRepository.GetEmployeesAsync();
        return employees.ConvertAll(e => e.ToEmployeeDto());
    }

    public async Task<EmployeeDto?> GetEmployeeAsync(int id)
    {
        var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
        return employee?.ToEmployeeDto();
    }

    public async Task<EmployeeDto?> CreateEmployeeAsync(CreateEmployeeDto createEmployeeDto)
    {
        var employee = createEmployeeDto.ToEmployeeFromCreateEmployeeDto();
        var result = await _employeeRepository.CreateEmployeeAsync(employee);
        return result?.ToEmployeeDto();
    }

    public async Task<EmployeeDto> UpdateEmployeeAsync(int id, UpdateEmployeeDto updateEmployeeDto)
    {
        var employee = await _employeeRepository.UpdateEmployeeAsync(id, updateEmployeeDto);
        return employee?.ToEmployeeDto();
    }

    public async Task<bool?> DeleteEmployeeAsync(int id)
    {
        var result = await _employeeRepository.DeleteEmployeeAsync(id);
        return result != null;
    }
}