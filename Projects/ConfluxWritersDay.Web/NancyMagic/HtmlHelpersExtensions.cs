using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Nancy.ViewEngines.Razor;
using OpenMagic.DataAnnotations;

namespace NancyMagic
{
    public static class HtmlHelpersExtensions
    {
        public static IHtmlString TextBoxGroupFor<TModel, TProperty>(this HtmlHelpers<TModel> htmlHelper, Expression<Func<TModel, TProperty>> property)
        {
            var propertyMetadata = ClassMetadata.GetProperty(property);
            var sb = new StringBuilder();

            sb.AppendLine("<div class=\"control-group\">");
            sb.Append(LabelFor(htmlHelper, propertyMetadata));
            sb.AppendLine("<div class=\"controls\">");
            sb.Append(TextBoxFor(htmlHelper, propertyMetadata));
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");

            return sb.ToString().ToHtmlString();
        }

        public static IHtmlString LabelFor<TModel, TProperty>(this HtmlHelpers<TModel> htmlHelper, Expression<Func<TModel, TProperty>> property)
        {
            var propertyMetadata = ClassMetadata.GetProperty(property);

            return LabelFor(htmlHelper, propertyMetadata);
        }

        public static IHtmlString LabelFor<TModel>(this HtmlHelpers<TModel> htmlHelper, IPropertyMetadata propertyMetadata)
        {
            return string.Format("<label class=\"control-label\">{0}</label>", propertyMetadata.Display.GetName()).ToHtmlString();
        }

        public static IHtmlString TextBoxFor<TModel, TProperty>(this HtmlHelpers<TModel> htmlHelper, Expression<Func<TModel, TProperty>> property)
        {
            var propertyMetadata = ClassMetadata.GetProperty(property);

            return TextBoxFor(htmlHelper, propertyMetadata);
        }

        public static IHtmlString TextBoxFor<TModel>(this HtmlHelpers<TModel> htmlHelper, IPropertyMetadata propertyMetadata)
        {
            var value = propertyMetadata.PropertyInfo.GetValue(htmlHelper.Model, null);

            return string.Format("<input id=\"{0}\" name=\"{1}\" type=\"text\" placeholder=\"{2}\" class=\"input-xlarge\" value=\"{3}\">", propertyMetadata.PropertyInfo.Name, propertyMetadata.PropertyInfo.Name, propertyMetadata.Display.GetPrompt(), value).ToHtmlString();
        }
    }
}
