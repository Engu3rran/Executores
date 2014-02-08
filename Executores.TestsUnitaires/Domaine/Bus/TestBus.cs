using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Executores.TestsUnitaires.Domaine.Bus
{
    [TestClass]
    public class TestBus
    {
        [TestMethod]
        public void TestBus_peutExécuterUnInstruction()
        {
            IMessageBusMock message = new MessageBusMock();
            ReponseBusMock réponse = new BusMock().exécuter(message);
            Assert.IsNotNull(réponse);
            Assert.IsTrue(réponse.Réussite);
        }

        [TestMethod]
        public void TestBus_exécuterUnMessageQuiNAAucuneCommandeAssociéRenvoieLeBonCodeDErreur()
        {
            IMauvaisMessageBusMock message = new MauvaisMessageBusMock();
            ReponseBusMock réponse = new BusMock().exécuter(message);
            Assert.IsNotNull(réponse);
            Assert.IsFalse(réponse.Réussite);
            Assert.AreEqual(CodeMessageBus.ERREUR_TYPE_MESSAGE_BUS, réponse.CodeMessage);
        }
    }
}
