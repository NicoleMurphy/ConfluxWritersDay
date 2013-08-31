namespace ConfluxWritersDay.Web.Repositories
{
    public interface IMarkdownRepository
    {
        string GetMarkdown(string fileName);
        bool MarkdownExists(string path);
    }
}
