using Microsoft.Extensions.Logging;

namespace UI_MVC.Core
{
    internal class LoggingMiddleware
    {
        private ILogger logger;

        public LoggingMiddleware(ILogger logger)
        {
            this.logger = logger;
        }
    }
}