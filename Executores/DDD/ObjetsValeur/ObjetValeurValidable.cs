
namespace Executores
{
    public abstract class ObjetValeurValidable : ObjetValeur
    {
        protected bool _estRequis = true;

        public ObjetValeurValidable(string valeur) : base(valeur) { }

        public bool estVide()
        {
            return string.IsNullOrEmpty(_valeur);
        }

        public void rendreObligatoire()
        {
            _estRequis = true;
        }

        public void rendreFacultatif()
        {
            _estRequis = false;
        }

        public virtual bool estValide()
        {
            return estRenseigné()
                && aLaBonneLongueur();
        }

        protected virtual bool estRenseigné()
        {
            return !_estRequis
                || !estVide();
        }

        protected virtual bool aLaBonneLongueur()
        {
            return estVide()
                || _valeur.Length <= VALIDATION.CHAINE_LONGUEUR_MAX;
        }

        public abstract Erreur donnerLErreur();
    }
}
