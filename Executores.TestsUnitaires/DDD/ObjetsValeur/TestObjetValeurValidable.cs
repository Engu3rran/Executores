using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Executores.TestsUnitaires
{
    [TestClass]
    public class TestObjetValeurValidable
    {
        [TestMethod]
        public void TestObjetValeurValidable_unObjetValeurVideEstVide()
        {
            ObjetValeurValidable objetValeur = new ObjetValeurValidableMock(null);
            Assert.IsTrue(objetValeur.estVide());
        }

        [TestMethod]
        public void TestObjetValeurValidable_unObjetValeurRenseignéNEstPasVide()
        {
            ObjetValeurValidable objetValeur = new ObjetValeurValidableMock("test");
            Assert.IsFalse(objetValeur.estVide());
        }

        [TestMethod]
        public void TestObjetValeurValidable_unObjetValeurVideObligatoireEstInvalide()
        {
            ObjetValeurValidable objetValeur = new ObjetValeurValidableMock(null);
            objetValeur.rendreObligatoire();
            Assert.IsFalse(objetValeur.estValide());
        }

        [TestMethod]
        public void TestObjetValeurValidable_unObjetValeurVideFacultatifEstValide()
        {
            ObjetValeurValidable objetValeur = new ObjetValeurValidableMock(null);
            objetValeur.rendreFacultatif();
            Assert.IsTrue(objetValeur.estValide());
        }

        [TestMethod]
        public void TestObjetValeurValidable_unObjetValeurRenseignéObligatoireEstValide()
        {
            ObjetValeurValidable objetValeur = new ObjetValeurValidableMock("test");
            objetValeur.rendreObligatoire();
            Assert.IsTrue(objetValeur.estValide());
        }

        [TestMethod]
        public void TestObjetValeurValidable_unObjetValeurRenseignéFacultatifEstValide()
        {
            ObjetValeurValidable objetValeur = new ObjetValeurValidableMock("test");
            objetValeur.rendreFacultatif();
            Assert.IsTrue(objetValeur.estValide());
        }

        [TestMethod]
        public void TestObjetValeurValidable_unObjetValeurRenseignéAvecUneChaineTropLongueEstInvalide()
        {
            ObjetValeurValidable objetValeur = new ObjetValeurValidableMock(TEST.CHAINEx257);
            Assert.IsFalse(objetValeur.estValide());
        }
    }
}
