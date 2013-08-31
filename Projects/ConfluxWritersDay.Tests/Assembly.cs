using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nancy.TinyIoc;

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
        }

        [AssemblyCleanup]
        public static void AfterAllTestsInThisAssembly()
        {
        }
    }
}
