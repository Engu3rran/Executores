
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
    }
}
