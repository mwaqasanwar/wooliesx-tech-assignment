using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WooliesXTechChallenge.Core.Models;
using WooliesXTechChallenge.ResourceApiClient.Config;

namespace WooliesXTechChallenge.Api.Controllers
{
    [Route("api/answers")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController()
        {
            
        }

        [HttpGet("user")]
        public IActionResult Get()
        {
            var result = new User { Name = "Waqas Anwar", Token = ApiConfig.ApiToken };
            return Ok(result);
        }
    }
}
