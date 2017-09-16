
using System.Configuration;
using System.IO;

namespace Utils
{
    public enum Severity
    {
        Error, Info, Warning
    }
    public interface ILogger
    {
        void Log(string data, Severity severity = Severity.Warning);
    }
    public class Logger : ILogger
    {
        private readonly string _path;

        public Logger()
        {
            _path = ConfigurationManager.AppSettings["loggingPath"];
        }
        public void Log(string data, Severity severity = Severity.Warning)
        {
            File.WriteAllText(_path, data);
        }

    }
}
