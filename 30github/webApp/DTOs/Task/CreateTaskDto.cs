using webApp.Controllers.Enums;

namespace webApp.DTOs.Task;

public class CreateTaskDto
{
    public string NameOfTask { get; set; }
    public string Description { get; set; }
    public int PriorityOfTheTask { get; set; }
    public StatusOfTheTask StatusOfTheTask { get; set; }
    public int AuthorId { get; set; }
    public int ExecutorId { get; set; }
    public int ProjectId { get; set; }
}