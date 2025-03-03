using webApp.DTOs.Task;
using webApp.Helpers;
using webApp.Models;

namespace webApp.Repository;

public interface ITaskRepository
{
    Task<List<TheTask>> GetAllAsync(QueryObj query);
    Task<TheTask?> GetByIdAsync(int id);
    Task<TheTask?> CreateAsync(TheTask task);
    Task<TheTask?> UpdateAsync(int id, UpdateTaskDto updateTaskDto);
    Task<TheTask?> DeleteAsync(int id);
}