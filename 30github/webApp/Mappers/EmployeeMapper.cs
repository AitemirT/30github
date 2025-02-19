using webApp.DTOs.Employee;
using webApp.Models;

namespace webApp.Mappers;

public static class EmployeeMapper
{
    public static EmployeeDto ToEmployeeDto(this Employee employee)
    {
        return new EmployeeDto
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email,
            MiddleName = employee.MiddleName,
        };
    }
}