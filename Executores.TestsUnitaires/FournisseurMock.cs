using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Executores.TestsUnitaires
{
    class FournisseurMock : IFournisseur
    {
        private IDictionary<string, IList<IAgregat>> _collections;
        private bool _estConnecté;

        public FournisseurMock()
        {
            _collections = new Dictionary<string, IList<IAgregat>>();    
        }

        public bool EstConnecté
        {
            get
            {
                return _estConnecté;
            }
        }

        public bool connecter()
        {
            _estConnecté = true;
            return true;
        }

        public bool déconnecter()
        {
            _estConnecté = false;
            return true;
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

        public bool insérer(IAgregat agrégat)
        {
            try
            {
                string nomDeLaCollection = trouverLeNomDeLaCollectionCorrespondante(agrégat);
                if (_collections.ContainsKey(nomDeLaCollection))
                    return ajouterALaCollection(agrégat, nomDeLaCollection);
                _collections.Add(nomDeLaCollection, new List<IAgregat>());
                agrégat.Id = Guid.NewGuid();
                _collections[nomDeLaCollection].Add(agrégat);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool ajouterALaCollection(IAgregat agrégat, string nomDeLaCollection)
        {
            IList<IAgregat> collection = _collections[nomDeLaCollection];
            if (collection.All(x => !x.Id.Equals(agrégat.Id)))
            {
                agrégat.Id = Guid.NewGuid();
                _collections[nomDeLaCollection].Add(agrégat);
                return true;
            }
            return false;
        }

        public bool modifier(IAgregat agrégat)
        {
            try
            {
                string nomDeLaCollection = trouverLeNomDeLaCollectionCorrespondante(agrégat);
                if (_collections.ContainsKey(nomDeLaCollection))
                    return modifierLaCollection(agrégat, nomDeLaCollection);
                return false;
            }
            catch
            {
                return false;
            }
        }

        private bool modifierLaCollection(IAgregat agrégat, string nomDeLaCollection)
        {
            IList<IAgregat> collection = _collections[nomDeLaCollection];
            if (collection.Any(x => x.Id.Equals(agrégat.Id)))
            {
                _collections[nomDeLaCollection] = _collections[nomDeLaCollection].Where(x => (x as IAgregat).Id != agrégat.Id).ToList();
                _collections[nomDeLaCollection].Add(agrégat);
                return true;
            }
            return false;
        }

        private string trouverLeNomDeLaCollectionCorrespondante(IAgregat agrégat)
        {
            return agrégat.GetType().GetTypeInfo().Name;
        }
    }
}
