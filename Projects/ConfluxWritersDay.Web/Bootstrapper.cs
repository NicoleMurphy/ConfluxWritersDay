using System;
using System.IO;
using ConfluxWritersDay.Web.Repositories;
using Nancy;
using Nancy.Conventions;
using Nancy.TinyIoc;
using Nancy.Validation.DataAnnotations;

namespace ConfluxWritersDay.Web
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, Nancy.Bootstrapper.IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);
        }

        protected override void ConfigureConventions(NancyConventions conventions)
        {
            base.ConfigureConventions(conventions);

            conventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("Scripts"));
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Register<IMarkdownRepository>((c,n) => new MarkdownRepository(this.GetMarkdownFolder(c)));
        }

        private string GetMarkdownFolder(TinyIoCContainer container)
        {
            var rootPathProvider = container.Resolve<IRootPathProvider>();
            var rootPath = rootPathProvider.GetRootPath();
            var markdownPath = Path.Combine(rootPath, "Markdown");

            return markdownPath;
        }
    }
}