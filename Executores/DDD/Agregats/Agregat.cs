using System;

namespace Executores
{
    public abstract class Agregat<T> : IAgregat where T : IAgregat
    {
        protected IEntrepotPersistance _entrepot;

        public Agregat(IEntrepotPersistance entrepot)
        {
            Id = Guid.NewGuid();
            _entrepot = entrepot;
        }

        public Guid Id { get; private set; }
        public DateTime? DateCréation { get; private set; }
        public DateTime? DateModification { get; private set; }
        public DateTime? DateArchivage { get; private set; }

        public void enregistrer()
        {
            if (!DateCréation.HasValue)
                DateCréation = DateTime.Now;
            else
                DateModification = DateTime.Now;
            _entrepot.enregistrer<T>(this);
        }

        public void archiver()
        {
            DateArchivage = DateTime.Now;
            _entrepot.enregistrer<T>(this);
        }

        public void désarchiver()
        {
            DateArchivage = null;
            _entrepot.enregistrer<T>(this);
        }
        
        public void supprimer()
        {
            _entrepot.supprimer<T>(this);
        }
    }
}
