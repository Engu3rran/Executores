using System;
using Executores.Commandes;
using Executores.Entrepots;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Executores.TestsUnitaires.Domaine.Commandes.Constats
{
    [TestClass]
    public class TestCreerConstatCommande
    {
        private BusCommande _bus;

        [TestInitialize]
        public void initialiser()
        {
            _bus = new BusCommande();
            _bus.utiliserUnModule(new ModuleEntrepotMock());
        }

        [TestMethod]
        public void TestCreerConstatCommande_peutCréerUnConstat()
        {
            Guid idGénéré;
            ICreerConstatMessageCommande message = new CreerConstatMessageMock();
            ReponseCommande réponse = _bus.exécuter(message);
            Assert.IsTrue(réponse.Réussite);
            Assert.IsNotNull(réponse.ValidationFormulaire);
            Assert.IsTrue(Guid.TryParse(réponse.ValidationFormulaire["Id"], out idGénéré));
            Constat constatRécupéré = FabriqueEntrepot.construire<IEntrepotConstat>().récupérer(idGénéré);
            Assert.IsNotNull(constatRécupéré);
        }
    }

    public class CreerConstatMessageMock : ICreerConstatMessageCommande
    {
        
    }
}
