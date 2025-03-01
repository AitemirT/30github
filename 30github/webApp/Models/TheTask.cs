using webApp.Controllers.Enums;

namespace webApp.Models;

public class TheTask
{
    public int Id { get; set; }
    public string NameOfTask { get; set; }
    public string Description { get; set; }
    public int PriorityOfTheTask { get; set; }
    public StatusOfTheTask StatusOfTheTask { get; set; }
    public int AuthorId { get; set; }
    public int ExecutorId { get; set; }
    public Employee Executor { get; set; }
    public Employee Author { get; set; }
    public int ProjectId { get; set; }
    public Project Project { get; set; }
}