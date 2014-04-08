using System.Linq;

namespace Executores
{
    public interface IEntrepotPersistance
    {
        bool EstConnecté { get; }
        IQueryable<T> prendreLaCollection<T>() where T : IEntite;
        void enregistrer<T>(IEntite entité) where T : IEntite;
        void supprimer<T>(IEntite entité) where T : IEntite;
    }
}
