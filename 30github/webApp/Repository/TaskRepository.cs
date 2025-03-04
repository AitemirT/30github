using Microsoft.EntityFrameworkCore;
using webApp.Data;
using webApp.DTOs.Task;
using webApp.Helpers;
using webApp.Models;

namespace webApp.Repository;

public class TaskRepository : ITaskRepository
{
    private readonly ApplicationDbContext _context;

    public TaskRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<TheTask>> GetAllAsync(QueryObj queryObj)
    {
        var tasks = _context.TheTasks
            .Include(t => t.Project)
            .Include(t => t.Executor)
            .Include(t => t.Author)
            .AsQueryable();
        if (queryObj.StatusOfTheTask.HasValue)
        {
            tasks = tasks.Where(t => t.StatusOfTheTask == queryObj.StatusOfTheTask.Value);
        }

        if (queryObj.SortByPriority.HasValue && queryObj.SortByPriority.Value)
        {
            tasks = tasks.OrderByDescending(t => t.PriorityOfTheTask);
        }

        return await tasks.ToListAsync();
    }

    public async Task<TheTask?> GetByIdAsync(int id)
    {
        return await _context.TheTasks
            .Include(t => t.Project)
            .Include(t => t.Executor)
            .Include(t => t.Author)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<TheTask?> CreateAsync(TheTask task)
    {
        await _context.TheTasks.AddAsync(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task<TheTask?> UpdateAsync(int id, UpdateTaskDto updateTaskDto)
    {
        var existingTask = await _context.TheTasks
            .Include(t => t.Project)
            .Include(t => t.Executor)
            .Include(t => t.Author)
            .FirstOrDefaultAsync(t => t.Id == id);
        if(existingTask == null) return null;
        existingTask.NameOfTask = updateTaskDto.NameOfTask;
        existingTask.Description = updateTaskDto.Description;
        existingTask.ProjectId = updateTaskDto.ProjectId;
        existingTask.ExecutorId = updateTaskDto.ExecutorId;
        existingTask.AuthorId = updateTaskDto.AuthorId;
        existingTask.StatusOfTheTask = updateTaskDto.StatusOfTheTask;
        existingTask.PriorityOfTheTask = updateTaskDto.PriorityOfTheTask;
        await _context.SaveChangesAsync();
        return existingTask;
    }

    public async Task<TheTask?> DeleteAsync(int id)
    {
        var task = await _context.TheTasks.FindAsync(id);
        if(task == null) return null;
        _context.TheTasks.Remove(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task<TheTask?> FindByNameInProjectAsync(string taskName, int projectId)
    {
        return await _context.TheTasks
            .FirstOrDefaultAsync(t => t.NameOfTask == taskName && t.ProjectId == projectId);
    }
}