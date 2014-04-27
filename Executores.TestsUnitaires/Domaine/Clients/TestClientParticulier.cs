using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Executores.TestsUnitaires
{
    [TestClass]
    public class TestClientParticulier : TestUnitaire
    {
        [TestMethod]
        public void TestClientParticulier_unClientParticulierVideEstInvalide()
        {
            ClientParticulier client = new ClientParticulier();
            Assert.IsFalse(client.estValide());
            ListeMessagesValidation validation = client.donnerLesMessagesDeValidation();
            Assert.AreEqual(6, validation.Count());
            Assert.IsTrue(validation.Any(x => x == VALIDATION.REQUIS_NOM));
            Assert.IsTrue(validation.Any(x => x == VALIDATION.REQUIS_PRENOM));
            Assert.IsTrue(validation.Any(x => x == VALIDATION.REQUIS_VOIE));
            Assert.IsTrue(validation.Any(x => x == VALIDATION.REQUIS_CODE_POSTAL));
            Assert.IsTrue(validation.Any(x => x == VALIDATION.REQUIS_COMMUNE));
            Assert.IsTrue(validation.Any(x => x == VALIDATION.REQUIS_NUMERO_TELEPHONE));
        }

        [TestMethod]
        public void TestClientParticulier_unClientParticulierValideEstValide()
        {
            ClientParticulier client = ClientParticulier.créer(TEST.MESSAGE_CLIENT_PARTICULIER_VALIDE);
            Assert.IsTrue(client.estValide());
            Assert.AreEqual(0, client.donnerLesMessagesDeValidation().Count());
        }

        [TestMethod]
        public void TestClientParticulier_unClientAvecDeMauvaisesDonnéesEstInvalide()
        {
            ClientParticulier client = new ClientParticulier();
            ClientParticulierMessageMock message = new ClientParticulierMessageMock();
            message.Nom = TEST.CHAINEx257;
            message.Prénom = TEST.CHAINEx257;
            message.AdresseEmail = TEST.CHAINEx257;
            message.Téléphone = TEST.CHAINEx257;
            AdresseMessageMock adresse = new AdresseMessageMock();
            adresse.Voie = TEST.CHAINEx257;
            adresse.Complément = TEST.CHAINEx257;
            adresse.CodePostal = TEST.CHAINEx257;
            adresse.Commune = TEST.CHAINEx257;
            message.AdressePostale = adresse;
            client.modifier(message);
            Assert.IsFalse(client.estValide());
            ListeMessagesValidation validation = client.donnerLesMessagesDeValidation();
            Assert.AreEqual(8, validation.Count());
            Assert.IsTrue(validation.Any(x => x == VALIDATION.LONGUEUR_NOM));
            Assert.IsTrue(validation.Any(x => x == VALIDATION.LONGUEUR_PRENOM));
            Assert.IsTrue(validation.Any(x => x == VALIDATION.INVALIDE_NUMERO_TELEPHONE));
            Assert.IsTrue(validation.Any(x => x == VALIDATION.LONGUEUR_ADRESSE_EMAIL));
            Assert.IsTrue(validation.Any(x => x == VALIDATION.LONGUEUR_VOIE));
            Assert.IsTrue(validation.Any(x => x == VALIDATION.LONGUEUR_COMPLEMENT));
            Assert.IsTrue(validation.Any(x => x == VALIDATION.INVALIDE_CODE_POSTAL));
            Assert.IsTrue(validation.Any(x => x == VALIDATION.LONGUEUR_COMMUNE));
        }
    }
}
