using System;
using System.Linq.Expressions;
using System.Text;
using Nancy.ViewEngines.Razor;
using OpenMagic.DataAnnotations;

namespace NancyMagic
{
    public static class HtmlHelpersExtensions
    {
        public static IHtmlString LabelFor<TModel, TProperty>(this HtmlHelpers<TModel> htmlHelper, Expression<Func<TModel, TProperty>> property)
        {
            var propertyMetadata = ClassMetadata.GetProperty(property);

            return htmlHelper.LabelFor(propertyMetadata);
        }

        public static IHtmlString LabelFor<TModel>(this HtmlHelpers<TModel> htmlHelper, IPropertyMetadata propertyMetadata)
        {
            return htmlHelper.Raw(string.Format("<label class=\"control-label\">{0}</label>", propertyMetadata.Display.GetName().HtmlEncode(htmlHelper)));
        }

        public static IHtmlString TextBoxFor<TModel, TProperty>(this HtmlHelpers<TModel> htmlHelper, Expression<Func<TModel, TProperty>> property)
        {
            var propertyMetadata = ClassMetadata.GetProperty(property);

            return htmlHelper.TextBoxFor(propertyMetadata);
        }

        public static IHtmlString TextBoxFor<TModel>(this HtmlHelpers<TModel> htmlHelper, IPropertyMetadata propertyMetadata)
        {
            var value = propertyMetadata.PropertyInfo.GetValue(htmlHelper.Model, null).ToString().HtmlEncode(htmlHelper);
            
            return htmlHelper.Raw(
                string.Format("<input id=\"{0}\" name=\"{1}\" type=\"text\" placeholder=\"{2}\" class=\"input-xlarge\" value=\"{3}\">",
                    propertyMetadata.PropertyInfo.Name.HtmlEncode(htmlHelper),
                    propertyMetadata.PropertyInfo.Name.HtmlEncode(htmlHelper),
                    propertyMetadata.Display.GetPrompt().HtmlEncode(htmlHelper),
                    value.HtmlEncode(htmlHelper)
                )
            );
        }

        public static IHtmlString TextBoxGroupFor<TModel, TProperty>(this HtmlHelpers<TModel> htmlHelper, Expression<Func<TModel, TProperty>> property)
        {
            var propertyMetadata = ClassMetadata.GetProperty(property);
            var sb = new StringBuilder();

            sb.AppendLine("<div class=\"control-group\">");
            sb.Append(htmlHelper.LabelFor(propertyMetadata));
            sb.AppendLine("<div class=\"controls\">");
            sb.Append(htmlHelper.TextBoxFor(propertyMetadata));
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");

            return htmlHelper.Raw(sb.ToString());
        }
    }
}
