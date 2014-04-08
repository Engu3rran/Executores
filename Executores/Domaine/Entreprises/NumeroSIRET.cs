using System.Text.RegularExpressions;

namespace Executores
{
    public class NumeroSIRET : ObjetValeurValidable
    {
        public NumeroSIRET(string valeur) : base(valeur) { }

        public override bool estValide()
        {
            return estRenseigné()
                && aLeBonFormat()
                && respecteLAlgorithme();
        }

        private bool aLeBonFormat()
        {
            string regex = @"^\d{14}$";
            return estVide()
                || Regex.Match(_valeur, regex).Success;
        }

        private bool respecteLAlgorithme()
        {
            int totalDesCoefficients = 0; 
            for (int i = 13; i >= 0; i--)
            {
                int coefficient = int.Parse(_valeur[i].ToString());
                coefficient = traiterUnIndicePair(i, coefficient);
                totalDesCoefficients += coefficient;
            }
            return totalDesCoefficients % 10 == 0;
        }

        private int traiterUnIndicePair(int i, int coefficient)
        {
            if (estPair(i))
                coefficient *= 2;
            if (coefficient > 9)
                coefficient -= 9;
            return coefficient;
        }

        private bool estPair(int indice)
        {
            return (indice) % 2 == 0;
        }

        public override Erreur donnerLErreur()
        {
            if (!estRenseigné())
                return VALIDATION.REQUIS_NUMERO_SIRET;
            if (!aLeBonFormat() || !respecteLAlgorithme())
                return VALIDATION.INVALIDE_NUMERO_SIRET;
            return null;
        }
    }
}
