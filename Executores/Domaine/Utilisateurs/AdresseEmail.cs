using System.Text.RegularExpressions;

namespace Executores
{
    public class AdresseEmail : ObjetValeurValidable
    {
        public AdresseEmail(string valeur) : base(valeur) { }

        public override bool estValide()
        {
            return estRenseigné()
                && aLaBonneLongueur()
                && aLeBonFormat();
        }

        private bool aLeBonFormat()
        {
            string regex = string.Concat(
                    @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*",
                    "@",
                    @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$"
                    );
            return estVide()
                || Regex.Match(_valeur, regex).Success;
        }

        public override Erreur donnerLErreur()
        {
            if (!estRenseigné())
                return VALIDATION.REQUIS_ADRESSE_EMAIL;
            if (!aLaBonneLongueur())
                return VALIDATION.LONGUEUR_ADRESSE_EMAIL;
            if (!aLeBonFormat())
                return VALIDATION.INVALIDE_ADRESSE_EMAIL;
            return null;
        }
    }
}
