using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using webApp.DTOs.Task;
using webApp.Helpers;
using webApp.Models;
using webApp.Repository;

namespace webApp.Services;

public class TaskService
{
    private readonly ITaskRepository _repository;
    private readonly IMapper _mapper;

    public TaskService(ITaskRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<TaskDto>> GetAllAsync(QueryObj queryObj)
    {
        var tasks = await _repository.GetAllAsync(queryObj);
        return _mapper.Map<List<TaskDto>>(tasks);
    }

    public async Task<TaskDto?> GetByIdAsync(int id)
    {
        var task = await _repository.GetByIdAsync(id);
        if(task == null) return null;
        return _mapper.Map<TaskDto>(task);
    }

    public async Task<TaskDto?> AddAsync(CreateTaskDto createTaskDto)
    {
        var existingTask = await _repository.FindByNameInProjectAsync(createTaskDto.NameOfTask, createTaskDto.ProjectId);
        if (existingTask != null)
        {
            throw new ArgumentException("Задача с таким названием уже существует в проекте");
        }
        var task = _mapper.Map<TheTask>(createTaskDto);
        var result = await _repository.CreateAsync(task);
        if(result == null) return null;
        return _mapper.Map<TaskDto>(result);
    }

    public async Task<TaskDto?> UpdateAsync(int id, UpdateTaskDto updateTaskDto)
    {
        var task = await _repository.UpdateAsync(id, updateTaskDto);
        if(task == null) return null;
        return _mapper.Map<TaskDto>(task);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var result = await _repository.DeleteAsync(id);
        return result != null;
    }
    
}