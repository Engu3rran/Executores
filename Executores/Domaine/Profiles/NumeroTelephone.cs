using System.Text.RegularExpressions;

namespace Executores
{
    public class NumeroTelephone : ObjetValeurValidable
    {
        public  NumeroTelephone(string valeur) : base(valeur) { }

        public override bool estValide()
        {
            return estRenseigné()
                && aLeBonFormat();
        }

        protected bool aLeBonFormat()
        {
            string regex = @"^\d{10}$";
            return estVide()
                || Regex.Match(_valeur, regex).Success;
        }

        public override MessageValidation donnerLErreur()
        {
            if (!estRenseigné())
                return VALIDATION.REQUIS_NUMERO_TELEPHONE;
            if (!aLeBonFormat())
                return VALIDATION.INVALIDE_NUMERO_TELEPHONE;
            return null;
        }
    }
}
