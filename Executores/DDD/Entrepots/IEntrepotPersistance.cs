using System.Linq;

namespace Executores
{
    public interface IEntrepotPersistance
    {
        bool EstConnecté { get;}
        IQueryable<T> prendreLaCollection<T>() where T : IAgregat;
        void insérer(IAgregat agrégat);
        void modifier(IAgregat agrégat);
        void archiver(IAgregat agrégat);
        void désarchiver(IAgregat agrégat);
        void supprimer(IAgregat agrégat);
    }
}
