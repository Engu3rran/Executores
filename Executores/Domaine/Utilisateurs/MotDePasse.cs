using System.Collections;
using System.Text.RegularExpressions;
using Executores.Chiffrement;

namespace Executores
{
    public class MotDePasse : ObjetValeur, IObjetValeurValidable
    {
        public const int MOT_DE_PASSE_LONGUEUR_MIN = 8;
        private const string SEL = "@apidbnçhbapçbzd";
        private readonly ChiffrementAES _chiffrement = new ChiffrementAES();

        public MotDePasse() : base() { }

        public MotDePasse(string valeurDéchiffrée)
        {
            _valeur = _chiffrement.chiffrer(valeurDéchiffrée);
        }

        public string déchiffrer()
        {
            return _chiffrement.déchiffrer(_valeur);
        }

        public bool estValide()
        {
            return estRenseigné()
                && aLaBonneLongueur()
                && aLaBonneComplexité();
        }

        private bool estRenseigné()
        {
            return _valeur != null && _valeur.Length > 0;
        }

        private bool aLaBonneLongueur()
        {
            string valeurDéchiffrée = déchiffrer();
            return _valeur != null
                && valeurDéchiffrée.Length >= MOT_DE_PASSE_LONGUEUR_MIN
                && valeurDéchiffrée.Length <= VALIDATION.CHAINE_LONGUEUR_MAX;
        }

        private bool aLaBonneComplexité()
        {
            if (_valeur != null)
            {
                Regex règle = new Regex(@"^.*(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9]).*$");
                Match comparaison = règle.Match(déchiffrer());
                return comparaison.Success;
            }
            return false;
        }

        public Erreur donnerLErreur()
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
