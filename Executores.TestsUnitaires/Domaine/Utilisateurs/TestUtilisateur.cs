using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Executores.TestsUnitaires
{
    [TestClass]
    public class TestUtilisateur : TestUnitaire
    {
        private Cabinet _cabinet;

        [TestInitialize]
        public void intialiser()
        {
            _cabinet = new Cabinet();
            _cabinet.modifier(TEST.MESSAGE_ENTREPRISE_VALIDE);
            _cabinet.enregistrer();
        }

        [TestMethod]
        public void TestUtilisateur_uneAuthentificationAvecMauvaisLoginOuMotDePasseEstImpossible()
        {
            créerUnUtilisateur();
            Assert.IsFalse(Utilisateur.authentifier(TEST.MESSAGE_AUTHENTIFIER_INVALIDE));
            SessionUtilisateur sessionEnCours = SessionUtilisateur.chargerLaSessionEnCours();
            Assert.IsNotNull(sessionEnCours);
            Assert.IsFalse(sessionEnCours.estAuthentifié());
        }

        [TestMethod]
        public void TestUtilisateur_uneAhtentificationAvecBonLoginEtMotDePasseRéussit()
        {
            créerUnUtilisateur();
            Assert.IsTrue(Utilisateur.authentifier(TEST.MESSAGE_AUTHENTIFIER_VALIDE));
            SessionUtilisateur sessionEnCours = SessionUtilisateur.chargerLaSessionEnCours();
            Assert.IsNotNull(sessionEnCours);
            Assert.IsTrue(sessionEnCours.estAuthentifié());
        }

        private Utilisateur créerUnUtilisateur()
        {
            Utilisateur utilisateur = new Utilisateur();
            UtilisateurMessageMock message = TEST.MESSAGE_UTILISATEUR_VALIDE;
            message.IdCabinet = _cabinet.Id.ToString();
            utilisateur.modifier(message);
            utilisateur.enregistrer();
            return utilisateur;
        }
    }
}
