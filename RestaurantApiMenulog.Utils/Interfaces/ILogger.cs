using System;

namespace RestaurantApiMenulog.Utils.Interfaces
{
    public interface ILogger
    {
        void LogException(Exception exp);
        void LogMessage(string message);
        void LogErrorMessage(string message);
    }
}
