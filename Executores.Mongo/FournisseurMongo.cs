using System;
using System.Linq;
using System.Reflection;
using System.Configuration;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Executores.Mongo
{
    public class FournisseurMongo : IFournisseur
    {
        private const string CHAINE_CONNEXION = "connexionBDDMongo";
        private const string NOM_BASE = "nomBDDMongo";

        private string _chaineDeConnexion;
        private string _nomBase;
        private MongoClient _client;
        private MongoServer _serveur;
        private MongoDatabase _baseDeDonnées;

        public FournisseurMongo()
        {
            _chaineDeConnexion = ConfigurationManager.AppSettings[CHAINE_CONNEXION];
            _nomBase = ConfigurationManager.AppSettings[NOM_BASE];
        }

        public bool EstConnecté
        {
            get
            {
                return _serveur != null
                    && _baseDeDonnées != null
                    && _baseDeDonnées.Name == _nomBase;
            }
        }

        public bool connecter()
        {
            if (!EstConnecté)
            {
                try
                {
                    if(string.IsNullOrEmpty(_chaineDeConnexion) || string.IsNullOrEmpty(_nomBase))
                        throw new Exception("Erreur de configuration de la base de données Mongo");
                    new MappingMongo().enregistrer();
                    _client = new MongoClient(_chaineDeConnexion);
                    _serveur = _client.GetServer();
                    _baseDeDonnées = _serveur.GetDatabase(_nomBase);
                    return EstConnecté;
                }
                catch (Exception e)
                {
                    //TODO : log
                    return false;
                }
            }
            return true;
        }

        public bool déconnecter()
        {
            if (EstConnecté)
            {
                try
                {
                    _serveur.Disconnect();
                    _serveur = null;
                    _client = null;
                    _baseDeDonnées = null;
                }
                catch
                {
                    //TODO : log
                    return false;
                }
            }
            return true;
        }

        public IQueryable<T> prendreLaCollection<T>() where T : IAgregat
        {
            string nomDeLaCollection = trouverLeNomDeLaCollectionCorrespondante<T>();
            if (EstConnecté)
                return _baseDeDonnées.GetCollection<T>(nomDeLaCollection).AsQueryable<T>();
            return null;
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
                MongoCollection collection = _baseDeDonnées.GetCollection(nomDeLaCollection);
                WriteConcernResult résultat = collection.Save(agrégat);
                return résultat.Ok;
            }
            catch
            {
                //TODO : log
                return false;
            }
        }

        public bool modifier(IAgregat agrégat)
        {
            return insérer(agrégat);
        }

        private string trouverLeNomDeLaCollectionCorrespondante(IAgregat agrégat)
        {
            return agrégat.GetType().GetTypeInfo().Name;
        }

    }
}
