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
            Mock<IEntrepriseMessage> mock = new Mock<IEntrepriseMessage>();
            mock.SetupGet(x => x.AdressePostale).Returns(Mock.Of<IAdressePostaleMessage>());
            Entreprise entreprise = Fabrique.constuire<Entreprise>();
            IEntrepriseMessage message = mock.Object;
            entreprise.modifier(message);
            Assert.IsFalse(entreprise.estValide());
            ListeErreurs erreurs = entreprise.donnerLesErreurs();
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
            Entreprise entreprise = Fabrique.constuire<Entreprise>();
            IEntrepriseMessage message = TEST.MESSAGE_ENTREPRISE_VALIDE;
            entreprise.modifier(message);
            Assert.IsTrue(entreprise.estValide());
            Assert.AreEqual(0, entreprise.donnerLesErreurs().Count());
        }

        [TestMethod]
        public void TestEntreprise_uneEntrepriseAvecUnNuméroSIRETDéjàPrisEstInvalide()
        {
            Entreprise entrepriseEnregistrée = Fabrique.constuire<Entreprise>();
            IEntrepriseMessage message = TEST.MESSAGE_ENTREPRISE_VALIDE;
            entrepriseEnregistrée.modifier(message);
            entrepriseEnregistrée.enregistrer();
            Entreprise entreprise = Fabrique.constuire<Entreprise>();
            entreprise.modifier(message);
            Assert.IsFalse(entreprise.estValide());
            ListeErreurs erreurs = entreprise.donnerLesErreurs();
            Assert.AreEqual(1, erreurs.Count());
            Assert.IsTrue(erreurs.Any(x => x == VALIDATION.INDISPONIBLE_NUMERO_SIRET));
        }
    }
}
