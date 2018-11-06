using ApiNetCore.Services;
using ApiNetCoreTests.Helpers.Logger;
using Xunit;

namespace ApiNetCoreTests.Unit.Services
{
    public class SkeletonServiceTests
    {
        private IExampleService service;

        private LoggerStub loggerStub;

        public SkeletonServiceTests()
        {
            // logger stub is used as ILogger extension methods are difficult to Mock reliably

            this.loggerStub = new LoggerStub();

            this.service = new ExampleService(this.loggerStub);
        }

        [Fact]
        public void ShouldReturnValidResult()
        {
            var task = this.service.CalculateTotalAsync(1, 3);


            Assert.Equal(4, task.Result);


            Assert.True(this.loggerStub.LoggedMessages.Count > 0);

            Assert.Contains("Trace", this.loggerStub.LoggedMessages[0].Item1);
            Assert.Contains("CalculateTotalAsync", this.loggerStub.LoggedMessages[0].Item2);

        }
    }
}
