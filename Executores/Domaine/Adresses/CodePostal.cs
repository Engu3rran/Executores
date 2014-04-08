using System.Text.RegularExpressions;

namespace Executores
{
    public class CodePostal : ObjetValeurValidable
    {
        public CodePostal(string valeur) : base(valeur) { }

        public override bool estValide()
        {
            return estRenseigné()
                && aLeBonFormat();
        }

        private bool aLeBonFormat()
        {
            string regex = @"^\d{5}$";
            return estVide()
                || Regex
                    .Match(_valeur, regex)
                    .Success;
        }

        public override Erreur donnerLErreur()
        {
            if (!estRenseigné())
                return VALIDATION.REQUIS_CODE_POSTAL;
            if (!aLeBonFormat())
                return VALIDATION.INVALIDE_CODE_POSTAL;
            return null;
        }
    }
}
