using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using SoftApp.MongoDB.Models;
using SoftApp.MongoDB.MongoDB;

namespace SoftApp.MongoDB.Repository
{
    public class MongoRepository<T> : IMongoRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;
        protected readonly IMongoCollection<BsonDocument> _bsonCollection;

        public MongoRepository(MongoDbContext context)
        {
            _collection = context.GetCollection<T>(typeof(T).Name);
            _bsonCollection = context.GetCollection<BsonDocument>(typeof(T).Name);

        }

        IQueryable<T> IMongoRepository<T>.Collection => _collection.AsQueryable();


        public IQueryable<T> GetAllEntities()
        {
            return _collection.AsQueryable();
        }


        public void Delete(T entity)
        {
            var objectId = entity.GetType().GetProperty("_id").GetValue(entity).ToString();
            _collection.DeleteOne(Builders<T>.Filter.Eq("_id", objectId));
        }

        public T GetById(object id)
        {
            T entity = _collection.Find(Builders<T>.Filter.Eq("_id", id)).FirstOrDefault();
            return entity;
        }

        public void Insert(T entity)
        {
            EntityCheck(entity);

            _collection.InsertOne(entity);
        }

        public void Insert(IList<T> entities)
        {
            if (entities.Any())
            {
                _collection.InsertMany(entities);
            }
        }

        public T Update(T entity)
        {
            EntityCheck(entity);
            var objectId = entity.GetType().GetProperty("_id").GetValue(entity).ToString();
            _collection.ReplaceOne(Builders<T>.Filter.Eq("_id", objectId), entity);

            return entity;
        }

        public void Update(IList<T> entities)
        {

            foreach (var entity in entities)
            {
                {
                    var idProperty = entity.GetType().GetProperty("_id");
                    if (idProperty is null)
                    {
                        throw new ArgumentNullException((nameof(entities)));
                    }

                    var objectId = idProperty.GetValue(entity).ToString();
                    _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", objectId), entity);
                };
            }

        }

        public IEnumerable<T> GetJsonList()
        {
            List<T> entities = new();
            entities = _collection.AsQueryable().ToList();

            return entities;
        }

        /// <summary>
        /// _id, Json dosyasındaki "_id" alanı ve value alanı dolu mu değil mi ? Değilse doldur gönder.
        /// </summary>
        /// <param name="jsonFilePath"></param>
        public void JsonUpload(string jsonFilePath)
        {
            if (!String.IsNullOrEmpty(jsonFilePath))
            {
                var jsonData = File.ReadAllText(jsonFilePath);
                var entities = JsonConvert.DeserializeObject<List<T>>(jsonData);

                var documents = new List<BsonDocument>();

                foreach (var entity in entities)
                {
                    var document = entity.ToBsonDocument();

                    if (!document.Contains("_id") || document["_id"].IsBsonNull)
                    {
                        document["_id"] = ObjectId.GenerateNewId();
                    }

                    documents.Add(document);
                }
                _bsonCollection.InsertMany(documents);
            }
        }


        public void EntityCheck(T entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
        }

        public void EntityListCheck(IList<T> entities)
        {
            if (entities is null) throw new ArgumentNullException(nameof(entities));
        }

    }
}
