using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Executores.TestsUnitaires
{
    [TestClass]
    public class TestEntrepotPersistanceMock
    {
        private IEntrepotPersistance _entrepot;

        [TestInitialize]
        public void initialiser()
        {
            _entrepot = new EntrepotPersistanceMock();
        }

        [TestMethod]
        public void TestEntrepotPersistanceMock_peutinsérerUnAgrégat()
        {
            int nombreInitial = _entrepot.prendreLaCollection<IEntite>().Count();
            IEntite entité = new EntiteMock();
            _entrepot.enregistrer<IEntite>(entité);
            int nombreFinal = _entrepot.prendreLaCollection<IEntite>().Count();
            Assert.AreEqual(nombreInitial + 1, nombreFinal);
        }

        [TestMethod]
        public void TestEntrepotPersistanceMock_peutModifierUnAgrégat()
        {
            int nombreInitial = _entrepot.prendreLaCollection<IEntite>().Count();
            IEntite entité = new EntiteMock();
            _entrepot.enregistrer<IEntite>(entité);
            _entrepot.enregistrer<IEntite>(entité);
            int nombreFinal = _entrepot.prendreLaCollection<IEntite>().Count();
            IEntite entitéRécupérée = _entrepot.prendreLaCollection<IEntite>().SingleOrDefault(x => x.Id == entité.Id);
            Assert.IsNotNull(entitéRécupérée);
            Assert.AreEqual(nombreInitial + 1, nombreFinal);
        }

        [TestMethod]
        public void TestEntrepotPersistanceMock_peutSupprimerUnAgrégat()
        {
            IEntite entité = new EntiteMock();
            _entrepot.enregistrer<IEntite>(entité);
            _entrepot.supprimer<IEntite>(entité);
            IEntite entitéRécupérée = _entrepot.prendreLaCollection<IEntite>().SingleOrDefault(x => x.Id == entité.Id);
            Assert.IsNull(entitéRécupérée);
        }
    }
}
