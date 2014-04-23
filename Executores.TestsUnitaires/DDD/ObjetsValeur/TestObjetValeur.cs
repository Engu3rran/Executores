using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

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
            ObjetValeur unObjet = new ObjetValeurMock(valeur);
            ObjetValeur unObjetIdentique = new ObjetValeurMock(valeur);
            ObjetValeur unObjetDifférent = new ObjetValeurMock(autreValeur);
            Assert.IsTrue(unObjet == unObjetIdentique);
            Assert.IsFalse(unObjet == unObjetDifférent);
        }
    }
}
