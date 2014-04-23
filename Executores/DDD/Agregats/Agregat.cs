using System;
using System.Linq;

namespace Executores
{
    public abstract class Agregat<T> : Entite<T>, IAgregat, IValidable where T : IAgregat
    {
        public Agregat(IEntrepotPersistance entrepot)
        {
            _entrepot = entrepot;
        }

        public Agregat() : base() 
        {
            DateCréation = DateTime.Now;
        }

        public DateTime? DateCréation { get; private set; }
        public DateTime? DateModification { get; private set; }
        public DateTime? DateArchivage { get; private set; }

        public abstract bool estValide();

        public abstract ListeMessagesValidation donnerLesMessagesDeValidation();

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

        public static T charger(string id)
        {
            Guid idConverti = Guid.Parse(id);
            return Fabrique
                .constuire<IEntrepotPersistance>()
                .prendreLaCollection<T>()
                .Single(x => x.Id == idConverti);
        }
    }
}
