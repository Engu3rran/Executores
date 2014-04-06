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
            connecter();
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

        public void insérer<T>(IAgregat agrégat) where T : IAgregat
        {
            agrégat.DateCréation = DateTime.Now;
            enregistrerLAgrégat(agrégat);
        }

        public void modifier<T>(IAgregat agrégat) where T : IAgregat
        {
            agrégat.DateModification = DateTime.Now;
            enregistrerLAgrégat(agrégat);
        }

        public void archiver<T>(IAgregat agrégat) where T : IAgregat
        {
            agrégat.DateArchivage = DateTime.Now;
            enregistrerLAgrégat(agrégat);
        }

        public void désarchiver<T>(IAgregat agrégat) where T : IAgregat
        {
            agrégat.DateArchivage = null;
            enregistrerLAgrégat(agrégat);
        }

        private void enregistrerLAgrégat(IAgregat agrégat)
        {
            try
            {
                string nomDeLaCollection = trouverLeNomDeLaCollectionCorrespondante(agrégat);
                MongoCollection collection = _baseDeDonnées.GetCollection(nomDeLaCollection);
                collection.Save(agrégat);
            }
            catch(Exception e)
            {
                //TODO : log
                throw new PersistanceException(e);
            }
        }

        public void supprimer<T>(IAgregat agrégat) where T : IAgregat
        {
            try
            {
                string nomDeLaCollection = trouverLeNomDeLaCollectionCorrespondante(agrégat);
                MongoCollection collection = _baseDeDonnées.GetCollection(nomDeLaCollection);
                collection.Remove(Query.EQ(agrégat.PropertyName(x => x.Id), agrégat.Id));
            }
            catch (Exception e)
            {
                //TODO : log
                throw new PersistanceException(e);
            }
        }

        private string trouverLeNomDeLaCollectionCorrespondante(IAgregat agrégat)
        {
            return agrégat.GetType().GetTypeInfo().Name;
        }

    }
}
