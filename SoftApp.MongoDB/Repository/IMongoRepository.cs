using MongoDB.Bson;
using SoftApp.MongoDB.Models;

namespace SoftApp.MongoDB.Repository
{
    public interface IMongoRepository<T> where T : class
    {
        IQueryable<T> Collection { get; }
        IQueryable<T> GetAllEntities();

        T GetById(object id);

        void Insert(T entity);

        void Insert(IList<T> entities);

        T Update(T entity);

        void Update(IList<T> entities);

        bool Delete(T entity);

        IEnumerable<T> GetJsonList();

        void JsonUpload(string jsonFilePath);
    }
}
