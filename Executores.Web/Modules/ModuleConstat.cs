using Nancy;

namespace Executores.Web
{
    public class ModuleConstat : NancyModule
    {
        public ModuleConstat()
        {
            Get["/Constats"] = _ =>
            {
                return View["Constats.html"];
            };
        }
    }
}