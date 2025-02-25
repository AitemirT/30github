using webApp.DTOs.Employee;
using webApp.Models;

namespace webApp.Repository;

public interface IEmployeeRepository
{
    Task<List<Employee>> GetEmployeesAsync();
    Task<Employee?> GetEmployeeByIdAsync(int id);
    Task<Employee?> CreateEmployeeAsync(Employee employee);
    Task<Employee?> UpdateEmployeeAsync(int id, UpdateEmployeeDto updateEmployeeDto);
    Task<Employee?> DeleteEmployeeAsync(int id);
}