using Executores.Commandes;
using Executores.Requetes;

namespace Executores.Web
{
    public class ModuleConstatAPI : ModuleAPI
    {
        public ModuleConstatAPI() : base()
        {
            Get["/Api/Constat"] = _ =>
            {
                IChargerConstatMessageRequete message = new ChargerConstatMessage()
                {
                    IdConstat = this.Request.Query["IdConstat"]
                };
                ReponseRequete réponse = _busRequete.exécuter(message);
                return _json.Serialize(réponse);
            };

            Post["/Api/Constat/Creer"] = _ =>
            {
                ICreerConstatMessageCommande message = new CreerConstatMessage();
                ReponseCommande réponse = _busCommande.exécuter(message);
                return _json.Serialize(réponse);
            };
        }
    }
}