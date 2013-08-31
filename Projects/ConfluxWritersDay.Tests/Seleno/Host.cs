using TestStack.Seleno.Configuration;
using TestStack.Seleno.Configuration.WebServers;

namespace ConfluxWritersDay.Tests.Seleno
{
    public static class Host
    {
        public static readonly SelenoHost Instance = new SelenoHost();

        static Host()
        {
            Instance.Run(Config.WebProjectName, Config.WebPort);
        }
    }
}
