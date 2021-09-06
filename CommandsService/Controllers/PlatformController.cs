using System;
using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers
{
    [ApiController]
    [Route("api/c/[controller]")]
    public class PlatformController : ControllerBase
    {
        

        public PlatformController()
        {
            
        }

        
        [HttpGet]

        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("--> Inbound POST # Command Service");
        
            return Ok("Inbound test of from Platforms Controller");
        }

    }
}
