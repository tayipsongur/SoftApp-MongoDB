using SoftApp.MongoDB.Models;
using SoftApp.MongoDB.Repository;

namespace SoftApp_MongoDB.Services
{
    public class JsonUploadService : IJsonUploadService
    {
        private readonly IMongoRepository<Criminals> _mongoRepository;
        public JsonUploadService(IServiceProvider serviceProvider)
        {
            _mongoRepository = serviceProvider.GetRequiredService<IMongoRepository<Criminals>>();
        }

        public IEnumerable<Criminals> GetJsonList()
        {
            var jsonList = _mongoRepository.GetJsonList();
            return jsonList;
        }

        public void JsonUpload(string jsonFilePath)
        {
           _mongoRepository.JsonUpload(jsonFilePath);
        }
    }
}
