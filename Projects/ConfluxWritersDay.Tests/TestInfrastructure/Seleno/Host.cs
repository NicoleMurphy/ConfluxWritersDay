using TestStack.Seleno.Configuration;

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
