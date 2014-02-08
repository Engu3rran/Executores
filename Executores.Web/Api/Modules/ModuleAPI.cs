using Executores.Commandes;
using Executores.Requetes;
using Nancy;
using Nancy.Json;

namespace Executores.Web
{
    public class ModuleAPI : NancyModule
    {
        protected JavaScriptSerializer _json = new JavaScriptSerializer();
        protected BusCommande _busCommande = new BusCommande();
        protected BusRequete _busRequete = new BusRequete();

        public ModuleAPI()
        {
            _busCommande.utiliserMongo();
            _busRequete.utiliserMongo();
        }
    }
}