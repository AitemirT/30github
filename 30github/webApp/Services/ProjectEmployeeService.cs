using webApp.Repository;

namespace webApp.Services;

public class ProjectEmployeeService
{
    private readonly IProjectEmployeeRepository _projectEmployeeRepository;

    public ProjectEmployeeService(IProjectEmployeeRepository projectEmployeeRepository)
    {
        _projectEmployeeRepository = projectEmployeeRepository;
    }

    public async Task<string> AddEmployeeToProject(int projectId, int employeeId)
    {
        if (await _projectEmployeeRepository.ProjectEmployeeExistsAsync(projectId, employeeId))
        {
            throw new ArgumentException("Этот сотрудник уже добавлен в данный проект");
        }
        await _projectEmployeeRepository.AddEmployeeToProjectAsync(projectId, employeeId);
        return "Сотрудник успешно добавлен в проект";
    }

    public async Task<string> RemoveEmployeeFromProject(int projectId, int employeeId)
    {
        await _projectEmployeeRepository.RemoveEmployeeFromProjectAsync(projectId, employeeId);
        return "Сотрудник успешно удален из проекта";
    }
}