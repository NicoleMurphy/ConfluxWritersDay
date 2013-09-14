using System;
using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nancy.ViewEngines;
using Nancy.ViewEngines.Razor;
using NancyMagic;
using Nancy.Helpers;
using TestMagic;

namespace ConfluxWritersDay.Tests.NancyMagic
{
    public class StringExtensionsTests
    {
        [TestClass]
        public class HtmlEncode
        {
            [TestMethod]
            public void ShouldThrowArgumentNullExceptionWhenValueIsNullAndSecondParameterIsRenderContext()
            {
                GWT.Given("testing null value")
                    .When(x => StringExtensions.HtmlEncode(value: null, renderContext: A.Fake<IRenderContext>()))
                    .Then<ArgumentNullException>().ShouldBeThrown().ForParameter("value");
            }

            [TestMethod]
            public void ShouldThrowArgumentNullExceptionWhenValueIsWhitespaceAndSecondParameterIsRenderContext()
            {
                GWT.Given("testing whitespace value")
                    .When(x => StringExtensions.HtmlEncode(value: "", renderContext: A.Fake<IRenderContext>()))
                    .Then<ArgumentException>().ShouldBeThrown().ForParameter("value");
            }

            [TestMethod]
            public void ShouldThrowArgumentNullExceptionWhenValueIsNullAndSecondParameterIsHtmlHelper()
            {
                GWT.Given("testing null value")
                    .When(x => StringExtensions.HtmlEncode(value: null, htmlHelper: this.FakeHtmlHelper()))
                    .Then<ArgumentNullException>().ShouldBeThrown().ForParameter("value");
            }

            [TestMethod]
            public void ShouldThrowArgumentNullExceptionWhenValueIsWhitespaceAndSecondParameterIsHtmlHelpers()
            {
                GWT.Given("testing whitespace value")
                    .When(x => StringExtensions.HtmlEncode(value: "", htmlHelper: this.FakeHtmlHelper()))
                    .Then<ArgumentException>().ShouldBeThrown().ForParameter("value");
            }

            [TestMethod]
            public void ShouldThrowArgumentNullExceptionWhenRenderContext()
            {
                GWT.Given("testing whitespace value")
                    .When(x => StringExtensions.HtmlEncode(value: "fake", renderContext: null))
                    .Then<ArgumentException>().ShouldBeThrown().ForParameter("renderContext");
            }

            [TestMethod]
            public void ShouldThrowArgumentNullExceptionWhenHtmlHelperIsNull()
            {
                GWT.Given("testing whitespace value")
                    .When(x => StringExtensions.HtmlEncode<dynamic>(value: "fake", htmlHelper: null))
                    .Then<ArgumentException>().ShouldBeThrown().ForParameter("htmlHelper");
            }

            [TestMethod]
            public void ShouldUseRenderContextToHtmlEncodeTheValue()
            {
                // Given
                var value = "a fake string";
                var renderContext = A.Fake<IRenderContext>();

                // When
                var encoded = value.HtmlEncode(renderContext);

                // Then
                A.CallTo(() => renderContext.HtmlEncode(value)).MustHaveHappened(Repeated.Exactly.Once);
            }

            [TestMethod]
            public void ShouldUseRenderContextOfHtmlHelperToHtmlEncodeTheValue()
            {
                // Given
                var value = "a fake string";
                var renderContext = A.Fake<IRenderContext>();

                // When
                var encoded = value.HtmlEncode(this.FakeHtmlHelper(renderContext));

                // Then
                A.CallTo(() => renderContext.HtmlEncode(value)).MustHaveHappened(Repeated.Exactly.Once);
            }

            private HtmlHelpers<dynamic> FakeHtmlHelper()
            {
                return new HtmlHelpers<dynamic>(new RazorViewEngine(A.Fake<IRazorConfiguration>()), A.Fake<IRenderContext>(), null);
            }

            private HtmlHelpers<dynamic> FakeHtmlHelper(IRenderContext renderContext)
            {
                return new HtmlHelpers<dynamic>(new RazorViewEngine(A.Fake<IRazorConfiguration>()), renderContext, null);
            }
        }
    }
}
