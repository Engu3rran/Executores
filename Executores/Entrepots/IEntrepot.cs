using System;

namespace Executores
{
    public interface IEntrepot<T> : IEntrepot where T : IAgregat
    {
        bool ajouter(IAgregat agrégat);
        bool modifier(IAgregat agrégat);
        bool supprimer(IAgregat agrégat);
        T récupérer(Guid id);
    }

    public interface IEntrepot
    {
        
    }
}
