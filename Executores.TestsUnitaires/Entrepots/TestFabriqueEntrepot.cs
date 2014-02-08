using System;
using Executores.Entrepots;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Executores.TestsUnitaires.Entrepots
{
    [TestClass]
    public class TestFabriqueEntrepot
    {
        [TestMethod]
        public void TestFabriqueEntrepot_peutConstuireUnEntrepot()
        {
            FabriqueEntrepot.chargerUnModule(new ModuleEntrepotMock());
            IEntrepotConstat entrepot = FabriqueEntrepot.construire<IEntrepotConstat>();
            Assert.IsNotNull(entrepot);
        }
    }
}
