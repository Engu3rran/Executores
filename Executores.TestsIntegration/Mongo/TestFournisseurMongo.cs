using System;
using System.Linq;
using Executores.Mongo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Executores.TestsIntegration.Mongo
{
    [TestClass]
    public class TestFournisseurMongo
    {
        private IFournisseur _fournisseur;

        [TestInitialize]
        public void initialiser()
        {
            _fournisseur = new FournisseurMongo();
            Assert.IsFalse(_fournisseur.EstConnecté);
            Assert.IsTrue(_fournisseur.connecter());
        }

        [TestCleanup]
        public void nettoyer()
        {
            if (_fournisseur != null)
                _fournisseur.déconnecter();
        }

        [TestMethod]
        public void TestFournisseurMongo_peutSeConnecterALaBaseDeDonnéesDeTest()
        {
            Assert.IsTrue(_fournisseur.EstConnecté);
        }

        [TestMethod]
        public void TestFournisseurMongo_peutinsérerUnAgrégat()
        {
            IQueryable<AgregatMock> collectionAgregatMocks = _fournisseur.prendreLaCollection<AgregatMock>();
            int nombreInitial = collectionAgregatMocks.Count();
            Assert.IsTrue(_fournisseur.insérer(new AgregatMock()));
            int nombreFinal = collectionAgregatMocks.Count();
            Assert.AreEqual(nombreInitial + 1, nombreFinal);
        }

        [TestMethod]
        public void TestFournisseurMongo_peutModifierUnAgrégat()
        {
            AgregatMock agrégat = new AgregatMock();
            Assert.IsTrue(_fournisseur.insérer(agrégat));
            Assert.IsNull(agrégat.DateModification);
            DateTime dateDeTest = new DateTime();
            agrégat.DateModification = dateDeTest;
            Assert.IsTrue(_fournisseur.modifier(agrégat));
            AgregatMock agrégatRécupéré = _fournisseur.prendreLaCollection<AgregatMock>().SingleOrDefault(x => x.Id.Equals(agrégat.Id));
            Assert.IsNotNull(agrégatRécupéré);
            Assert.AreEqual(dateDeTest, agrégatRécupéré.DateModification);
        }
    }
}
