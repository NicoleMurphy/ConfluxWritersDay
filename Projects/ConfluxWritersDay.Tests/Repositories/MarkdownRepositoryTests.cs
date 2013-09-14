using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConfluxWritersDay.Tests.Repositories
{
    public class MarkdownRepositoryTests
    {
        [TestClass]
        public class Constructor
        {
            [TestMethod]
            public void ShouldThrowArgumentExceptionWhenFolderWhitespace()
            {
                // Given

                // When

                // Then
                Assert.Inconclusive("todo");
            }

            [TestMethod]
            public void ShouldThrowArgumentExceptionWhenFolderDoesNotExist()
            {
                // Given

                // When

                // Then
                Assert.Inconclusive("todo");
            }
        }

        [TestClass]
        public class GetMarkdown
        {
            [TestMethod]
            public void ShouldThrowArgumentExceptionWhenNameIsWhitespace()
            {
                // Given

                // When

                // Then
                Assert.Inconclusive("todo");
            }

            [TestMethod]
            public void ShouldThrowArgumentExceptionWhenFileDoesNotExist()
            {
                // Given

                // When

                // Then
                Assert.Inconclusive("todo");
            }

            [TestMethod]
            public void ShouldReturnFileContents()
            {
                // Given

                // When

                // Then
                Assert.Inconclusive("todo");
            }
        }

        [TestClass]
        public class MarkdownExists
        {
            [TestMethod]
            public void ShouldThrowArgumentExceptionWhenNameIsWhitespace()
            {
                // Given

                // When

                // Then
                Assert.Inconclusive("todo");
            }

            [TestMethod]
            public void ShouldReturnTrueWhenFileDoesExist()
            {
                // Given

                // When

                // Then
                Assert.Inconclusive("todo");
            }

            [TestMethod]
            public void ShouldReturnFalseWhenFileDoesNotExist()
            {
                // Given

                // When

                // Then
                Assert.Inconclusive("todo");
            }
        }
    }
}
