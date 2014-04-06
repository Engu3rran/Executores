using System;

namespace Executores
{
    public class CodePostal : ObjetValeur, IObjetValeurValidable
    {
        public CodePostal() : base() { }

        public CodePostal(string valeur) : base(valeur) { }

        public bool estValide()
        {
            return estRenseigné()
                && aLaBonneLongueur()
                && estComposéDeChiffres();
        }

        private bool estRenseigné()
        {
            return _valeur != null && _valeur.Length > 0;
        }

        private bool aLaBonneLongueur()
        {
            return _valeur != null && _valeur.Length == 5;
        }

        private bool estComposéDeChiffres()
        {
            int valeurConvertie;
            return int.TryParse(_valeur, out valeurConvertie);
        }

        public Erreur donnerLErreur()
        {
            if (!estRenseigné())
                return VALIDATION.REQUIS_CODE_POSTAL;
            if (!aLaBonneLongueur())
                return VALIDATION.LONGUEUR_CODE_POSTAL;
            if (!estComposéDeChiffres())
                return VALIDATION.INVALIDE_CODE_POSTAL;
            return null;
        }
    }
}
