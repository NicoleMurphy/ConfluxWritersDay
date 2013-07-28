namespace ConfluxWritersDay.Web.Repositories
{
    public interface IMarkdownRepository
    {
        bool MarkdownExists(string path);
        string GetMarkdown(string fileName);
    }
}
