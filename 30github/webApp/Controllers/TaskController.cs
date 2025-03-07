using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webApp.DTOs.Task;
using webApp.Helpers;
using webApp.Models;
using webApp.Repository;
using webApp.Services;

namespace webApp.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly TaskService _taskService;

    public TaskController(TaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] QueryObj queryObj)
    {
        return Ok(await _taskService.GetAllAsync(queryObj));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var task = await _taskService.GetByIdAsync(id);
        return task == null ? NotFound() : Ok(task);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateTaskDto createTaskDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        try
        {
            var task = await _taskService.AddAsync(createTaskDto);
            return task == null
                ? StatusCode(500, "Не удалось создать задачу")
                : CreatedAtAction(nameof(Get), new { id = task.Id }, task);
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, new { Message = "Ошибка сервера", Details = e.Message });
        }
        
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateTaskDto updateTaskDto)
    {
        if (!ModelState.IsValid) return BadRequest();
        var task = await _taskService.UpdateAsync(id, updateTaskDto);
        return task == null ? NotFound() : Ok(task);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var task = await _taskService.DeleteAsync(id);
        return task ? NoContent() : NotFound();
    }
}