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

        public static readonly AdresseMessageMock MESSAGE_ADRESSE_VIDE = new AdresseMessageMock();
        public static readonly AdresseMessageMock MESSAGE_ADRESSE_POSTALE_VALIDE = new AdresseMessageMock() { Voie = "7, rue pouet", Complément = "Appartement 3", CodePostal = CODE_POSTAL_VALIDE.ToString(), Commune = "Bruges" };

        public static readonly EntrepriseMessageMock MESSAGE_ENTREPRISE_VIDE = new EntrepriseMessageMock();
        public static readonly EntrepriseMessageMock MESSAGE_ENTREPRISE_VALIDE = new EntrepriseMessageMock() { Nom = "Epsilone inc.", AdressePostale = MESSAGE_ADRESSE_POSTALE_VALIDE, NuméroSIRET = NUMERO_SIRET_VALIDE.ToString() };

        public static readonly UtilisateurMessageMock UTILISATEUR_VIDE = new UtilisateurMessageMock();
        public static readonly UtilisateurMessageMock UTILISATEUR_VALIDE = new UtilisateurMessageMock() { TypeUtilisateur = (int)TypeUtilisateur.Normal, MotDePasse = MOT_DE_PASSE_VALIDE.déchiffrer(), Civilité = (int)Civilite.Madame, Nom = "Pouet", Prénom = "Poulou", AdresseEmail = ADRESSE_EMAIL_VALIDE.ToString() };
        public static readonly AuthentificationMessageMock AUTHENTIFIER_INVALIDE = new AuthentificationMessageMock();
        public static readonly AuthentificationMessageMock AUTHENTIFIER_VALIDE = new AuthentificationMessageMock() { Login = ADRESSE_EMAIL_VALIDE.ToString(), MotDePasse = MOT_DE_PASSE_VALIDE.déchiffrer() };
    }
}
