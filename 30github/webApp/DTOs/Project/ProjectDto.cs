namespace webApp.DTOs;

public class ProjectDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Priority { get; set; }
    public int CustomerCompanyId { get; set; }
    public string CustomerCompanyName { get; set; }
    public int ExecutorCompanyId { get; set; }
    public string ExecutorCompanyName { get; set; }
    public int ProjectManagerId { get; set; }
    public string ProjectManagerName { get; set; }
    
}