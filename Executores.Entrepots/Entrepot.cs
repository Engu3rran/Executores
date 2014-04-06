using System;
using System.Linq;

namespace Executores.Entrepots
{
    public abstract class Entrepot<T> : IEntrepot<T> where T : IAgregat
    {
        protected IEntrepotPersistance _fournisseur;

        public Entrepot(IEntrepotPersistance fournisseur)
        {
            _fournisseur = fournisseur;
            _fournisseur.connecter();
        }

        public bool ajouter(IAgregat agrégat)
        {
            agrégat.DateCréation = DateTime.Now;
            return _fournisseur.insérer(agrégat);
        }

        public bool modifier(IAgregat agrégat)
        {
            agrégat.DateModification = DateTime.Now;
            return _fournisseur.modifier(agrégat);
        }

        public bool supprimer(IAgregat agrégat)
        {
            agrégat.DateSuppression = DateTime.Now;
            return _fournisseur.modifier(agrégat);
        }

        public T récupérer(Guid id)
        {
            return _fournisseur.prendreLaCollection<T>().SingleOrDefault(x => x.Id.Equals(id));
        }
    }
}
