using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Executores.TestsUnitaires
{
    [TestClass]
    public class TestFournisseurMock
    {
        private IFournisseur _fournisseur;

        [TestInitialize]
        public void initialiser()
        {
            _fournisseur = new FournisseurMock();
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
        public void TestFournisseurMock_peutSeConnecter()
        {
            Assert.IsTrue(_fournisseur.EstConnecté);
        }

        [TestMethod]
        public void TestFournisseurMock_()
        {

        }

        [TestMethod]
        public void TestFournisseurMongo_peutinsérerUnAgrégat()
        {
            int nombreInitial = _fournisseur.prendreLaCollection<AgregatMock>().Count();
            Assert.IsTrue(_fournisseur.insérer(new AgregatMock()));
            int nombreFinal = _fournisseur.prendreLaCollection<AgregatMock>().Count();
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
