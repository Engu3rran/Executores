using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Executores.TestsUnitaires
{
    [TestClass]
    public class TestEntreprise : TestUnitaire
    {
        [TestMethod]
        public void TestEntreprise_uneEntrepriseVideEstInvalide()
        {
            Entreprise entreprise = new Entreprise();
            entreprise.modifier(TEST.MESSAGE_ENTREPRISE_VIDE);
            Assert.IsFalse(entreprise.estValide());
            ListeMessagesValidation erreurs = entreprise.donnerLesMessagesDeValidation();
            Assert.AreEqual(5, erreurs.Count());
            Assert.IsTrue(erreurs.Any(x => x == VALIDATION.REQUIS_NUMERO_SIRET));
            Assert.IsTrue(erreurs.Any(x => x == VALIDATION.REQUIS_DENOMINATION));
            Assert.IsTrue(erreurs.Any(x => x == VALIDATION.REQUIS_VOIE));
            Assert.IsTrue(erreurs.Any(x => x == VALIDATION.REQUIS_CODE_POSTAL));
            Assert.IsTrue(erreurs.Any(x => x == VALIDATION.REQUIS_COMMUNE));
        }

        [TestMethod]
        public void TestEntreprise_uneEntrepriseValideEstValide()
        {
            Entreprise entreprise = new Entreprise();
            IEntrepriseMessage message = TEST.MESSAGE_ENTREPRISE_VALIDE;
            entreprise.modifier(message);
            Assert.IsTrue(entreprise.estValide());
            Assert.AreEqual(0, entreprise.donnerLesMessagesDeValidation().Count());
        }

        [TestMethod]
        public void TestEntreprise_uneEntrepriseAvecUnNuméroSIRETDéjàPrisEstInvalide()
        {
            Entreprise entrepriseEnregistrée = new Entreprise();
            IEntrepriseMessage message = TEST.MESSAGE_ENTREPRISE_VALIDE;
            entrepriseEnregistrée.modifier(TEST.MESSAGE_ENTREPRISE_VALIDE);
            entrepriseEnregistrée.enregistrer();
            Entreprise entreprise = new Entreprise();
            entreprise.modifier(message);
            Assert.IsFalse(entreprise.estValide());
            ListeMessagesValidation erreurs = entreprise.donnerLesMessagesDeValidation();
            Assert.AreEqual(1, erreurs.Count());
            Assert.IsTrue(erreurs.Any(x => x == VALIDATION.INDISPONIBLE_NUMERO_SIRET));
        }
    }
}
