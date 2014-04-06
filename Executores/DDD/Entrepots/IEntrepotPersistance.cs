using System.Linq;

namespace Executores
{
    public interface IEntrepotPersistance
    {
        bool EstConnecté { get;}
        IQueryable<T> prendreLaCollection<T>() where T : IAgregat;
        void insérer<T>(IAgregat agrégat) where T : IAgregat;
        void modifier<T>(IAgregat agrégat) where T : IAgregat;
        void archiver<T>(IAgregat agrégat) where T : IAgregat;
        void désarchiver<T>(IAgregat agrégat) where T : IAgregat;
        void supprimer<T>(IAgregat agrégat) where T : IAgregat;
    }
}
