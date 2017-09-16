using System;
using System.IO;

namespace FinancialControl.Repositories
{

    public interface IPathRepository
    {
        string AppData { get; }
        string ApplicationDirectory { get; }
        string ApplicationDirectoryName { get; }
        string ApplicationDataDirectory { get; }

    }
    public class PathRepository : IPathRepository
    {
        public string AppData => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public string ApplicationDirectory => Path.Combine(AppData, ApplicationDirectoryName);
        public string ApplicationDirectoryName => "FinancialControl";
        public string ApplicationDataDirectory => Path.Combine(ApplicationDirectory, "Data");
    }
}
