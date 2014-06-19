using System;
using System.Diagnostics;
using Common.Logging;

namespace ConfluxWritersDay.Infrastructure.Logging
{
    public class Logger : ILogger
    {
        private readonly ILog CommonLogger;

        public Logger()
            : this(GetCallingMethodName())
        {
        }

        public Logger(string name)
        {
            CommonLogger = LogManager.GetLogger(name);
        }

        public void Trace(object message)
        {
            CommonLogger.Trace(message);
        }

        public void Debug(object message)
        {
            CommonLogger.Debug(message);
        }

        public void Info(object message)
        {
            CommonLogger.Info(message);
        }

        public void Warn(object message)
        {
            CommonLogger.Warn(message);
        }

        public void Trace(string message)
        {
            CommonLogger.Trace(message);
        }

        public void Debug(string message)
        {
            CommonLogger.Debug(message);
        }

        public void Info(string message)
        {
            CommonLogger.Info(message);
        }

        public void Warn(string message)
        {
            CommonLogger.Warn(message);
        }

        public void Trace(string format, params object[] args)
        {
            CommonLogger.TraceFormat(format, args);
        }

        public void Debug(string format, params object[] args)
        {
            CommonLogger.DebugFormat(format, args);
        }

        public void Info(string format, params object[] args)
        {
            CommonLogger.InfoFormat(format, args);
        }

        public void Warn(string format, params object[] args)
        {
            CommonLogger.WarnFormat(format, args);
        }

        public void Error(Exception ex)
        {
            CommonLogger.Error(ex.Message, ex);
        }

        private static string GetCallingMethodName()
        {
            return new StackTrace().GetFrame(2).GetMethod().DeclaringType.Name;
        }
    }
}