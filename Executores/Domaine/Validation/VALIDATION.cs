
namespace Executores
{
    public class VALIDATION
    {
        //Domaine
        public const int CHAINE_LONGUEUR_MAX = 256;

        //Adresse
        public static readonly Erreur REQUIS_VOIE = new Erreur("007", "La voie est requise");
        public static readonly Erreur LONGUEUR_VOIE = new Erreur("008", "La voie doit faire moins de " + CHAINE_LONGUEUR_MAX + " caractères");
        public static readonly Erreur LONGUEUR_COMPLEMENT = new Erreur("009", "Le complément doit faire moins de " + CHAINE_LONGUEUR_MAX + " caractères");
        public static readonly Erreur REQUIS_CODE_POSTAL = new Erreur("004", "Le code postal est requis");
        public static readonly Erreur INVALIDE_CODE_POSTAL = new Erreur("006", "Le code postal est invalide");
        public static readonly Erreur REQUIS_COMMUNE = new Erreur("010", "La commune est requise");
        public static readonly Erreur LONGUEUR_COMMUNE = new Erreur("011", "La commune doit faire moins de " + CHAINE_LONGUEUR_MAX + " caractères");

        //Entreprise
        public static readonly Erreur REQUIS_NUMERO_SIRET = new Erreur("001", "Le numéro SIRET est requis");
        public static readonly Erreur INVALIDE_NUMERO_SIRET = new Erreur("002", "Le numéro SIRET est invalide");
        public static readonly Erreur REQUIS_DENOMINATION = new Erreur("003", "La dénomination est requise");
        public static readonly Erreur LONGUEUR_DENOMINATION = new Erreur("004", "La dénomination doit faire moins de " + CHAINE_LONGUEUR_MAX + " caractères");
        public static readonly Erreur INDISPONIBLE_NUMERO_SIRET = new Erreur("005", "Le numéro SIRET est déjà utilisé");

        //Utilisateurs
        public static readonly Erreur REQUIS_MOT_DE_PASSE = new Erreur("101", "Le mot de passe est requis");
        public static readonly Erreur LONGUEUR_MOT_DE_PASSE = new Erreur("102", "Le mot de passe doit avoir une longueur comprise entre " + MotDePasse.MOT_DE_PASSE_LONGUEUR_MIN + " et " + CHAINE_LONGUEUR_MAX + " caractères");
        public static readonly Erreur COMPLEXITE_MOT_DE_PASSE = new Erreur("103", "Le mot de passe doit contenir au moins une lettre minuscule, une lettre majuscule, un chiffre et un caractère spécial");
        public static readonly Erreur REQUIS_ADRESSE_EMAIL = new Erreur("104", "L'adresse e-mail est requise");
        public static readonly Erreur LONGUEUR_ADRESSE_EMAIL = new Erreur("105", "L'adresse e-mail doit faire moins de " + CHAINE_LONGUEUR_MAX + " caractères");
        public static readonly Erreur INVALIDE_ADRESSE_EMAIL = new Erreur("106", "L'adresse e-mail est invalide");
        public static readonly Erreur REQUIS_NOM = new Erreur("107", "Le nom est requis");
        public static readonly Erreur LONGUEUR_NOM = new Erreur("108", "Le nom doit faire moins de " + CHAINE_LONGUEUR_MAX + " caractères");
        public static readonly Erreur REQUIS_PRENOM = new Erreur("109", "Le prénom est requis");
        public static readonly Erreur LONGUEUR_PRENOM = new Erreur("110", "Le prénom doit faire moins de " + CHAINE_LONGUEUR_MAX + " caractères");
    }
}
