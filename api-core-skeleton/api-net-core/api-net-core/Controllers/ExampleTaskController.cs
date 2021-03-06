﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ApiNetCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiNetCore.Controllers
{
    [Route("api/example")]
    [ApiController]
    public class ExampleTaskController : ControllerBase
    {

        private readonly ILogger<ExampleTaskController> logger;
        private readonly IExampleService exampleService;

        public ExampleTaskController(ILogger<ExampleTaskController> logger, IExampleService exampleService)
        {
            this.logger = logger;
            this.exampleService = exampleService;
        }

        [HttpGet("calculate")]
        public async Task<IActionResult> Calculate([FromQuery] int x, int y)
        {
            var result = await this.exampleService.CalculateTotalAsync(x, y);

            var jsonResponse = new
            {
                result = result
            };

            return Ok(jsonResponse);                
        }
    }
}
