
namespace Executores
{
    public class Nom : ObjetValeurValidable
    {
        public Nom(string valeur) : base(valeur) { }

        public override Erreur donnerLErreur()
        {
            if (!estRenseigné())
                return VALIDATION.REQUIS_NOM;
            if (!aLaBonneLongueur())
                return VALIDATION.LONGUEUR_NOM;
            return null;
        }
    }
}
