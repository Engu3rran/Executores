
namespace Executores
{
    public class Denomination : ObjetValeurValidable
    {
        public Denomination(string valeur) : base(valeur) 
        {
            _estRequis = true;
        }

        public override MessageValidation donnerLErreur()
        {
            if (!estRenseigné())
                return VALIDATION.REQUIS_DENOMINATION;
            if (!aLaBonneLongueur())
                return VALIDATION.LONGUEUR_DENOMINATION;
            return null;
        }
    }
}
