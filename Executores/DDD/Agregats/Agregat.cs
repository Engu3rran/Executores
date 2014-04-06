using System;

namespace Executores
{
    public abstract class Agregat<T> : IAgregat where T : IAgregat
    {
        protected IEntrepotPersistance _entrepot;

        public Agregat(IEntrepotPersistance entrepot)
        {
            _entrepot = entrepot;
        }

        public Guid Id { get; set; }
        public DateTime? DateCréation { get; set; }
        public DateTime? DateModification { get; set; }
        public DateTime? DateArchivage { get; set; }

        public void enregistrer()
        {
            if (!DateCréation.HasValue)
                _entrepot.insérer<T>(this);
            else
                _entrepot.modifier<T>(this);
        }

        public void archiver()
        {
            _entrepot.archiver<T>(this);
        }

        public void désarchiver()
        {
            _entrepot.désarchiver<T>(this);
        }
        
        public void supprimer()
        {
            _entrepot.supprimer<T>(this);
        }
    }
}
