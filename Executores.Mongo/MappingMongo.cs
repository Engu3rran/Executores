using System;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Options;

namespace Executores.Mongo
{
    internal class MappingMongo
    {
        public void enregistrer()
        {
            enregistrerLesConstats();
        }

        private void enregistrerLesConstats()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(Constat)))
                BsonClassMap.RegisterClassMap<Constat>();
        }
    }
}
