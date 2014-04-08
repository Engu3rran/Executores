using System;
using System.Linq;
using System.Reflection;
using System.Configuration;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Builders;

namespace Executores.Mongo
{
    public class EntrepotMongo : IEntrepotPersistance
    {
        private const string CHAINE_CONNEXION = "connexionBDDMongo";
        private const string NOM_BASE = "nomBDDMongo";

        private string _chaineDeConnexion;
        private string _nomBase;
        private MongoClient _client;
        private MongoServer _serveur;
        private MongoDatabase _baseDeDonnées;

        public EntrepotMongo()
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

        private void connecter()
        {
            if (!EstConnecté)
            {
                try
                {
                    if(string.IsNullOrEmpty(_chaineDeConnexion) || string.IsNullOrEmpty(_nomBase))
                        throw new PersistanceException("Erreur de configuration de la base de données Mongo");
                    new MappingMongo().enregistrer();
                    _client = new MongoClient(_chaineDeConnexion);
                    _serveur = _client.GetServer();
                    _baseDeDonnées = _serveur.GetDatabase(_nomBase);
                }
                catch (Exception e)
                {
                    //TODO : log
                    throw new PersistanceException(e);
                }
            }
        }

        public IQueryable<T> prendreLaCollection<T>() where T : IEntite
        {
            connecter();
            string nomDeLaCollection = trouverLeNomDeLaCollectionCorrespondante<T>();
            if (EstConnecté)
                return _baseDeDonnées.GetCollection<T>(nomDeLaCollection).AsQueryable<T>();
            return null;
        }

        private string trouverLeNomDeLaCollectionCorrespondante<T>()
        {
            return typeof(T).GetTypeInfo().Name;
        }

        public void enregistrer<T>(IEntite entité ) where T : IEntite
        {
            connecter();
            try
            {
                string nomDeLaCollection = trouverLeNomDeLaCollectionCorrespondante<T>();
                MongoCollection collection = _baseDeDonnées.GetCollection(nomDeLaCollection);
                collection.Save(entité);
            }
            catch (Exception e)
            {
                //TODO : log
                throw new PersistanceException(e);
            }
        }

        public void supprimer<T>(IEntite entité) where T : IEntite
        {
            connecter();
            try
            {
                string nomDeLaCollection = trouverLeNomDeLaCollectionCorrespondante<T>();
                MongoCollection collection = _baseDeDonnées.GetCollection(nomDeLaCollection);
                collection.Remove(Query.EQ(entité.PropertyName(x => x.Id), entité.Id));
            }
            catch (Exception e)
            {
                //TODO : log
                throw new PersistanceException(e);
            }
        }
    }
}
