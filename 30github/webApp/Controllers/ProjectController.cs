using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webApp.DTOs;
using webApp.Mappers;
using webApp.Repository;
using webApp.Services;

namespace webApp.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProjectController : ControllerBase
{
    private readonly ProjectService _projectService;
    private readonly IMapper _mapper;

    public ProjectController(ProjectService projectService, IMapper mapper)
    {
        _projectService = projectService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetProjects()
    {
        return Ok(await _projectService.GetProjects());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetProject(int id)
    {
        var project = await _projectService.GetProjectById(id);
        return project == null ? NotFound() : Ok(project);
    }

    [HttpPost]
    public async Task<IActionResult> AddProject([FromBody] CreateProjectDto createProjectDto)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            createProjectDto.StartDate = createProjectDto.StartDate.ToUniversalTime();
            createProjectDto.EndDate = createProjectDto.EndDate.ToUniversalTime();
            var project = await _projectService.CreateProject(createProjectDto);
            return project == null
                ? StatusCode(500, "Не удалось создать проект")
                : CreatedAtAction(nameof(GetProject), new { id = project.Id }, project);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateProject(int id, [FromBody] UpdateProjectDto updateProjectDto)
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);
        updateProjectDto.StartDate = updateProjectDto.StartDate.ToUniversalTime();
        updateProjectDto.EndDate = updateProjectDto.EndDate.ToUniversalTime();
        var project = await _projectService.UpdateProject(id, updateProjectDto);
        return project == null ? NotFound() : Ok(project);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteProject(int id)
    {
        var project = await _projectService.DeleteProject(id);
        return project ? NoContent() : NotFound();
    }
}