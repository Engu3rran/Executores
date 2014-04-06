
namespace Executores
{
    public class NumeroSIRET : ObjetValeur, IObjetValeurValidable
    {
        public NumeroSIRET() : base() { }

        public NumeroSIRET(string valeur) : base(valeur) { }

        public bool estValide()
        {
            return estRenseigné()
                && aLaBonneLongueur()
                && estComposéDeChiffres()
                && respecteLAlgorithme();
        }

        private bool estRenseigné()
        {
            return _valeur != null && _valeur.Length > 0;
        }

        private bool aLaBonneLongueur()
        {
            return _valeur != null && _valeur.Length == 14;
        }

        private bool estComposéDeChiffres()
        {
            long valeurConvertie;
            return long.TryParse(_valeur, out valeurConvertie);
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

        public Erreur donnerLErreur()
        {
            if (!estRenseigné())
                return VALIDATION.REQUIS_NUMERO_SIRET;
            if (!aLaBonneLongueur())
                return VALIDATION.LONGUEUR_NUMERO_SIRET;
            if (!estComposéDeChiffres())
                return VALIDATION.INVALIDE_NUMERO_SIRET;
            if (!respecteLAlgorithme())
                return VALIDATION.INVALIDE_NUMERO_SIRET;
            return null;
        }
    }
}
