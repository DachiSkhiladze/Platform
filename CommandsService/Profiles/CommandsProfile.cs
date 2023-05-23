using AutoMapper;
using CommandsService.Dtos;
using CommandsService.Models;

namespace CommandsService.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            // Source --> Target
            CreateMap<Platform, PlatformReadDto>().ReverseMap();
            CreateMap<Command, CommandCreateDto>().ReverseMap();
            CreateMap<Command, CommandReadDto>().ReverseMap();
            CreateMap<PlatformPublishedDto, Platform>()
              .ForMember(dest => dest.ExternalID, opt => opt.MapFrom(src => src.Id))
              .ReverseMap();
        }
    }
}
