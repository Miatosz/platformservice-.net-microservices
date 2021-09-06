using System;
using System.ComponentModel.DataAnnotations;

namespace PlatformServices.DTOs
{
    public class PlatformCreateDto
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string Publisher { get; set; }

        [Required]
        public string Cost { get; set; }
    }
}
