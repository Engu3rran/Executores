using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Executores.TestsUnitaires
{
    [TestClass]
    public class TestAdressePostale
    {
        [TestMethod]
        public void TestAdressePostale_uneAdressePostaleValideEstValide()
        {
            AdressePostale adressePostale = TEST.ADRESSE_POSTALE_VALIDE;
            Assert.IsTrue(adressePostale.estValide());
        }

        [TestMethod]
        public void TestAdressePostale_uneAdresseVideEstInvalide()
        {
            AdressePostale adressePostale = new AdressePostale();
            Assert.IsFalse(adressePostale.estValide());
            ListeErreurs erreurs = adressePostale.donnerLesErreurs();
            Assert.AreEqual(3, erreurs.Count());
            Assert.IsTrue(erreurs.Any(x => x == VALIDATION.REQUIS_VOIE));
            Assert.IsTrue(erreurs.Any(x => x == VALIDATION.REQUIS_COMMUNE));
        }

        [TestMethod]
        public void TestAdressePostale_uneAdresseAvecDesValeursTropLonguesEstInvalide()
        {
            AdressePostale adressePostale = new AdressePostale() { Voie = TEST.CHAINEx257, Complément = TEST.CHAINEx257, CodePostal = TEST.CODE_POSTAL_VALIDE, Commune = TEST.CHAINEx257 };
            Assert.IsFalse(adressePostale.estValide());
            ListeErreurs erreurs = adressePostale.donnerLesErreurs();
            Assert.AreEqual(3, erreurs.Count());
            Assert.IsTrue(erreurs.Any(x => x == VALIDATION.LONGUEUR_VOIE));
            Assert.IsTrue(erreurs.Any(x => x == VALIDATION.LONGUEUR_COMPLEMENT));
            Assert.IsTrue(erreurs.Any(x => x == VALIDATION.LONGUEUR_COMMUNE));
        }

        [TestMethod]
        public void TestAdressePostale_uneAdressePeutEtreModifiée()
        {
            Mock<IAdressePostaleMessage> mock = new Mock<IAdressePostaleMessage>();
            mock.SetupGet(x => x.Voie).Returns("7, rue pouet");
            mock.SetupGet(x => x.Complément).Returns("Appartement 3");
            mock.SetupGet(x => x.CodePostal).Returns("33520");
            mock.SetupGet(x => x.Commune).Returns("Bruges");
            IAdressePostaleMessage message = mock.Object;
            AdressePostale adressePostale = new AdressePostale();
            adressePostale.modifier(message);
            Assert.AreEqual(message.Voie, adressePostale.Voie);
            Assert.AreEqual(message.Complément, adressePostale.Complément);
            Assert.AreEqual(message.CodePostal, adressePostale.CodePostal.ToString());
            Assert.AreEqual(message.Commune, adressePostale.Commune);
        }
    }
}
