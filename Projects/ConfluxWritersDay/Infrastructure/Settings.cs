using System;
using System.IO;

namespace ConfluxWritersDay.Infrastructure
{
    public class Settings : ISettings
    {
        public Settings(DirectoryInfo appDataFolder)
        {
            IsDeveloperMachine = Environment.MachineName.Equals("TimMurphy2010", StringComparison.InvariantCultureIgnoreCase);
            AppDataFolder = appDataFolder;
        }

        public bool IsDeveloperMachine { get; set; }
        public DirectoryInfo AppDataFolder { get; set; }
    }
}
