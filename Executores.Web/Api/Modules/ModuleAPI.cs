using Nancy;
using Nancy.Json;

namespace Executores.Web
{
    public class ModuleAPI : NancyModule
    {
        protected JavaScriptSerializer _json = new JavaScriptSerializer();
    }
}