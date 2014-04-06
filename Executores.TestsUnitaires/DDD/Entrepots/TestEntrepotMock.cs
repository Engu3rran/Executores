using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Executores.TestsUnitaires
{
    [TestClass]
    public class TestEntrepotMock
    {
        private IEntrepotPersistance _entrepot;

        [TestInitialize]
        public void initialiser()
        {
            _entrepot = new EntrepotMock();
        }

        [TestMethod]
        public void TestEntrepotMock_peutinsérerUnAgrégat()
        {
            int nombreInitial = _entrepot.prendreLaCollection<IAgregat>().Count();
            IAgregat agrégat = Mock.Of<IAgregat>();
            _entrepot.insérer<IAgregat>(agrégat);
            int nombreFinal = _entrepot.prendreLaCollection<IAgregat>().Count();
            Assert.AreEqual(nombreInitial + 1, nombreFinal);
            Assert.IsNotNull(agrégat.DateCréation);
        }

        [TestMethod]
        public void TestEntrepotMock_peutModifierUnAgrégat()
        {
            IAgregat agrégat = Mock.Of<IAgregat>();
            _entrepot.insérer<IAgregat>(agrégat);
            Assert.IsNull(agrégat.DateModification);
            _entrepot.modifier<IAgregat>(agrégat);
            IAgregat agrégatRécupéré = _entrepot.prendreLaCollection<IAgregat>().SingleOrDefault(x => x.Id.Equals(agrégat.Id));
            Assert.IsNotNull(agrégatRécupéré);
            Assert.IsNotNull(agrégatRécupéré.DateModification);
        }

        [TestMethod]
        public void TestEntrepotMock_peutArchiverUnAgrégat()
        {
            IAgregat agrégat = Mock.Of<IAgregat>();
            _entrepot.insérer<IAgregat>(agrégat);
            Assert.IsNull(agrégat.DateArchivage);
            _entrepot.archiver<IAgregat>(agrégat);
            IAgregat agrégatRécupéré = _entrepot.prendreLaCollection<IAgregat>().SingleOrDefault(x => x.Id.Equals(agrégat.Id));
            Assert.IsNotNull(agrégatRécupéré);
            Assert.IsNotNull(agrégatRécupéré.DateArchivage);
        }

        [TestMethod]
        public void TestEntrepotMock_peutDésarchiverUnAgrégat()
        {
            IAgregat agrégat = Mock.Of<IAgregat>();
            _entrepot.insérer<IAgregat>(agrégat);
            _entrepot.archiver<IAgregat>(agrégat);
            _entrepot.désarchiver<IAgregat>(agrégat);
            IAgregat agrégatRécupéré = _entrepot.prendreLaCollection<IAgregat>().SingleOrDefault(x => x.Id.Equals(agrégat.Id));
            Assert.IsNotNull(agrégatRécupéré);
            Assert.IsNull(agrégat.DateArchivage);
        }

        [TestMethod]
        public void TestEntrepotMock_peutSupprimerUnAgrégat()
        {
            IAgregat agrégat = Mock.Of<IAgregat>();
            _entrepot.insérer<IAgregat>(agrégat);
            _entrepot.supprimer<IAgregat>(agrégat);
            IAgregat agrégatRécupéré = _entrepot.prendreLaCollection<IAgregat>().SingleOrDefault(x => x.Id.Equals(agrégat.Id));
            Assert.IsNull(agrégatRécupéré);
        }
    }
}
