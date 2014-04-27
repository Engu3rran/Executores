using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Executores.TestsUnitaires
{
    [TestClass]
    public class TestClientEntreprise : TestUnitaire
    {
        Entreprise _entreprise;

        [TestInitialize]
        public void initialiser()
        {
            _entreprise = Entreprise.créer(TEST.MESSAGE_ENTREPRISE_VALIDE);
            _entreprise.enregistrer();
        }

        [TestMethod]
        public void TestClientEntreprise_unClientEntrepriseVideEstInvalide()
        {
            ClientEntreprise client = new ClientEntreprise();
            Assert.IsFalse(client.estValide());
            ListeMessagesValidation validation = client.donnerLesMessagesDeValidation();
            Assert.AreEqual(8, validation.Count());
            Assert.IsTrue(validation.Any(x => x == VALIDATION.REQUIS_NOM));
            Assert.IsTrue(validation.Any(x => x == VALIDATION.REQUIS_PRENOM));
            Assert.IsTrue(validation.Any(x => x == VALIDATION.REQUIS_NUMERO_TELEPHONE));
            Assert.IsTrue(validation.Any(x => x == VALIDATION.REQUIS_NUMERO_SIRET));
            Assert.IsTrue(validation.Any(x => x == VALIDATION.REQUIS_DENOMINATION));
            Assert.IsTrue(validation.Any(x => x == VALIDATION.REQUIS_VOIE));
            Assert.IsTrue(validation.Any(x => x == VALIDATION.REQUIS_CODE_POSTAL));
            Assert.IsTrue(validation.Any(x => x == VALIDATION.REQUIS_COMMUNE));
        }

        [TestMethod]
        public void TestClientEntreprise_unClientEntrepriseValideEstValide()
        {
            ClientEntrepriseMessageMock message = TEST.MESSAGE_CLIENT_ENTREPRISE_SANS_ENTREPRISE;
            message.IdEntreprise = _entreprise.Id.ToString();
            ClientEntreprise client = ClientEntreprise.créer(message);
            Assert.IsTrue(client.estValide());
            Assert.AreEqual(0, client.donnerLesMessagesDeValidation().Count());
        }

        [TestMethod]
        public void TestClientEntreprise_unClientAvecDeMauvaisesDonnéesEstInvalide()
        {
            ClientEntreprise client = new ClientEntreprise();
            ClientEntrepriseMessageMock message = new ClientEntrepriseMessageMock();
            message.Nom = TEST.CHAINEx257;
            message.Prénom = TEST.CHAINEx257;
            message.AdresseEmail = TEST.CHAINEx257;
            message.Téléphone = TEST.CHAINEx257;
            message.IdEntreprise = _entreprise.Id.ToString();
            client.modifier(message);
            Assert.IsFalse(client.estValide());
            ListeMessagesValidation validation = client.donnerLesMessagesDeValidation();
            Assert.AreEqual(4, validation.Count());
            Assert.IsTrue(validation.Any(x => x == VALIDATION.LONGUEUR_NOM));
            Assert.IsTrue(validation.Any(x => x == VALIDATION.LONGUEUR_PRENOM));
            Assert.IsTrue(validation.Any(x => x == VALIDATION.INVALIDE_NUMERO_TELEPHONE));
            Assert.IsTrue(validation.Any(x => x == VALIDATION.LONGUEUR_ADRESSE_EMAIL));
        }
    }
}
