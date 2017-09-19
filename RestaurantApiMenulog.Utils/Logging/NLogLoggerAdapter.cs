using System;
using NLog;

namespace RestaurantApiMenulog.Utils.Logging
{
    public class NLogLoggerAdapter : Interfaces.ILogger
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public void LogException(Exception exp)
        {
            _logger.Log(LogLevel.Error, exp);
        }

        public void LogMessage(string message)
        {
            _logger.Log(LogLevel.Info, message);
        }

        public void LogErrorMessage(string message)
        {
            _logger.Log(LogLevel.Error, message);
        }
    }
}
