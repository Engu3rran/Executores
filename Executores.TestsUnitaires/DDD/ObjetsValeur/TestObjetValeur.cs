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
            ObjetValeur unObjet = new Mock<ObjetValeur>(valeur).Object;
            ObjetValeur unObjetIdentique = new Mock<ObjetValeur>(valeur).Object;
            ObjetValeur unObjetDifférent = new Mock<ObjetValeur>(autreValeur).Object;
            Assert.IsTrue(unObjet == unObjetIdentique);
            Assert.IsFalse(unObjet == unObjetDifférent);
        }
    }
}
