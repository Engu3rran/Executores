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
            Assert.IsFalse(Utilisateur.authentifier(TEST.AUTHENTIFIER_INVALIDE));
        }

        [TestMethod]
        public void TestUtilisateur_uneAhtentificationAvecBonLoginEtMotDePasseRéussit()
        {
            créerUnUtilisateur();
            Assert.IsTrue(Utilisateur.authentifier(TEST.AUTHENTIFIER_VALIDE));
        }

        private Utilisateur créerUnUtilisateur()
        {
            Utilisateur utilisateur = new Utilisateur();
            UtilisateurMessageMock message = TEST.UTILISATEUR_VALIDE;
            message.IdCabinet = _cabinet.Id.ToString();
            utilisateur.modifier(message);
            utilisateur.enregistrer();
            return utilisateur;
        }
    }
}
