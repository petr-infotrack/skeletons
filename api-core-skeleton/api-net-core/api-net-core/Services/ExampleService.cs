using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ApiNetCore.Services
{
    public class ExampleService: IExampleService
    {
        private ILogger<ExampleService> logger;

        public ExampleService(ILogger<ExampleService> logger)
        {
            this.logger = logger;
        }


        public async Task<int> CalculateTotal(int x, int y)
        {

            this.logger.LogTrace("CalculateTotal methods was invoked" );

            return (x + y) ;
        }
    }
}
