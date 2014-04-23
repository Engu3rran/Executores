using System;

namespace Executores
{
    public class Entite<T> : IEntite, IEnregistrable where T : IEntite
    {
        protected IEntrepotPersistance _entrepot = Fabrique.constuire<IEntrepotPersistance>();

        public Entite()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public void enregistrer()
        {
            _entrepot.enregistrer<T>(this);
        }

        public void supprimer()
        {
            _entrepot.supprimer<T>(this);
        }
    }
}
