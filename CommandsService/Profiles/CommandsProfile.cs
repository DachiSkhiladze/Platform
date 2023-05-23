using AutoMapper;
using CommandsService.Dtos;
using CommandsService.Models;
using PlatformService;

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
            CreateMap<GrpcPlatformModel, Platform>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PlatformId))
              .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
              .ForMember(dest => dest.Commands, opt => opt.Ignore());
        }
    }
}
