using System.ComponentModel.DataAnnotations;

namespace webApp.DTOs.Company;

public class CreateCompanyDto
{
    [Required(ErrorMessage = "Название компании обязательно к заполнению")]
    public string Name { get; set; }
}