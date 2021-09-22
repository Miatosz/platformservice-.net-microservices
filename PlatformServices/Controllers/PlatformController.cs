using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;  
using PlatformServices.Data;
using PlatformServices.DTOs;
using PlatformServices.Models;

namespace PlatformServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformRepo _repo;
        private readonly IMapper _mapper;

        public PlatformController(IPlatformRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: /api/platform
        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetAllPlatforms()
            => Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(_repo.GetAllPlatforms()));
        

        // GET: /api/platform/1
        [HttpGet("{id}", Name = "GetPlatformById")]
        public ActionResult<PlatformReadDto> GetPlatformById([FromRoute] int id)        
        {
            var platform = _repo.GetPlatformById(id);

            if (platform != null)
                return Ok(_mapper.Map<PlatformReadDto>(platform));
            
            return NotFound("Platform with given ID cannot be found");             
        }

        // POST: /api/platform
        [HttpPost]
        public ActionResult<PlatformCreateDto> CreatePlatform([FromBody] PlatformCreateDto platform)
        {

            var mappedPlatform = _mapper.Map<Platform>(platform);
            _repo.CreatePlatform(mappedPlatform);
            _repo.SaveChanges();

            var platformReadDto = _mapper.Map<PlatformReadDto>(mappedPlatform);

            Console.WriteLine("POST OK");

            return CreatedAtRoute(nameof(GetPlatformById), new { Id = platformReadDto.Id}, platformReadDto);            
        }

    }
}
