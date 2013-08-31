using System;
using MarkdownSharp;
using OpenMagic;

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
            var markdown = new Markdown(
                new MarkdownOptions()
                {
                    AutoHyperlink = true,
                    LinkEmails = true
                }
            );

            var html = markdown.Transform(markdownText);

            return html;
        }
    }
}