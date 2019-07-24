using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WooliesXTechChallenge.Core.Enum;
using WooliesXTechChallenge.Core.Interface;

namespace WooliesXTechChallenge.Api.Controllers
{
    [Route("api/answers")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IProductsService _productsService;

        public ProductController(ILogger<UserController> logger, IProductsService productsService)
        {
            _logger = logger;
            _productsService = productsService;
        }

        [HttpGet("sort")]
        public async Task<IActionResult> Sort(SortOptions sortOption)
        {
            if (sortOption == SortOptions.None)
            {
                return BadRequest("Invalid sort option");
            }

            var products = await _productsService.SortProductsAsync(sortOption);
            return Ok(products);
        }
    }
}
