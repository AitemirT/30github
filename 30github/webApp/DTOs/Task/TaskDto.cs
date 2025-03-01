using webApp.Controllers.Enums;

namespace webApp.DTOs.Task;

public class TaskDto
{
    public int Id { get; set; }
    public string NameOfTask { get; set; }
    public string Description { get; set; }
    public int PriorityOfTheTask { get; set; }
    public StatusOfTheTask StatusOfTheTask { get; set; }
    public int AuthorId { get; set; }
    public string AuthorName { get; set; }
    public int ExecutorId { get; set; }
    public string ExecutorName { get; set; }
    public int ProjectId { get; set; }
}