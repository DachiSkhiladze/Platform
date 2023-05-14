using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.DTOs;
using PlatformService.Models;

namespace PlatformService.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _repo;

        public readonly IMapper _mapper;

        public PlatformsController(IPlatformRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDTO>> GetPlatforms()
        {
            Console.WriteLine("--> Getting Platforms...");

            var platformItem = _repo.GetAllPlatforms();

            return Ok(_mapper.Map<IEnumerable<PlatformReadDTO>>(platformItem));
        }

        [HttpGet("{id}", Name = "GetPlatformById")]
        public ActionResult<PlatformReadDTO> GetPlatformById(int id)
        {
            var platformItem = _repo.GetPlatformById(id);

            if (platformItem is not null)
            {
                return Ok(_mapper.Map<PlatformReadDTO>(platformItem));
            }

            return StatusCode(StatusCodes.Status404NotFound);
        }

        [HttpPost]
        public ActionResult<PlatformReadDTO> CreatePlatform(PlatformCreateDTO platformCreateDTO)
        {
            var platformModel = _mapper.Map<Platform>(platformCreateDTO);
            if (platformModel is not null)
            {
                _repo.CreatePlatform(platformModel);
                _repo.SaveChanges();

                var platformReadDTO = _mapper.Map<PlatformReadDTO>(platformModel);

                return CreatedAtRoute(nameof(GetPlatformById), new { Id = platformReadDTO.id }, platformReadDTO);
            }

            return StatusCode(StatusCodes.Status400BadRequest);
        }
    }
}
