using BoDi;
using ConfluxWritersDay.Infrastructure;
using ConfluxWritersDay.Infrastructure.Logging;
using ConfluxWritersDay.Repositories;
using TechTalk.SpecFlow;

namespace ConfluxWritersDay.Specifications.Infrastructure
{
    [Binding]
    public class SpecFlowHooks
    {
        private static readonly ILogger Log = new Logger();

        private readonly IObjectContainer Container;

        public SpecFlowHooks(IObjectContainer container)
        {
            Container = container;
        }

        [BeforeTestRun]
        public static void BeforeEntireTestSuite()
        {
            Log.Trace("BeforeEntireTestSuite()");
        }

        [AfterTestRun]
        public static void AfterEntireTestSuite()
        {
            Log.Trace("AfterEntireTestSuite()");
        }

        [BeforeFeature]
        public static void BeforeEachFeature()
        {
            Log.Trace("BeforeEachFeature()");
        }

        [AfterFeature]
        public static void AfterEachFeature()
        {
            Log.Trace("AfterEachFeature()");
        }

        [BeforeScenario]
        public void BeforeEachScenario()
        {
            Log.Trace("BeforeEachScenario()");

            Container.RegisterTypeAs<RegistrationRepository, IRegistrationRepository>();
            Container.RegisterInstanceAs<ISettings>(new ConfluxWritersDay.Infrastructure.Settings(Settings.AppDataFolder));
        }

        [AfterScenario]
        public void AfterEachScenario()
        {
            Log.Trace("AfterEachScenario()");
        }
    }
}
