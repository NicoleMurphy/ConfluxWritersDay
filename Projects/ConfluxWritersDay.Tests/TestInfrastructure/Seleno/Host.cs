using TestStack.Seleno.Configuration;
using TestStack.Seleno.Configuration.WebServers;

namespace ConfluxWritersDay.Tests.TestInfrastructure.Seleno
{
    public static class Host
    {
        public static readonly SelenoHost Instance = new SelenoHost();

        static Host()
        {
            Instance.Run(Settings.WebProjectName, Settings.WebPort);
        }
    }
}
