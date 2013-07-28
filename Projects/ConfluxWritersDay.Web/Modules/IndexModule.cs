using Nancy;

namespace ConfluxWritersDay.Web.Modules
{
    public class IndexModule : BaseModule
    {
        public IndexModule()
        {
            Get["/"] = parameters =>
            {
                return View["index"];
            };
        }
    }
}