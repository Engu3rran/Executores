using Moq;

namespace Executores.TestsUnitaires
{
    public class TEST
    {
        public const string CHAINEx7 = "aaaaaaa";
        public const string CHAINEx257 = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

        public static readonly MotDePasse MOT_DE_PASSE_VALIDE = new MotDePasse("p0uEtPou3t!:");
        public static readonly AdresseEmail ADRESSE_EMAIL_VALIDE = new AdresseEmail("poulou@poulou.com");
        public static readonly NumeroSIRET NUMERO_SIRET_VALIDE = new NumeroSIRET("12345678900015");
        public static readonly CodePostal CODE_POSTAL_VALIDE = new CodePostal("33520");
        public static readonly AdressePostale ADRESSE_POSTALE_VALIDE = new AdressePostale() { Voie = "7 rue pouet", CodePostal = CODE_POSTAL_VALIDE, Commune = "Poulou" };

        public static readonly Mock<IAdressePostaleMessage> MockAdresseMessage = new Mock<IAdressePostaleMessage>();
        public static IAdressePostaleMessage MESSAGE_ADRESSE_POSTALE_VALIDE
        {
            get
            {
                MockAdresseMessage.SetupGet(x => x.Voie).Returns("7, rue pouet");
                MockAdresseMessage.SetupGet(x => x.Complément).Returns("Appartement 3");
                MockAdresseMessage.SetupGet(x => x.CodePostal).Returns(CODE_POSTAL_VALIDE.ToString());
                MockAdresseMessage.SetupGet(x => x.Commune).Returns("Bruges");
                return MockAdresseMessage.Object;
            }
        }

        public static readonly Mock<IEntrepriseMessage> MockEntrepriseMessage = new Mock<IEntrepriseMessage>();
        public static IEntrepriseMessage MESSAGE_ENTREPRISE_VALIDE
        {
            get
            {
                MockEntrepriseMessage.SetupGet(x => x.NuméroSIRET).Returns(NUMERO_SIRET_VALIDE.ToString());
                MockEntrepriseMessage.SetupGet(x => x.Nom).Returns("Epsilone inc.");
                MockEntrepriseMessage.SetupGet(x => x.AdressePostale).Returns(MESSAGE_ADRESSE_POSTALE_VALIDE);
                return MockEntrepriseMessage.Object;
            }
        }
    }
}
