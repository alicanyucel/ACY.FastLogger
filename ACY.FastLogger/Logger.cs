using System;
using System.IO;

namespace ACY.Logging
{
    public interface ILoggerService
    {
        void Information(string message);
        void Warning(string message);
        void Error(string message, Exception ex = null);
    }

    public class LoggerService : ILoggerService
    {
        private readonly string _logFilePath;

        public LoggerService(string logFilePath = "logs.txt")
        {
            _logFilePath = logFilePath;
        }

        public void Information(string message)
        {
            WriteLog("INFO", message);
        }

        public void Warning(string message)
        {
            WriteLog("WARN", message);
        }

        public void Error(string message, Exception ex = null)
        {
            var msg = ex == null ? message : $"{message} | Exception: {ex.Message}";
            WriteLog("ERROR", msg);
        }

        private void WriteLog(string level, string message)
        {
            var logLine = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}";
            Console.WriteLine(logLine);
            File.AppendAllText(_logFilePath, logLine + Environment.NewLine);
        }
    }
}