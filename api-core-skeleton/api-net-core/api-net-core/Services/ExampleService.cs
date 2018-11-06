using System;
using System.Collections.Generic;
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


        public async Task<int> CalculateTotalAsync(int x, int y)
        {
            this.logger.LogTrace("ExampleService->CalculateTotalAsync() - method executed");


            var task = await Task.Run(() => x + y);

            return task;
        }
    }
}
