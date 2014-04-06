using System.Text.RegularExpressions;

namespace Executores
{
    public class AdresseEmail : ObjetValeur, IObjetValeurValidable
    {
        public AdresseEmail() : base() { }

        public AdresseEmail(string valeur) : base(valeur) { }

        public bool estValide()
        {
            return estRenseignée()
                   && aLeBonFormat();
        }

        private bool estRenseignée()
        {
            return !string.IsNullOrEmpty(_valeur);
        }

        private bool aLaBonneLongueur()
        {
            return _valeur != null && _valeur.Length <= VALIDATION.CHAINE_LONGUEUR_MAX;
        }

        private bool aLeBonFormat()
        {
            if (!string.IsNullOrEmpty(_valeur))
            {
                Regex règle = new Regex(
                   string.Concat(
                    @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*",
                    "@",
                    @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$"
                    )
                );
                Match comparaison = règle.Match(_valeur);
                return comparaison.Success;
            }
            return true; 
        }

        public Erreur donnerLErreur()
        {
            if (!estRenseignée())
                return VALIDATION.REQUIS_ADRESSE_EMAIL;
            if (!aLaBonneLongueur())
                return VALIDATION.LONGUEUR_ADRESSE_EMAIL;
            if (!aLeBonFormat())
                return VALIDATION.INVALIDE_ADRESSE_EMAIL;
            return null;
        }
    }
}
