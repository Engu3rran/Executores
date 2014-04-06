using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Executores.TestsUnitaires.Domaine.Utilisateurs
{
    [TestClass]
    public class TestMotDePasse
    {
        [TestMethod]
        public void TestMotDePasse_unMotDePassePeutEtreDéchiffré()
        {
            string motDePasseDéchiffré = "p0uEtPou3t!:";
            MotDePasse motDePasse = new MotDePasse(motDePasseDéchiffré); ;
            Assert.AreNotEqual(motDePasseDéchiffré, motDePasse.ToString());
            Assert.AreEqual(motDePasseDéchiffré, motDePasse.déchiffrer());
        }

        [TestMethod]
        public void TestMotDePasse_unMotDePasseValideEstValide()
        {
            MotDePasse motDePasse = TEST.MOT_DE_PASSE_VALIDE;
            Assert.IsTrue(motDePasse.estValide());
        }

        [TestMethod]
        public void TestMotDePasse_unMotDePasseVideEstInvalide()
        {
            MotDePasse motDePasse = new MotDePasse();
            Assert.IsFalse(motDePasse.estValide());
            Assert.AreEqual(VALIDATION.REQUIS_MOT_DE_PASSE, motDePasse.donnerLErreur());
        }

        [TestMethod]
        public void TestMotDePasse_unMotDePasseTropCourtEstInvalide()
        {
            MotDePasse motDePasse = new MotDePasse(TEST.CHAINEx7);
            Assert.IsFalse(motDePasse.estValide());
            Assert.AreEqual(VALIDATION.LONGUEUR_MOT_DE_PASSE, motDePasse.donnerLErreur());
        }

        [TestMethod]
        public void TestMotDePasse_unMotDePasseTropLongEstInvalide()
        {
            MotDePasse motDePasse = new MotDePasse(TEST.CHAINEx257);
            Assert.IsFalse(motDePasse.estValide());
            Assert.AreEqual(VALIDATION.LONGUEUR_MOT_DE_PASSE, motDePasse.donnerLErreur());
        }

        [TestMethod]
        public void TestMotDePasse_unMotDePassePasAssezComplexeEstInvalide()
        {
            MotDePasse motDePasse = new MotDePasse("admin123");
            Assert.IsFalse(motDePasse.estValide());
            Assert.AreEqual(VALIDATION.COMPLEXITE_MOT_DE_PASSE, motDePasse.donnerLErreur());
        }
    }
}
