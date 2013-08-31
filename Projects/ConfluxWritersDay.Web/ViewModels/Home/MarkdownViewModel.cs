using System;
using MarkdownSharp;
using OpenMagic;
using OpenMagic.Extensions;

namespace ConfluxWritersDay.Web.ViewModels.Home
{
    public class MarkdownViewModel
    {
        private Lazy<string> _Html;

        public MarkdownViewModel(string markdown)
        {
            markdown.MustNotBeNullOrWhiteSpace("markdown");

            _Html = new Lazy<string>(() => ToHtml(markdown));
        }

        public string Html { get { return _Html.Value; } }

        private string ToHtml(string markdownText)
        {
            var text = ReplaceImageTags(markdownText);

            var markdown = new Markdown(
                new MarkdownOptions()
                {
                    AutoHyperlink = true,
                    LinkEmails = true
                }
            );

            var html = markdown.Transform(text);

            return html;
        }

        private string ReplaceImageTags(string markdownText)
        {
            var text = markdownText;
            var indexOfStartImageTag = text.IndexOf("{Image=");

            while (indexOfStartImageTag > -1)
            {
                var indexOfEndImageTag = text.IndexOf("}", indexOfStartImageTag);
                var imageTag = text.Substring(indexOfStartImageTag, indexOfEndImageTag - indexOfStartImageTag);
                var imageParts = imageTag.Split(',');
                var src = imageParts[0].TextAfter("=");
                var alt = imageParts[1].TextAfter("=");
                var css = this.GetCss(imageParts);

                var img = string.Format("<img src=\"/Content/Images/{0}\" alt=\"{1}\" class=\"image-{2}\" />", src, alt, css);
                var before = text.Substring(0, indexOfStartImageTag);
                var after = text.Substring(indexOfEndImageTag + 1);

                text = before + img + after;

                indexOfStartImageTag = text.IndexOf("{Image=");
            }

            return text;
        }

        private string GetCss(string[] imageParts)
        {
            if (imageParts.Length == 2)
            {
                return "noalignment";
            }

            return imageParts[2].TextAfter("=").ToLower();
        }
    }
}