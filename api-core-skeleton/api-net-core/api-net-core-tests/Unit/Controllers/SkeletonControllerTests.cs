using ApiNetCore.Controllers;
using ApiNetCore.Services;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace ApiNetCoreTests.Unit.Controllers
{
    public class SkeletonControllerTests
    {
        private ExampleTaskController controller;

        private Mock<ILogger<ExampleTaskController>> mockLogger;

        private Mock<IExampleService> mockService;

        public SkeletonControllerTests()
        {
            // logger stub is used as ILogger extension methods are difficult to Mock reliably

            this.mockLogger = new Mock<ILogger<ExampleTaskController>>();

            this.mockService = new Mock<IExampleService>();
            this.mockService.Setup(m => m.CalculateTotalAsync(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(5)
                .Verifiable();
                

            this.controller = new ExampleTaskController(this.mockLogger.Object, this.mockService.Object);
        }

        [Fact]
        public async void ShouldReturnValidResult()
        {
            var jsonResult  = await this.controller.Calculate(1, 3) as Microsoft.AspNetCore.Mvc.OkObjectResult;

            
            Assert.NotNull(jsonResult);
            this.mockService.Verify(m => m.CalculateTotalAsync(It.IsAny<int>(), It.IsAny<int>()), Times.Once);

           // Assert.Equal(5, result);



            //Assert.True(this.loggerStub.LoggedMessages.Count > 0);

            //Assert.Contains("TRACE", this.loggerStub.LoggedMessages[0].Item1);
            //Assert.Contains("CalculateTotalAsync methods was invoked", this.loggerStub.LoggedMessages[0].Item2);

        }
    }
}
