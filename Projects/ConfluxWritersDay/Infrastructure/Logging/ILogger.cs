using System;

namespace ConfluxWritersDay.Infrastructure.Logging
{
    public interface ILogger
    {
        void Trace(object message);
        void Debug(object message);
        void Info(object message);
        void Warn(object message);

        void Trace(string message);
        void Debug(string message);
        void Info(string message);
        void Warn(string message);

        void Trace(string format, params object[] args);
        void Debug(string format, params object[] args);
        void Info(string format, params object[] args);
        void Warn(string format, params object[] args);

        void Error(Exception ex);
    }
}