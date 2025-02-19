using webApp.DTOs;
using webApp.Models;

namespace webApp.Mappers;

public static class ProjectMapper
{
    public static ProjectDto ToProjectDto(this Project project)
    {
        return new ProjectDto
        {
            Id = project.Id,
            Name = project.Name,
            CustomerCompanyId = project.CustomerCompanyId,
            CustomerCompanyName = project.CustomerCompany?.Name ?? string.Empty,
            ExecutorCompanyId = project.ExecutorCompanyId,
            ExecutorCompanyName = project.ExecutorCompany?.Name ?? string.Empty,
            ProjectManagerId = project.ProjectManagerId,
            ProjectManagerName = project?.ProjectManager != null
                ? $"{project.ProjectManager.FirstName} {project.ProjectManager.LastName}"
                : string.Empty,
        };
    }
    
}