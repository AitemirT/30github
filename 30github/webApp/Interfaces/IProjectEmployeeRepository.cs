namespace webApp.Repository;

public interface IProjectEmployeeRepository
{
    Task AddEmployeeToProjectAsync(int projectId, int employeeId);
    Task RemoveEmployeeFromProjectAsync(int projectId, int employeeId);
    Task<bool> ProjectEmployeeExistsAsync(int projectId, int employeeId);
}