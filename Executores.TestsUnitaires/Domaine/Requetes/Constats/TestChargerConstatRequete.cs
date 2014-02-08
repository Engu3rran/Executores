using System;
using Executores.Entrepots;
using Executores.Requetes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Executores.TestsUnitaires.Domaine.Requetes.Constats
{
    [TestClass]
    public class TestChargerConstatRequete
    {
        private BusRequete _bus;

        [TestInitialize]
        public void initialiser()
        {
            _bus = new BusRequete();
            _bus.utiliserUnModule(new ModuleEntrepotMock());
        }

        [TestMethod]
        public void TestChargerConstatRequete_peutChargerUnConstat()
        {
            Constat constat = new Constat();
            IEntrepotConstat entrepot = FabriqueEntrepot.construire<IEntrepotConstat>();
            entrepot.ajouter(constat);
            IChargerConstatMessageRequete message = new ChargerConstatMessageMock()
            {
                IdConstat = constat.Id.ToString()
            };
            ReponseRequete réponse = _bus.exécuter(message);
            Assert.IsTrue(réponse.Réussite);
            Constat constatRécupéré = réponse.Résultat as Constat;
            Assert.AreEqual(constat.Id, constatRécupéré.Id);
            Assert.AreEqual(constat.DateCréation, constatRécupéré.DateCréation);
        }

        [TestMethod]
        public void TestChargerConstatRequete_chargerLeConstatSansIdDonneLeBonMessage()
        {
            IChargerConstatMessageRequete message = new ChargerConstatMessageMock();
            ReponseRequete réponse = _bus.exécuter(message);
            Assert.IsFalse(réponse.Réussite);
            Assert.AreEqual(CodeMessageBus.ID_CONSTAT_MANQUANT, réponse.CodeMessage);
        }

        [TestMethod]
        public void TestChargerConstatRequete_chargerLeConstatAvecLeMauvaisIdRenvoieLeBonMessage()
        {
            IChargerConstatMessageRequete message = new ChargerConstatMessageMock()
            {
                IdConstat = Guid.NewGuid().ToString()
            };
            ReponseRequete réponse = _bus.exécuter(message);
            Assert.IsFalse(réponse.Réussite);
            Assert.AreEqual(CodeMessageBus.ERREUR_ID_CONSTAT, réponse.CodeMessage);
        }
    }

    public class ChargerConstatMessageMock : IChargerConstatMessageRequete
    {
        public string IdConstat { get; set; }
    }
}
