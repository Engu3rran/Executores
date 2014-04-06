using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Executores.TestsUnitaires
{
    [TestClass]
    public class TestObjetValeur
    {
        [TestMethod]
        public void TestObjetValeur_peutComparerDeuxObjetsValeurs()
        {
            string valeur = "test";
            string autreValeur = "pouet";
            ObjetValeurMock unObjet = new ObjetValeurMock(valeur);
            ObjetValeurMock unObjetIdentique = new ObjetValeurMock(valeur);
            ObjetValeurMock unObjetDifférent = new ObjetValeurMock(autreValeur);
            Assert.IsTrue(unObjet == unObjetIdentique);
            Assert.IsFalse(unObjet == unObjetDifférent);
            Assert.IsTrue(unObjet.Equals(unObjetIdentique));
            Assert.IsFalse(unObjet.Equals(unObjetDifférent));
            Assert.IsFalse(unObjet.Equals(new object()));
        }

        [TestMethod]
        public void TestObjetValeur_peutDonnerSaValeur()
        {
            string valeur = "test";
            ObjetValeurMock unObjet = new ObjetValeurMock(valeur);
            Assert.AreEqual(valeur, unObjet.ToString());
        }
    }
}
