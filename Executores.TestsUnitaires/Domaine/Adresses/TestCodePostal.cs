using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Executores.TestsUnitaires
{
    [TestClass]
    public class TestCodePostal
    {
        [TestMethod]
        public void TestCodePostal_unCodePostalValideEstValide()
        {
            CodePostal codePostal = TEST.CODE_POSTAL_VALIDE;
            Assert.IsTrue(codePostal.estValide());
        }

        [TestMethod]
        public void TestCodePostal_unCodePostalVideEstInvalide()
        {
            CodePostal codePostal = new CodePostal();
            Assert.IsFalse(codePostal.estValide());
            Assert.AreEqual(VALIDATION.REQUIS_CODE_POSTAL, codePostal.donnerLErreur());
        }

        [TestMethod]
        public void TestCodePostal_unCodePostalFaitMoinsDe5CaractèresEstInvalide()
        {
            CodePostal codePostal = new CodePostal("0000");
            Assert.IsFalse(codePostal.estValide());
            Assert.AreEqual(VALIDATION.LONGUEUR_CODE_POSTAL, codePostal.donnerLErreur());
        }

        [TestMethod]
        public void TestCodePostal_unCodePostalFaitPlusDe5CaractèresEstInvalide()
        {
            CodePostal codePostal = new CodePostal("000000");
            Assert.IsFalse(codePostal.estValide());
            Assert.AreEqual(VALIDATION.LONGUEUR_CODE_POSTAL, codePostal.donnerLErreur());
        }

        [TestMethod]
        public void TestCodePostal_unCodePostalQuiNeContientPasQueDesChiffresEstInvalide()
        {
            CodePostal codePostal = new CodePostal("0A000");
            Assert.IsFalse(codePostal.estValide());
            Assert.AreEqual(VALIDATION.INVALIDE_CODE_POSTAL, codePostal.donnerLErreur());
        }
    }
}
