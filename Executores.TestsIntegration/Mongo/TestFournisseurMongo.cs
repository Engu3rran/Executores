using System;
using System.Linq;
using Executores.Mongo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Executores.TestsIntegration.Mongo
{
    [TestClass]
    public class TestEntrepotMongo
    {
        private IEntrepotPersistance _entrepot;

        [TestInitialize]
        public void initialiser()
        {
            _entrepot = new EntrepotMongo();
        }

        [TestMethod]
        public void TestEntrepotMongo_peutSeConnecterALaBaseDeDonnéesDeTest()
        {
            Assert.IsTrue(_entrepot.EstConnecté);
        }

        [TestMethod]
        public void TestEntrepotMongo_peutinsérerUnAgrégat()
        {
            IQueryable<AgregatMock> collectionAgregatMocks = _entrepot.prendreLaCollection<AgregatMock>();
            int nombreInitial = collectionAgregatMocks.Count();
            _entrepot.insérer(new AgregatMock());
            int nombreFinal = collectionAgregatMocks.Count();
            Assert.AreEqual(nombreInitial + 1, nombreFinal);
        }

        [TestMethod]
        public void TestEntrepotMongo_peutModifierUnAgrégat()
        {
            AgregatMock agrégat = new AgregatMock();
            _entrepot.insérer(agrégat);
            Assert.IsNull(agrégat.DateModification);
            _entrepot.modifier(agrégat);
            AgregatMock agrégatRécupéré = _entrepot.prendreLaCollection<AgregatMock>().SingleOrDefault(x => x.Id.Equals(agrégat.Id));
            Assert.IsNotNull(agrégatRécupéré);
            Assert.IsNotNull(agrégatRécupéré.DateModification);
        }
    }
}
