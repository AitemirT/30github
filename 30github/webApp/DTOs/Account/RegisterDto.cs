using System.ComponentModel.DataAnnotations;

namespace webApp.DTOs.Account;

public class RegisterDto
{
    [Required(ErrorMessage = "Имя пользователя обязательно к заполнению")]
    public string? UserName { get; set; }
    [Required(ErrorMessage = "Почта обязательна к заполнению")]
    [EmailAddress(ErrorMessage = "Не правильный формат электронной почты")]
    public string? Email { get; set; }
    [Required(ErrorMessage = "Пароль обязателен к заполнению")]
    public string? Password { get; set; }
    
}