using System.IO;

namespace ConfluxWritersDay.Infrastructure
{
    public interface ISettings
    {
        bool IsDeveloperMachine { get; set; }
        DirectoryInfo AppDataFolder { get; set; }
    }
}