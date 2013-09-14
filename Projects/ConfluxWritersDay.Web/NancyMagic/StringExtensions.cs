using Nancy.ViewEngines;
using Nancy.ViewEngines.Razor;
using OpenMagic;

namespace NancyMagic
{
    public static class StringExtensions
    {
        public static string HtmlEncode<TModel>(this string value, HtmlHelpers<TModel> htmlHelper)
        {
            value.MustNotBeNullOrWhiteSpace("value");

            return value.HtmlEncode(htmlHelper.RenderContext);
        }

        public static string HtmlEncode(this string value, IRenderContext renderContext)
        {
            value.MustNotBeNullOrWhiteSpace("value");

            return renderContext.HtmlEncode(value);
        }
    }
}