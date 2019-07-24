using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WooliesXTechChallenge.Core.Enum;
using WooliesXTechChallenge.Core.Interface;
using WooliesXTechChallenge.Core.Models;

namespace WooliesXTechChallenge.Api.Controllers
{
    [Route("api/answers")]
    [ApiController]
    public class TrolleyController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly ITrolleyCalculatorService _trolleyService;

        public TrolleyController(ILogger<UserController> logger, ITrolleyCalculatorService trolleyService)
        {
            _logger = logger;
            _trolleyService = trolleyService;
        }

        [HttpPost("trolleyTotalWoolies")]
        public async Task<IActionResult> GetTrolleyTotal(Trolley trolley)
        {
            var minTrolleyPrice = await _trolleyService.GetMinimumTrolleyBalance(trolley);
            return Ok(minTrolleyPrice);
        }

        [HttpPost("trolleyTotal")]
        public async Task<IActionResult> CalculateTrolleyTotal(Trolley trolley)
        {
            var minTrolleyPrice = await _trolleyService.CalculateTrolleyTotal(trolley);
            return Ok(minTrolleyPrice);
        }
    }
}
