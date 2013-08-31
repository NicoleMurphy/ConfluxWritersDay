using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nancy.TinyIoc;
using ConfluxWritersDay.Web.Repositories;

namespace CroquetScores.Domain.UnitTests
{
    [TestClass]
    public class Assembly
    {
        [AssemblyInitialize]
        public static void BeforeAllTestsInThisAssembly(TestContext context)
        {
            var container = TinyIoCContainer.Current;

            container.AutoRegister();
            var can = container.CanResolve<IMembershipOrganisationRepository>();
        }

        [AssemblyCleanup]
        public static void AfterAllTestsInThisAssembly()
        {
        }
    }
}
