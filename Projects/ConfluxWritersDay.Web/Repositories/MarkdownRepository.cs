using System;
using System.IO;
using OpenMagic;

namespace ConfluxWritersDay.Web.Repositories
{
    public class MarkdownRepository : IMarkdownRepository
    {
        private readonly string Folder;

        public MarkdownRepository(string folder)
        {
            folder.MustNotBeNullOrWhiteSpace("folder");

            if (!Directory.Exists(folder))
            {
                throw new ArgumentException(string.Format("'{0}' folder does not exist.", folder));
            }

            this.Folder = folder;
        }

        public string GetMarkdown(string name)
        {
            var fileName = GetFullFileName(name);
            var markdown = File.ReadAllText(fileName);

            if (markdown.Trim() == "todo")
            {
                markdown = "<h1>todo: " + name + @"</h1>
                
Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ergo ita: non posse honeste vivi, nisi honeste vivatur? Quod autem in homine praestantissimum atque optimum est, id deseruit. Ut non sine causa ex iis memoriae ducta sit disciplina. Atqui reperies, inquit, in hoc quidem pertinacem; Quae sunt igitur communia vobis cum antiquis, iis sic utamur quasi concessis; Eorum enim est haec querela, qui sibi cari sunt seseque diligunt. Quacumque enim ingredimur, in aliqua historia vestigium ponimus.

<div class=""alert"">
    <p>alert

    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ergo ita: non posse honeste vivi, nisi honeste vivatur? Quod autem in homine praestantissimum atque optimum est, id deseruit. Ut non sine causa ex iis memoriae ducta sit disciplina. Atqui reperies, inquit, in hoc quidem pertinacem; Quae sunt igitur communia vobis cum antiquis, iis sic utamur quasi concessis; Eorum enim est haec querela, qui sibi cari sunt seseque diligunt. Quacumque enim ingredimur, in aliqua historia vestigium ponimus.</p>
</div>
<div class=""alert alert-danger"">
    <p>alert alert-danger

    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ergo ita: non posse honeste vivi, nisi honeste vivatur? Quod autem in homine praestantissimum atque optimum est, id deseruit. Ut non sine causa ex iis memoriae ducta sit disciplina. Atqui reperies, inquit, in hoc quidem pertinacem; Quae sunt igitur communia vobis cum antiquis, iis sic utamur quasi concessis; Eorum enim est haec querela, qui sibi cari sunt seseque diligunt. Quacumque enim ingredimur, in aliqua historia vestigium ponimus.</p>
</div>
<div class=""alert alert-success"">
    <p>alert alert-success

    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ergo ita: non posse honeste vivi, nisi honeste vivatur? Quod autem in homine praestantissimum atque optimum est, id deseruit. Ut non sine causa ex iis memoriae ducta sit disciplina. Atqui reperies, inquit, in hoc quidem pertinacem; Quae sunt igitur communia vobis cum antiquis, iis sic utamur quasi concessis; Eorum enim est haec querela, qui sibi cari sunt seseque diligunt. Quacumque enim ingredimur, in aliqua historia vestigium ponimus.</p>
</div>
<div class=""alert alert-info"">
    <p>alert alert-info

    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ergo ita: non posse honeste vivi, nisi honeste vivatur? Quod autem in homine praestantissimum atque optimum est, id deseruit. Ut non sine causa ex iis memoriae ducta sit disciplina. Atqui reperies, inquit, in hoc quidem pertinacem; Quae sunt igitur communia vobis cum antiquis, iis sic utamur quasi concessis; Eorum enim est haec querela, qui sibi cari sunt seseque diligunt. Quacumque enim ingredimur, in aliqua historia vestigium ponimus.</p>
</div>";

            }

            return markdown;
        }

        private string GetFullFileName(string name)
        {
            return Path.Combine(Folder, name + ".md");
        }

        public bool MarkdownExists(string path)
        {
            var fileName = StripLeadingSlash(path);
            fileName = GetFullFileName(fileName);

            return File.Exists(fileName);
        }

        private string StripLeadingSlash(string path)
        {
            if (path.StartsWith("/"))
            {
                return path.Substring(1);
            }

            return path;
        }
    }
}