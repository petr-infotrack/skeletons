using ApiNetCore.Controllers;
using ApiNetCore.Services;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace ApiNetCoreTests.Integration.Controllers
{
    public class SkeletonControllerTests
    {
        private Mock<ILogger<ExampleTaskController>> mockLogger;

        private ExampleTaskController controller;

        
        private IExampleService service;

        public SkeletonControllerTests()
        {
            // logger stub is used as ILogger extension methods are difficult to Mock reliably

            this.mockLogger = new Mock<ILogger<ExampleTaskController>>();

            this.service = new ExampleService(new Mock<ILogger<ExampleService>>().Object);
                

            this.controller = new ExampleTaskController(this.mockLogger.Object, this.service);
        }

        [Fact]
        public async void ShouldReturnValidResult()
        {
            var result = await this.controller.Calculate(1, 3) as Microsoft.AspNetCore.Mvc.OkObjectResult;

            Assert.NotNull(result);

            var json = JsonConvert.SerializeObject(result.Value);

            Assert.Equal("{\"result\":4}", json);

        }
    }
}
