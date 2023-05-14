using System.ComponentModel.DataAnnotations;

namespace PlatformService.DTOs
{
    public record PlatformCreateDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        public string Cost { get; set; }
    }
}
