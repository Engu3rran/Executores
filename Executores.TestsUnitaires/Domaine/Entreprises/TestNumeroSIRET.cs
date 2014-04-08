using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Executores.TestsUnitaires
{
    [TestClass]
    public class TestNumeroSIRET
    {
        [TestMethod]
        public void TestNumeroSIRET_unNuméroSIRETValideEstValide()
        {
            NumeroSIRET numéroSIRET = TEST.NUMERO_SIRET_VALIDE;
            Assert.IsTrue(numéroSIRET.estValide());
        }

        [TestMethod]
        public void TestNumeroSIRET_unNuméroSIRETVideEstInvalide()
        {
            NumeroSIRET numéroSIRET = new NumeroSIRET(null);
            Assert.IsFalse(numéroSIRET.estValide());
            Assert.AreEqual(VALIDATION.REQUIS_NUMERO_SIRET, numéroSIRET.donnerLErreur());
        }

        [TestMethod]
        public void TestNumeroSIRET_unNuméroSIRETTropLongEstInvalide()
        {
            NumeroSIRET numéroSIRET = new NumeroSIRET("123456789000150");
            Assert.IsFalse(numéroSIRET.estValide());
            Assert.AreEqual(VALIDATION.INVALIDE_NUMERO_SIRET, numéroSIRET.donnerLErreur());
        }

        [TestMethod]
        public void TestNumeroSIRET_unNuméroSIRETTropCourtEstInvalide()
        {
            NumeroSIRET numéroSIRET = new NumeroSIRET("1234567890001");
            Assert.IsFalse(numéroSIRET.estValide());
            Assert.AreEqual(VALIDATION.INVALIDE_NUMERO_SIRET, numéroSIRET.donnerLErreur());
        }

        [TestMethod]
        public void TestNumeroSIRET_unNuméroSIRETQuiNeContientPasUniquementDesChiffresEstInvalides()
        {
            NumeroSIRET numéroSIRET = new NumeroSIRET("a2345678900015");
            Assert.IsFalse(numéroSIRET.estValide());
            Assert.AreEqual(VALIDATION.INVALIDE_NUMERO_SIRET, numéroSIRET.donnerLErreur());
        }

        [TestMethod]
        public void TestNumeroSIRET_unNuméroSIRETQuiNeRespectePasLAlgorithmeEstInvalide()
        {
            NumeroSIRET numéroSIRET = new NumeroSIRET("12345678900014");
            Assert.IsFalse(numéroSIRET.estValide());
            Assert.AreEqual(VALIDATION.INVALIDE_NUMERO_SIRET, numéroSIRET.donnerLErreur());
        }
    }
}
