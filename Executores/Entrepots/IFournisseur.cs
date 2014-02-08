using System.Linq;

namespace Executores
{
    public interface IFournisseur
    {
        bool EstConnecté { get;}
        bool connecter();
        bool déconnecter();
        IQueryable<T> prendreLaCollection<T>() where T : IAgregat;
        bool insérer(IAgregat agrégat);
        bool modifier(IAgregat agrégat);
    }
}
