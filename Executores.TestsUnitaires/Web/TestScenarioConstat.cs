using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nancy;
using Nancy.Testing;

namespace Executores.TestsUnitaires.Web
{
    [TestClass]
    public class TestScenarioConstat
    {
        //[Ignore]
        //[TestMethod]
        //public void TestScenarioConstat_peutCréerEtChargerUnConstat()
        //{
        //    BootstrapperTest bootstrapper = new BootstrapperTest();
        //    Browser navigateur = new Browser(bootstrapper);
        //    BrowserResponse réponse = navigateur.Post("/Api/Constat/Creer", (avec) =>
        //    {
        //        avec.HttpRequest();
        //    });
        //    Assert.AreEqual(HttpStatusCode.OK, réponse.StatusCode);
        //    ReponseCommande résultatCommande = réponse.Body.DeserializeJson<ReponseCommande>();
        //    Assert.IsTrue(résultatCommande.Réussite);
        //    Assert.IsTrue(résultatCommande.ValidationFormulaire.ContainsKey("Id"));
        //    string idConstat = résultatCommande.ValidationFormulaire["Id"];
        //    réponse = navigateur.Get("/Api/Constat", (avec) =>
        //    {
        //        avec.HttpRequest();
        //        avec.Query("IdConstat", idConstat);
        //    });
        //    Assert.AreEqual(HttpStatusCode.OK, réponse.StatusCode);
        //    ReponseRequete résultatRequete = réponse.Body.DeserializeJson<ReponseRequete>();
        //    Assert.IsTrue(résultatRequete.Réussite);
        //}
    }
}
