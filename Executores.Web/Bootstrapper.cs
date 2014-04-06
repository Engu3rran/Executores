using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;

namespace Executores.Web
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);
            //TODO : param injection
        }
    }
}