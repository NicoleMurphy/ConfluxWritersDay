using System.IO;

namespace ConfluxWritersDay.Specifications.Infrastructure
{
    public static class Settings
    {
        // todo: hack. It is 3am, if I'm not allowed a hack now when am I???
        public static DirectoryInfo SolutionFolder { get { return new DirectoryInfo(@"C:\Users\Tim\Code\NicoleMurphy\ConfluxWritersDay"); } }

        public static DirectoryInfo AppDataFolder { get { return new DirectoryInfo(Path.Combine(SolutionFolder.FullName, @"Projects\ConfluxWritersDay.Web\App_Data")); } }
    }
}
