
namespace Executores
{
    public class VALIDATION
    {
        //Domaine
        public const int CHAINE_LONGUEUR_MAX = 256;

        //Adresse
        public static readonly MessageValidation REQUIS_VOIE = new MessageValidation("007", "La voie est requise");
        public static readonly MessageValidation LONGUEUR_VOIE = new MessageValidation("008", "La voie doit faire moins de " + CHAINE_LONGUEUR_MAX + " caractères");
        public static readonly MessageValidation LONGUEUR_COMPLEMENT = new MessageValidation("009", "Le complément doit faire moins de " + CHAINE_LONGUEUR_MAX + " caractères");
        public static readonly MessageValidation REQUIS_CODE_POSTAL = new MessageValidation("004", "Le code postal est requis");
        public static readonly MessageValidation INVALIDE_CODE_POSTAL = new MessageValidation("006", "Le code postal est invalide");
        public static readonly MessageValidation REQUIS_COMMUNE = new MessageValidation("010", "La commune est requise");
        public static readonly MessageValidation LONGUEUR_COMMUNE = new MessageValidation("011", "La commune doit faire moins de " + CHAINE_LONGUEUR_MAX + " caractères");

        //Entreprise
        public static readonly MessageValidation REQUIS_NUMERO_SIRET = new MessageValidation("001", "Le numéro SIRET est requis");
        public static readonly MessageValidation INVALIDE_NUMERO_SIRET = new MessageValidation("002", "Le numéro SIRET est invalide");
        public static readonly MessageValidation REQUIS_DENOMINATION = new MessageValidation("003", "La dénomination est requise");
        public static readonly MessageValidation LONGUEUR_DENOMINATION = new MessageValidation("004", "La dénomination doit faire moins de " + CHAINE_LONGUEUR_MAX + " caractères");
        public static readonly MessageValidation INDISPONIBLE_NUMERO_SIRET = new MessageValidation("005", "Le numéro SIRET est déjà utilisé");

        //Utilisateurs
        public static readonly MessageValidation REQUIS_MOT_DE_PASSE = new MessageValidation("101", "Le mot de passe est requis");
        public static readonly MessageValidation LONGUEUR_MOT_DE_PASSE = new MessageValidation("102", "Le mot de passe doit avoir une longueur comprise entre " + MotDePasse.MOT_DE_PASSE_LONGUEUR_MIN + " et " + CHAINE_LONGUEUR_MAX + " caractères");
        public static readonly MessageValidation COMPLEXITE_MOT_DE_PASSE = new MessageValidation("103", "Le mot de passe doit contenir au moins une lettre minuscule, une lettre majuscule, un chiffre et un caractère spécial");
        public static readonly MessageValidation REQUIS_ADRESSE_EMAIL = new MessageValidation("104", "L'adresse e-mail est requise");
        public static readonly MessageValidation LONGUEUR_ADRESSE_EMAIL = new MessageValidation("105", "L'adresse e-mail doit faire moins de " + CHAINE_LONGUEUR_MAX + " caractères");
        public static readonly MessageValidation INVALIDE_ADRESSE_EMAIL = new MessageValidation("106", "L'adresse e-mail est invalide");
        public static readonly MessageValidation REQUIS_NOM = new MessageValidation("107", "Le nom est requis");
        public static readonly MessageValidation LONGUEUR_NOM = new MessageValidation("108", "Le nom doit faire moins de " + CHAINE_LONGUEUR_MAX + " caractères");
        public static readonly MessageValidation REQUIS_PRENOM = new MessageValidation("109", "Le prénom est requis");
        public static readonly MessageValidation LONGUEUR_PRENOM = new MessageValidation("110", "Le prénom doit faire moins de " + CHAINE_LONGUEUR_MAX + " caractères");
    }
}
