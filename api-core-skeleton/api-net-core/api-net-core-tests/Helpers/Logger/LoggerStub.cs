using System;
using System.Collections.Generic;
using ApiNetCore.Services;
using Microsoft.Extensions.Logging;

namespace ApiNetCoreTests.Helpers.Logger
{
    /*  ---------------------------------------------------------------------------------------------------------------
        LOGGER - STUB  - Essential for stubbing/mocking ILogger responses to extension methods.. (Moq often fails)         
        --------------------------------------------------------------------------------------------------------------- */
    public class LoggerStub: ILogger<ExampleService>
    {
        public List<Tuple<string, string>> LoggedMessages;

        public LoggerStub()
        {
            this.LoggedMessages = new List<Tuple<string, string>>();
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            this.LoggedMessages.Add(new Tuple<string, string>(Enum.GetName(typeof(LogLevel), logLevel), state?.ToString()));
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
    }
}