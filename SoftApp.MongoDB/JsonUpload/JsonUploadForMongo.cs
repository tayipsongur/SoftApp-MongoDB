using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace SoftApp.MongoDB.JsonUpload
{
    public class JsonUploadForMongo<T> where T : class
    {
        protected readonly string _databaseName;
        protected readonly IMongoDatabase _database;
        protected readonly IMongoCollection<T> _collection;
        protected readonly IMongoCollection<BsonDocument> _bsonCollection;

        public JsonUploadForMongo(IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("MongoDbSettings:ConnectionString").Value;
            _databaseName = configuration.GetSection("MongoDbSettings:DatabaseName").Value;

            var mongoClient = new MongoClient(connectionString);
            _database = mongoClient.GetDatabase(_databaseName);
            _collection = _database.GetCollection<T>(typeof(T).Name);
            _bsonCollection = _database.GetCollection<BsonDocument>(typeof(T).Name);
        }

        
    }
}
