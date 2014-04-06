using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;

namespace Executores.TestsUnitaires.Web
{
    class BootstrapperTest : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);
        }
    }
}
