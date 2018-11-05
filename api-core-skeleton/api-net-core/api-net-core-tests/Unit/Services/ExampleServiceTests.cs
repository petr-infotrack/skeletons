using System.Linq;
using System.Text;
using ApiNetCore.Services;
using ApiNetCoreTests.Unit.Helpers;
using Microsoft.Extensions.Logging.Internal;
using Moq;
using Xunit;

namespace ApiNetCoreTests.Unit.Services
{
    public class ExampleServiceTests
    {
        private IExampleService service;

        private LoggerStub loggerStub;

        public ExampleServiceTests()
        {
            // logger stub is used as ILogger extension methods are difficult to Mock reliably

            this.loggerStub = new LoggerStub();

            this.service = new ExampleService(this.loggerStub);
        }

        [Fact]
        public void ShouldReturnValidResult()
        {
            var task = this.service.CalculateTotal(1, 3);


            Assert.Equal(4, task.Result);


            Assert.True(this.loggerStub.LoggedMessages.Count > 0);

            Assert.Contains("TRACE", this.loggerStub.LoggedMessages[0].Item1);
            Assert.Contains("CalculateTotal methods was invoked", this.loggerStub.LoggedMessages[0].Item2);

        }
    }
}
