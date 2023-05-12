using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace NagarroReader.Logger
{
    public class LogException : ExceptionFilterAttribute
    {
        private readonly ILog _logger;

        public LogException()
        {
            _logger = ILog.GetInstance;
        }
        [LogException]
        public override void OnException(ExceptionContext context)
        {
            _logger.LogException(context.Exception.Message);
            base.OnException(context);
        }
    }
 
}
