using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Executores.TestsUnitaires
{
    [TestClass]
    public class TestUnitaire
    {
        [TestInitialize]
        public void InitialiserLaFabrique()
        {
            Fabrique.configurerLInjectionDeDépendance(new ModuleInjectionTest());
        }
    }
}
