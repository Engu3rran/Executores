using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Executores.TestsUnitaires
{
    [TestClass]
    public class TestAdressePostale
    {
        [TestMethod]
        public void TestAdressePostale_uneAdressePostaleValideEstValide()
        {
            AdressePostale adressePostale = new AdressePostale();
            adressePostale.modifier(TEST.MESSAGE_ADRESSE_POSTALE_VALIDE);
            Assert.IsTrue(adressePostale.estValide());
        }

        [TestMethod]
        public void TestAdressePostale_uneAdresseVideEstInvalide()
        {
            AdressePostale adressePostale = new AdressePostale();
            Assert.IsFalse(adressePostale.estValide());
            ListeMessagesValidation erreurs = adressePostale.donnerLesMessagesDeValidation();
            Assert.AreEqual(3, erreurs.Count());
            Assert.IsTrue(erreurs.Any(x => x == VALIDATION.REQUIS_VOIE));
            Assert.IsTrue(erreurs.Any(x => x == VALIDATION.REQUIS_COMMUNE));
        }

        [TestMethod]
        public void TestAdressePostale_uneAdresseAvecDesValeursTropLonguesEstInvalide()
        {
            AdressePostale adressePostale = new AdressePostale() { Voie = TEST.CHAINEx257, Complément = TEST.CHAINEx257, CodePostal = TEST.CODE_POSTAL_VALIDE, Commune = TEST.CHAINEx257 };
            Assert.IsFalse(adressePostale.estValide());
            ListeMessagesValidation erreurs = adressePostale.donnerLesMessagesDeValidation();
            Assert.AreEqual(3, erreurs.Count());
            Assert.IsTrue(erreurs.Any(x => x == VALIDATION.LONGUEUR_VOIE));
            Assert.IsTrue(erreurs.Any(x => x == VALIDATION.LONGUEUR_COMPLEMENT));
            Assert.IsTrue(erreurs.Any(x => x == VALIDATION.LONGUEUR_COMMUNE));
        }

        [TestMethod]
        public void TestAdressePostale_uneAdressePeutEtreModifiée()
        {
            IAdressePostaleMessage message = TEST.MESSAGE_ADRESSE_POSTALE_VALIDE;
            AdressePostale adressePostale = new AdressePostale();
            adressePostale.modifier(message);
            Assert.AreEqual(message.Voie, adressePostale.Voie);
            Assert.AreEqual(message.Complément, adressePostale.Complément);
            Assert.AreEqual(message.CodePostal, adressePostale.CodePostal.ToString());
            Assert.AreEqual(message.Commune, adressePostale.Commune);
        }
    }
}
