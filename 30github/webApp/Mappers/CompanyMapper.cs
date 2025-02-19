using webApp.DTOs.Company;
using webApp.Models;

namespace webApp.Mappers;

public static class CompanyMapper
{
    public static CompanyDto ToCompanyDto(this Company company)
    {
        return new CompanyDto
        {
            Id = company.Id,
            Name = company.Name,
        };
    }
}