using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConfluxWritersDay.Tests.ViewModels.Home
{
    public class MarkdownViewModelTests
    {
        [TestClass]
        public class Constructor
        {
            [TestMethod]
            public void ShouldThrowArgumentNullExceptionWhenMarkdownIsNull()
            {
                // Given
                
                // When

                // Then
                Assert.Inconclusive("todo");
            }

            [TestMethod]
            public void ShouldThrowArgumentExceptionWhenMarkdownIsWhitespace()
            {
                // Given

                // When

                // Then
                Assert.Inconclusive("todo");
            }
        }

        [TestClass]
        public class Html
        {
            [TestMethod]
            public void ShouldReturnMarkdownPassedToConstructorAsHtml()
            {
                // Given

                // When

                // Then
                Assert.Inconclusive("todo");
            }
        }
    }
}
