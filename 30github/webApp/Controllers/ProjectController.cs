using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webApp.DTOs;
using webApp.Mappers;
using webApp.Repository;

namespace webApp.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProjectController : ControllerBase
{
    private readonly IProjectRepository _projectRepository;
    private readonly IMapper _mapper;

    public ProjectController(IProjectRepository projectRepository, IMapper mapper)
    {
        _projectRepository = projectRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetProjects()
    {
        var projects = await _projectRepository.GetAllProjectsAsync();
        var projectDtos = projects.Select(p => p.ToProjectDto(_mapper));
        return Ok(projectDtos);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetProject(int id)
    {
        var project = await _projectRepository.GetProjectByIdAsync(id);
        var projectDto = project.ToProjectDto(_mapper);
        return projectDto == null ? NotFound() : Ok(projectDto);
    }

    [HttpPost]
    public async Task<IActionResult> AddProject([FromBody] CreateProjectDto createProjectDto)
    {
        try
        {
            createProjectDto.StartDate = createProjectDto.StartDate.ToUniversalTime();
            createProjectDto.EndDate = createProjectDto.EndDate.ToUniversalTime();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var project = createProjectDto.ToProjectFromCreateProjectDto();
            var createdProject = await _projectRepository.CreateProjectAsync(project);
            return createdProject == null
                ? StatusCode(500, "Не удалось создать проект")
                : CreatedAtAction(nameof(GetProject), new { id = createdProject.Id }, createdProject.ToProjectDto(_mapper));
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
        var project = await _projectRepository.UpdateProjectAsync(id, updateProjectDto);
        return project == null ? NotFound() : Ok(project.ToProjectDto(_mapper));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteProject(int id)
    {
        var project = await _projectRepository.DeleteProjectAsync(id);
        return project == null ? NotFound() : Ok(project);
    }
}