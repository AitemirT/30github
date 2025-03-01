using AutoMapper;
using webApp.DTOs.Task;
using webApp.Models;

namespace webApp.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<TheTask, TaskDto>()
            .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.FirstName + " " + src.Author.LastName))
            .ForMember(dest => dest.ExecutorName, opt => opt.MapFrom(src => src.Executor.FirstName + " " + src.Executor.LastName));

        CreateMap<CreateTaskDto, TheTask>();
    }
}