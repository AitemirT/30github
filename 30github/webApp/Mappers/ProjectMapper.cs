using webApp.DTOs;
using webApp.DTOs.Employee;
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
            ProjectEmployees = project?.ProjectEmployees
                .Where(pe => pe.Employee != null)
                .Select(pe => new EmployeeDto()
                {
                    Id = pe.Employee.Id,
                    FirstName = pe.Employee.FirstName,
                    LastName = pe.Employee.LastName,
                }).ToList()
        };
    }
    
    public static Project ToProjectFromCreateProjectDto(this CreateProjectDto projectDto)
    {
        return new Project
        {
            Name = projectDto.Name,
            StartDate = projectDto.StartDate,
            EndDate = projectDto.EndDate,
            Priority = projectDto.Priority,
            CustomerCompanyId = projectDto.CustomerCompanyId,
            ExecutorCompanyId = projectDto.ExecutorCompanyId,
            ProjectManagerId = projectDto.ProjectManagerId,
        };
    }
    
}