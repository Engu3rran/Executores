using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Executores.TestsUnitaires
{
    [TestClass]
    public class TestEntrepotSessionMock
    {
        private IEntrepotSession _entrepot;

        [TestInitialize]
        public void initialiser()
        {
            _entrepot = new EntrepotSessionMock();
        }

        [TestMethod]
        public void TestEntrepotSessionMock_peutEnregistrerLaSessionEnCours()
        {
            SessionHTTPMock session = new SessionHTTPMock();
            _entrepot.enregistrerLaSession<SessionHTTPMock>(session);
            Assert.AreEqual(1, _entrepot.donnerLesSessions<SessionHTTPMock>().Count);
            Assert.AreEqual(session.Id, _entrepot.donnerLaSessionEnCours<SessionHTTPMock>().Id);
        }

        [TestMethod]
        public void TestEntrepotSessionMock_peutSupprimerLaSessionEnCours()
        {
            SessionHTTPMock session = new SessionHTTPMock();
            _entrepot.enregistrerLaSession<SessionHTTPMock>(session);
            _entrepot.supprimerLaSession<SessionHTTPMock>(session);
            Assert.AreEqual(0, _entrepot.donnerLesSessions<SessionHTTPMock>().Count);
            Assert.IsNull(_entrepot.donnerLaSessionEnCours<SessionHTTPMock>());
        }

        [TestMethod]
        public void TestEntrepotSessionMock_peutVoirLaListeDeToutesLesSessions()
        {
            for(int i = 0; i < 10; i++)
            {
                SessionHTTPMock session = new SessionHTTPMock();
                _entrepot.enregistrerLaSession<SessionHTTPMock>(session);
            }
            Assert.AreEqual(10, _entrepot.donnerLesSessions<SessionHTTPMock>().Count);
        }
    }
}
