using webApp.DTOs.Task;
using webApp.Models;

namespace webApp.Repository;

public interface ITaskRepository
{
    Task<List<TheTask>> GetAllAsync();
    Task<TheTask?> GetByIdAsync(int id);
    Task<TheTask?> CreateAsync(TheTask task);
    Task<TheTask?> UpdateAsync(int id, UpdateTaskDto updateTaskDto);
    Task<TheTask?> DeleteAsync(int id);
}