using AutoMapper;
using webApp.DTOs;
using webApp.Mappers;
using webApp.Models;
using webApp.Repository;

namespace webApp.Services;

public class ProjectService
{
    private readonly IProjectRepository _projectRepository;
    private readonly IMapper _mapper;

    public ProjectService(IProjectRepository projectRepository, IMapper mapper)
    {
        _projectRepository = projectRepository;
        _mapper = mapper;
    }

    public async Task<List<ProjectDto>> GetProjects()
    {
        List<Project> projects = await _projectRepository.GetAllProjectsAsync();
        return projects.ConvertAll(p => p.ToProjectDto(_mapper));
    }

    public async Task<ProjectDto?> GetProjectById(int id)
    {
        var project = await _projectRepository.GetProjectByIdAsync(id);
        if(project == null) return null;
        return project.ToProjectDto(_mapper);
    }

    public async Task<ProjectDto?> CreateProject(CreateProjectDto createProjectDto)
    {
        var project = createProjectDto.ToProjectFromCreateProjectDto();
        var createdProject = await _projectRepository.CreateProjectAsync(project);
        return createdProject.ToProjectDto(_mapper);
    }

    public async Task<ProjectDto?> UpdateProject(int id, UpdateProjectDto updateProjectDto)
    {
        var project = await _projectRepository.UpdateProjectAsync(id, updateProjectDto);
        if(project == null) return null;
        return project.ToProjectDto(_mapper);
    }

    public async Task<bool> DeleteProject(int id)
    {
        var project = await _projectRepository.DeleteProjectAsync(id);
        return project != null;
    }
}