using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Executores.TestsUnitaires.Domaine.Utilisateurs
{
    [TestClass]
    public class TestAdresseEmail
    {

        [TestMethod]
        public void TestAdresseEmail_uneAdresseEmailValideEstValide()
        {
            AdresseEmail adresseEmail = TEST.ADRESSE_EMAIL_VALIDE;
            Assert.IsTrue(adresseEmail.estValide());
        }

        [TestMethod]
        public void TestAdresseEmail_uneAdresseEmailVideEstInvalide()
        {
            AdresseEmail adresseEmail = new AdresseEmail();
            Assert.IsFalse(adresseEmail.estValide());
            Assert.AreEqual(VALIDATION.REQUIS_ADRESSE_EMAIL, adresseEmail.donnerLErreur());
        }

        [TestMethod]
        public void TestAdresseEmail_uneAdresseEmailTropLongueEstInvalide()
        {
            AdresseEmail adresseEmail = new AdresseEmail(TEST.CHAINEx257);
            Assert.IsFalse(adresseEmail.estValide());
            Assert.AreEqual(VALIDATION.LONGUEUR_ADRESSE_EMAIL, adresseEmail.donnerLErreur());
        }

        [TestMethod]
        public void TestAdresseEmail_uneAdresseEmailInvalideEstInvalide()
        {
            AdresseEmail adresseEmail = new AdresseEmail("pouetpoulouloucom");
            Assert.IsFalse(adresseEmail.estValide());
            Assert.AreEqual(VALIDATION.INVALIDE_ADRESSE_EMAIL, adresseEmail.donnerLErreur());
        }
    }
}
