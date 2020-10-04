using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseForNuevo.Bussiness.Services
{
    public class Logger :ILogger
    {
        private readonly ILogger<Logger> _logger;

        public Logger(ILogger<Logger> logger)
        {
            _logger = logger;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            throw new NotImplementedException();
        }

        public void Log<TState>(LogLevel logLevel,EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            _logger.Log(logLevel, state.ToString());
        }
    }
}
