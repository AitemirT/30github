using System.ComponentModel.DataAnnotations;

namespace webApp.DTOs.Company;

public class UpdateCompanyDto
{
    [Required(ErrorMessage = "Название компании обязательно к заполнению")]
    public string Name { get; set; }
}