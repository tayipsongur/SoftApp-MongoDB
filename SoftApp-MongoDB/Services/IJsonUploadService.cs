using MongoDB.Bson;
using SoftApp.MongoDB.Models;

namespace SoftApp_MongoDB.Services
{
    public interface IJsonUploadService
    {
        void JsonUpload(string jsonFilePath);
        IEnumerable<Criminals> GetJsonList();
    }
}
