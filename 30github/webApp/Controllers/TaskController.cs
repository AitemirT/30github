using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webApp.DTOs.Task;
using webApp.Helpers;
using webApp.Models;
using webApp.Repository;

namespace webApp.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITaskRepository _taskRepository;
    private readonly IMapper _mapper;

    public TaskController(ITaskRepository taskRepository, IMapper mapper)
    {
        _taskRepository = taskRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] QueryObj queryObj)
    {
        var tasks = await _taskRepository.GetAllAsync(queryObj);
        if(tasks == null) return NotFound();
        var taskDto = _mapper.Map<IEnumerable<TaskDto>>(tasks);
        return Ok(taskDto);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var task = await _taskRepository.GetByIdAsync(id);
        return task == null ? NotFound() : Ok(_mapper.Map<TaskDto>(task));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateTaskDto createTaskDto)
    {
        if(createTaskDto == null) return BadRequest("Данные отсутствуют");
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var existingTask = await _taskRepository.FindByNameInProjectAsync(createTaskDto.NameOfTask, createTaskDto.ProjectId);
        if(existingTask != null) return BadRequest("Задача с таким названием уже существует в этом проекте");
        var task = _mapper.Map<TheTask>(createTaskDto);
        var createdTask = await _taskRepository.CreateAsync(task);
        return createdTask == null ? StatusCode(500, "Не удалось создать задачу") : CreatedAtAction(nameof(Get), new { id = createdTask.Id }, _mapper.Map<TaskDto>(createdTask));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateTaskDto updateTaskDto)
    {
        if(updateTaskDto == null) return BadRequest("Данные отсутствуют");
        if (!ModelState.IsValid) return BadRequest();
        var task = await _taskRepository.UpdateAsync(id, updateTaskDto);
        return task == null ? NotFound() : Ok(_mapper.Map<TaskDto>(task));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var task = await _taskRepository.DeleteAsync(id);
        return task == null ? NotFound() : NoContent();
    }
}