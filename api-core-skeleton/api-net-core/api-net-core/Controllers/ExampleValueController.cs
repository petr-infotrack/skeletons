using System.Collections.Generic;
using ApiNetCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiNetCore.Controllers
{
    [Route("api/example")]
    [ApiController]
    public class ExampleValueController : ControllerBase
    {

        private readonly ILogger<ExampleValueController> logger;

        public ExampleValueController(ILogger<ExampleValueController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
