using System;
using ConfluxWritersDay.Web.ViewModels.Home;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenMagic.Extensions;
using TestMagic;

namespace ConfluxWritersDay.Tests.ViewModels.Home
{
    public class MarkdownViewModelTests
    {
        [TestClass]
        public class Constructor
        {
            [TestMethod]
            public void ShouldThrowArgumentExceptionWhenMarkdownIsWhitespace()
            {
                GWT.Given("testing constructor")
                    .When(c => new MarkdownViewModel(markdown: ""))
                    .Then<ArgumentException>().ShouldBeThrown().ForParameter("markdown");
            }
        }

        [TestClass]
        public class Html
        {
            [TestMethod]
            public void ShouldReturnMarkdownPassedToConstructorAsHtml()
            {
                // Given
                var markdown = TrimMarkdown(@"para 1
                                
                                para 2");

                // When
                var viewModel = new MarkdownViewModel(markdown);

                // Then
                viewModel.Html.Should().Be("<p>para 1</p>\n\n<p>para 2</p>\n");
            }

            [TestMethod]
            public void ShouldReturnHtmlWithProcessedImageTags()
            {
                // Given
                var markdown = TrimMarkdown(@"{Image=universityhouse.jpg,Description=The internal courtyard at the venue University House also offering accommodation,Alignment=Left} para 1

                    para 2");

                // When
                var viewModel = new MarkdownViewModel(markdown);

                // Then
                viewModel.Html.Should().Be("<p><img src=\"/Content/Images/universityhouse.jpg\" alt=\"The internal courtyard at the venue University House also offering accommodation\" class=\"image-left\" /> para 1</p>\n\n<p>para 2</p>\n");
            }

            [TestMethod]
            public void ShouldReturnHtmlWithProcessedImageTagsWhereImageTagDoesNotHaveAlignmentValue()
            {
                // Given
                var markdown = TrimMarkdown(@"{Image=universityhouse.jpg,Description=The internal courtyard at the venue University House also offering accommodation} para 1

                    para 2");

                // When
                var viewModel = new MarkdownViewModel(markdown);

                // Then
                viewModel.Html.Should().Be("<p><img src=\"/Content/Images/universityhouse.jpg\" alt=\"The internal courtyard at the venue University House also offering accommodation\" class=\"image-noalignment\" /> para 1</p>\n\n<p>para 2</p>\n");
            }

            private string TrimMarkdown(string markdown)
            {
                return string.Join(Environment.NewLine, markdown.ToLines(trimLines:true));
            }
        }
    }
}
