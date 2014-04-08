using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Executores.TestsUnitaires
{
    [TestClass]
    public class TestObjetValeurValidable
    {
        private ObjetValeurValidable donnerUnMock(string valeur)
        {
            Mock<ObjetValeurValidable> mock = new Mock<ObjetValeurValidable>(valeur);
            mock.CallBase = true;
            return mock.Object;
        }

        [TestMethod]
        public void TestObjetValeurValidable_unObjetValeurVideEstVide()
        {
            ObjetValeurValidable objetValeur = donnerUnMock(null);
            Assert.IsTrue(objetValeur.estVide());
        }

        [TestMethod]
        public void TestObjetValeurValidable_unObjetValeurRenseignéNEstPasVide()
        {
            ObjetValeurValidable objetValeur = donnerUnMock("test");
            Assert.IsFalse(objetValeur.estVide());
        }

        [TestMethod]
        public void TestObjetValeurValidable_unObjetValeurVideObligatoireEstInvalide()
        {
            ObjetValeurValidable objetValeur = donnerUnMock(null);
            objetValeur.rendreObligatoire();
            Assert.IsFalse(objetValeur.estValide());
        }

        [TestMethod]
        public void TestObjetValeurValidable_unObjetValeurVideFacultatifEstValide()
        {
            ObjetValeurValidable objetValeur = donnerUnMock(null);
            objetValeur.rendreFacultatif();
            Assert.IsTrue(objetValeur.estValide());
        }

        [TestMethod]
        public void TestObjetValeurValidable_unObjetValeurRenseignéObligatoireEstValide()
        {
            ObjetValeurValidable objetValeur = donnerUnMock("test");
            objetValeur.rendreObligatoire();
            Assert.IsTrue(objetValeur.estValide());
        }

        [TestMethod]
        public void TestObjetValeurValidable_unObjetValeurRenseignéFacultatifEstValide()
        {
            ObjetValeurValidable objetValeur = donnerUnMock("test");
            objetValeur.rendreFacultatif();
            Assert.IsTrue(objetValeur.estValide());
        }

        [TestMethod]
        public void TestObjetValeurValidable_unObjetValeurRenseignéAvecUneChaineTropLongueEstInvalide()
        {
            ObjetValeurValidable objetValeur = donnerUnMock(TEST.CHAINEx257);
            Assert.IsFalse(objetValeur.estValide());
        }
    }
}
