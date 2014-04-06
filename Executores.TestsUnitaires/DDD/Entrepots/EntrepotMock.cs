using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Executores.TestsUnitaires
{
    class EntrepotMock : IEntrepotPersistance
    {
        private IDictionary<string, IList<IAgregat>> _collections;

        public EntrepotMock()
        {
            _collections = new Dictionary<string, IList<IAgregat>>();    
        }

        public bool EstConnecté
        {
            get
            {
                return true;
            }
        }

        public IQueryable<T> prendreLaCollection<T>() where T : IAgregat
        {
            string nomDeLaCollection = trouverLeNomDeLaCollectionCorrespondante<T>();
            if (_collections.ContainsKey(nomDeLaCollection))
                return convertirLesEléments<T>(nomDeLaCollection);
            return new List<T>().AsQueryable();
        }

        private IQueryable<T> convertirLesEléments<T>(string nomDeLaCollection) where T : IAgregat
        {
            IList<T> éléments = new List<T>();
            foreach (IAgregat agrégat in _collections[nomDeLaCollection])
                éléments.Add((T)agrégat);
            return éléments.AsQueryable<T>();
        }

        private string trouverLeNomDeLaCollectionCorrespondante<T>()
        {
            return typeof(T).GetTypeInfo().Name;
        }

        public void insérer(IAgregat agrégat)
        {
            try
            {
                agrégat.DateCréation = DateTime.Now;
                string nomDeLaCollection = trouverLeNomDeLaCollectionCorrespondante(agrégat);
                if (_collections.ContainsKey(nomDeLaCollection))
                    ajouterALaCollection(agrégat, nomDeLaCollection);
                _collections.Add(nomDeLaCollection, new List<IAgregat>());
                agrégat.Id = Guid.NewGuid();
                _collections[nomDeLaCollection].Add(agrégat);
            }
            catch(Exception e)
            {
                throw new PersistanceException(e);
            }
        }

        private void ajouterALaCollection(IAgregat agrégat, string nomDeLaCollection)
        {
            IList<IAgregat> collection = _collections[nomDeLaCollection];
            if (collection.All(x => !x.Id.Equals(agrégat.Id)))
            {
                agrégat.Id = Guid.NewGuid();
                _collections[nomDeLaCollection].Add(agrégat);
            }
            else
                throw new PersistanceException("Insertion impossible : Id déjà présent");
        }

        public void modifier(IAgregat agrégat)
        {
            try
            {
                agrégat.DateModification = DateTime.Now;
                string nomDeLaCollection = trouverLeNomDeLaCollectionCorrespondante(agrégat);
                if (_collections.ContainsKey(nomDeLaCollection))
                    modifierLaCollection(agrégat, nomDeLaCollection);
                else
                    throw new PersistanceException("Modification impossible : Collection inexistante");
            }
            catch(Exception e)
            {
                throw new PersistanceException(e);
            }
        }

        public void archiver(IAgregat agrégat)
        {
            try
            {
                agrégat.DateArchivage = DateTime.Now;
                string nomDeLaCollection = trouverLeNomDeLaCollectionCorrespondante(agrégat);
                if (_collections.ContainsKey(nomDeLaCollection))
                    modifierLaCollection(agrégat, nomDeLaCollection);
                else
                    throw new PersistanceException("Modification impossible : Collection inexistante");
            }
            catch (Exception e)
            {
                throw new PersistanceException(e);
            }
        }

        public void désarchiver(IAgregat agrégat)
        {
            try
            {
                agrégat.DateArchivage = null;
                string nomDeLaCollection = trouverLeNomDeLaCollectionCorrespondante(agrégat);
                if (_collections.ContainsKey(nomDeLaCollection))
                    modifierLaCollection(agrégat, nomDeLaCollection);
                else
                    throw new PersistanceException("Modification impossible : Collection inexistante");
            }
            catch (Exception e)
            {
                throw new PersistanceException(e);
            }
        }

        private void modifierLaCollection(IAgregat agrégat, string nomDeLaCollection)
        {
            IList<IAgregat> collection = _collections[nomDeLaCollection];
            if (collection.Any(x => x.Id.Equals(agrégat.Id)))
            {
                _collections[nomDeLaCollection] = _collections[nomDeLaCollection].Where(x => (x as IAgregat).Id != agrégat.Id).ToList();
                _collections[nomDeLaCollection].Add(agrégat);
            }
            else
                throw new PersistanceException("Modification impossible : Id absent de la collection");
        }

        public void supprimer(IAgregat agrégat)
        {
            try
            {
                string nomDeLaCollection = trouverLeNomDeLaCollectionCorrespondante(agrégat);
                if (_collections.ContainsKey(nomDeLaCollection))
                    supprimerDeLaCollection(agrégat, nomDeLaCollection);
                else
                    throw new PersistanceException("Suppression impossible : Collection inexistante");
            }
            catch (Exception e)
            {
                throw new PersistanceException(e);
            }
        }

        private void supprimerDeLaCollection(IAgregat agrégat, string nomDeLaCollection)
        {
            IList<IAgregat> collection = _collections[nomDeLaCollection];
            if (collection.Any(x => x.Id.Equals(agrégat.Id)))
            {
                _collections[nomDeLaCollection] = _collections[nomDeLaCollection].Where(x => (x as IAgregat).Id != agrégat.Id).ToList();
                _collections[nomDeLaCollection].Remove(agrégat);
            }
            else
                throw new PersistanceException("Suppression impossible : Id absent de la collection");
        }

        private string trouverLeNomDeLaCollectionCorrespondante(IAgregat agrégat)
        {
            return agrégat.GetType().GetTypeInfo().Name;
        }
    }
}
