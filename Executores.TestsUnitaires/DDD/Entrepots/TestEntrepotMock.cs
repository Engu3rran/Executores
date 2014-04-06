using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        public void TestEntrepotMock_peutSeConnecter()
        {
            Assert.IsTrue(_entrepot.EstConnecté);
        }

        [TestMethod]
        public void TestEntrepotMock_peutinsérerUnAgrégat()
        {
            int nombreInitial = _entrepot.prendreLaCollection<AgregatMock>().Count();
            AgregatMock agrégat = new AgregatMock();
            _entrepot.insérer(agrégat);
            int nombreFinal = _entrepot.prendreLaCollection<AgregatMock>().Count();
            Assert.AreEqual(nombreInitial + 1, nombreFinal);
            Assert.IsNotNull(agrégat.DateCréation);
        }

        [TestMethod]
        public void TestEntrepotMock_peutModifierUnAgrégat()
        {
            AgregatMock agrégat = new AgregatMock();
            _entrepot.insérer(agrégat);
            Assert.IsNull(agrégat.DateModification);
            _entrepot.modifier(agrégat);
            AgregatMock agrégatRécupéré = _entrepot.prendreLaCollection<AgregatMock>().SingleOrDefault(x => x.Id.Equals(agrégat.Id));
            Assert.IsNotNull(agrégatRécupéré);
            Assert.IsNotNull(agrégatRécupéré.DateModification);
        }

        [TestMethod]
        public void TestEntrepotMock_peutArchiverUnAgrégat()
        {
            AgregatMock agrégat = new AgregatMock();
            _entrepot.insérer(agrégat);
            Assert.IsNull(agrégat.DateArchivage);
            _entrepot.archiver(agrégat);
            AgregatMock agrégatRécupéré = _entrepot.prendreLaCollection<AgregatMock>().SingleOrDefault(x => x.Id.Equals(agrégat.Id));
            Assert.IsNotNull(agrégatRécupéré);
            Assert.IsNotNull(agrégatRécupéré.DateArchivage);
        }

        [TestMethod]
        public void TestEntrepotMock_peutDésarchiverUnAgrégat()
        {
            AgregatMock agrégat = new AgregatMock();
            _entrepot.insérer(agrégat);
            _entrepot.archiver(agrégat);
            _entrepot.désarchiver(agrégat);
            AgregatMock agrégatRécupéré = _entrepot.prendreLaCollection<AgregatMock>().SingleOrDefault(x => x.Id.Equals(agrégat.Id));
            Assert.IsNotNull(agrégatRécupéré);
            Assert.IsNull(agrégat.DateArchivage);
        }

        [TestMethod]
        public void TestEntrepotMock_peutSupprimerUnAgrégat()
        {
            AgregatMock agrégat = new AgregatMock();
            _entrepot.insérer(agrégat);
            _entrepot.supprimer(agrégat);
            AgregatMock agrégatRécupéré = _entrepot.prendreLaCollection<AgregatMock>().SingleOrDefault(x => x.Id.Equals(agrégat.Id));
            Assert.IsNull(agrégatRécupéré);
        }
    }
}
