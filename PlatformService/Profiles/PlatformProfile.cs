using AutoMapper;
using PlatformService.DTOs;
using PlatformService.Models;

namespace PlatformService.Profiles
{
    public class PlatformProfile : Profile
    {
        public PlatformProfile()
        {
            // Source -> Target
            CreateMap<PlatformCreateDTO, Platform>().ReverseMap();
            CreateMap<PlatformReadDTO, Platform>().ReverseMap();
            CreateMap<PlatformReadDTO, PlatformPublishDto>().ReverseMap();
        }
    }
}
