using System;
using Nancy.TinyIoc;

namespace ConfluxWritersDay.Web.Infrastructure
{
    [Obsolete("todo: where is this used?")]
    public static class IoC
    {
        public static T Resolve<T>() where T : class
        {
            return Container.Resolve<T>();
        }

        private static TinyIoCContainer Container
        {
            get { return TinyIoCContainer.Current; }
        }
    }
}