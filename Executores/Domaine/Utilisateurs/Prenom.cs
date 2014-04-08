
namespace Executores
{
    public class Prenom : ObjetValeurValidable
    {
        public Prenom(string valeur) : base(valeur) { }

        public override Erreur donnerLErreur()
        {
            if (!estRenseigné())
                return VALIDATION.REQUIS_PRENOM;
            if (!aLaBonneLongueur())
                return VALIDATION.LONGUEUR_PRENOM;
            return null;
        }
    }
}
