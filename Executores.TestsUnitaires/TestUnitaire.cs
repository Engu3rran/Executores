using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Executores.TestsUnitaires
{
    [TestClass]
    public class TestUnitaire
    {
        [TestInitialize]
        public void initialiserLaFabrique()
        {
            Fabrique.configurerLInjectionDeDépendance(new ModuleInjectionTest());
        }
    }
}
