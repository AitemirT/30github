using webApp.DTOs;
using webApp.Models;

namespace webApp.Repository;

public interface IProjectRepository
{
    Task<List<Project>> GetAllProjectsAsync();
    Task<Project?> GetProjectByIdAsync(int id);
    Task<Project> CreateProjectAsync(Project project);
    Task<Project?> UpdateProjectAsync(int id, UpdateProjectDto updateProjectDto);
    Task<Project?> DeleteProjectAsync(int id);
}