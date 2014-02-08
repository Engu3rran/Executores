using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Executores.TestsUnitaires.Entrepots
{
    [TestClass]
    public class TestEntrepot
    {
        private EntrepotMock _entrepot;
        private IFournisseur _fournisseur;

        [TestInitialize]
        public void initialiser()
        {
            _fournisseur = new FournisseurMock();
            _entrepot = new EntrepotMock(_fournisseur);    
        }

        [TestMethod]
        public void TestEntrepot_peutAjouter()
        {
            AgregatMock agrégat = new AgregatMock();
            int nombreInitial = _fournisseur.prendreLaCollection<AgregatMock>().Count();
            Assert.IsTrue(_entrepot.ajouter(agrégat));
            int nombreFinal = _fournisseur.prendreLaCollection<AgregatMock>().Count();
            Assert.IsNotNull(agrégat.DateCréation);
            Assert.IsNotNull(agrégat.Id);
            Assert.AreEqual(nombreInitial + 1, nombreFinal);
        }

        [TestMethod]
        public void TestEntrepot_peutModifier()
        {
            AgregatMock agrégat = new AgregatMock();
            Assert.IsTrue(_fournisseur.insérer(agrégat));
            Assert.IsNull(agrégat.DateModification);
            Assert.IsTrue(_entrepot.modifier(agrégat));
            AgregatMock agrégatRécupéré = _fournisseur.prendreLaCollection<AgregatMock>().SingleOrDefault(x => x.Id.Equals(agrégat.Id));
            Assert.IsNotNull(agrégatRécupéré);
            Assert.AreEqual(agrégat.Id, agrégatRécupéré.Id);
            Assert.IsNotNull(agrégatRécupéré.DateModification);
        }

        [TestMethod]
        public void TestEntrepot_peutSupprimer()
        {
            AgregatMock agrégat = new AgregatMock();
            Assert.IsTrue(_fournisseur.insérer(agrégat));
            Assert.IsNull(agrégat.DateSuppression);
            Assert.IsTrue(_entrepot.supprimer(agrégat));
            AgregatMock agrégatRécupéré = _fournisseur.prendreLaCollection<AgregatMock>().SingleOrDefault(x => x.Id.Equals(agrégat.Id));
            Assert.IsNotNull(agrégatRécupéré);
            Assert.AreEqual(agrégat.Id, agrégatRécupéré.Id);
            Assert.IsNotNull(agrégatRécupéré.DateSuppression);
        }

        [TestMethod]
        public void TestEntrepot_peutRécupérer()
        {
            AgregatMock agrégat = new AgregatMock();
            Assert.IsTrue(_fournisseur.insérer(agrégat));
            AgregatMock agrégatRécupéré = _entrepot.récupérer(agrégat.Id);
            Assert.IsNotNull(agrégatRécupéré);
            Assert.AreEqual(agrégat.Id, agrégatRécupéré.Id);
        }
    }
}
