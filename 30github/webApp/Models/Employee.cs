namespace webApp.Models;

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string Email { get; set; }
    public List<Project> Projects { get; set; } = new List<Project>();
    public List<ProjectEmployee> ProjectEmployees { get; set; } = new List<ProjectEmployee>();
    public List<TheTask> Tasks { get; set; } = new List<TheTask>();
}