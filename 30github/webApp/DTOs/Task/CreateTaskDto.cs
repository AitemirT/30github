using System.ComponentModel.DataAnnotations;
using webApp.Controllers.Enums;

namespace webApp.DTOs.Task;

public class CreateTaskDto
{
    [Required(ErrorMessage = "Название задачи обязательно к заполнению")]
    public string NameOfTask { get; set; }
    [Required(ErrorMessage = "Описание задачи обязательно к заполнению")]
    public string Description { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Приоритет не может быть меньше 0")]
    public int PriorityOfTheTask { get; set; }
    [Required(ErrorMessage = "Статус задачи обязателен")]
    [EnumDataType(typeof(StatusOfTheTask), ErrorMessage = "Статус задачи не может быть пустым")]
    public StatusOfTheTask StatusOfTheTask { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Автор задачи обязателен")]
    public int AuthorId { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Исполнитель задачи обязателен")]

    public int ExecutorId { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Проект задачи обязателен")]

    public int ProjectId { get; set; }
}