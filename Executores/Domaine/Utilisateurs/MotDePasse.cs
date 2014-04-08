using System.Text.RegularExpressions;
using Executores.Chiffrement;

namespace Executores
{
    public class MotDePasse : ObjetValeurValidable
    {
        public const int MOT_DE_PASSE_LONGUEUR_MIN = 8;
        private const string SEL = "@apidbnçhbapçbzd";
        private readonly ChiffrementAES _chiffrement = new ChiffrementAES();

        public MotDePasse(string valeurDéchiffrée) : base(valeurDéchiffrée)
        {
            _valeur = _chiffrement.chiffrer(_valeur);
        }

        public string déchiffrer()
        {
            return _chiffrement.déchiffrer(_valeur);
        }

        public override bool estValide()
        {
            return estRenseigné()
                && aLaBonneLongueur()
                && aLaBonneComplexité();
        }

        protected override bool aLaBonneLongueur()
        {
            string valeurDéchiffrée = déchiffrer();
            return _valeur != null
                && valeurDéchiffrée.Length >= MOT_DE_PASSE_LONGUEUR_MIN
                && valeurDéchiffrée.Length <= VALIDATION.CHAINE_LONGUEUR_MAX;
        }

        private bool aLaBonneComplexité()
        {
            string regex = @"^.*(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9]).*$";
            return estVide()
                || Regex.Match(_valeur, regex).Success;
        }

        public override Erreur donnerLErreur()
        {
            if (!estRenseigné())
                return VALIDATION.REQUIS_MOT_DE_PASSE;
            if (!aLaBonneLongueur())
                return VALIDATION.LONGUEUR_MOT_DE_PASSE;
            if (!aLaBonneComplexité())
                return VALIDATION.COMPLEXITE_MOT_DE_PASSE;
            return null;
        }
    }
}
