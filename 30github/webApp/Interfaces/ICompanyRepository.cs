using webApp.DTOs.Company;
using webApp.Models;

namespace webApp.Repository;

public interface ICompanyRepository
{
    Task<List<Company>> GetAllCompaniesAsync();
    Task<Company?> GetCompanyByIdAsync(int id);
    Task<Company> CreateCompanyAsync(Company company);
    Task<Company?> UpdateCompanyAsync(int id, UpdateCompanyDto updateCompanyDto);
    Task<Company?> DeleteCompanyAsync(int id);
}