using Executores.Commandes;
using Executores.Requetes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nancy;
using Nancy.Testing;

namespace Executores.TestsIntegration.Web
{
    [TestClass]
    public class TestScenarioConstat
    {
        [TestMethod]
        public void TestScenarioConstat_peutCréerEtChargerUnConstat()
        {
            DefaultNancyBootstrapper bootstrapper = new DefaultNancyBootstrapper();
            Browser navigateur = new Browser(bootstrapper);
            BrowserResponse réponse = navigateur.Post("/Api/Constat/Creer", (avec) =>
            {
                avec.HttpRequest();
            });
            Assert.AreEqual(HttpStatusCode.OK, réponse.StatusCode);
            ReponseCommande résultatCommande = réponse.Body.DeserializeJson<ReponseCommande>();
            Assert.IsTrue(résultatCommande.Réussite);
            Assert.IsTrue(résultatCommande.ValidationFormulaire.ContainsKey("Id"));
            string idConstat = résultatCommande.ValidationFormulaire["Id"];
            réponse = navigateur.Get("/Api/Constat", (avec) =>
            {
                avec.HttpRequest();
                avec.Query("IdConstat", idConstat);
            });
            Assert.AreEqual(HttpStatusCode.OK, réponse.StatusCode);
            ReponseRequete résultatRequete = réponse.Body.DeserializeJson<ReponseRequete>();
            Assert.IsTrue(résultatRequete.Réussite);
        }
    }
}
