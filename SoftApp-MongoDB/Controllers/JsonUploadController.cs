using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using SoftApp.MongoDB.Models;
using SoftApp_MongoDB.Services;

namespace SoftApp_MongoDB.Controllers
{
    [Route("api/[controller]")]
    public class JsonUploadController : ControllerBase
    {
        private readonly IJsonUploadService _jsonUploadService;
        public JsonUploadController(IServiceProvider serviceProvider)
        {
            _jsonUploadService = serviceProvider.GetRequiredService<IJsonUploadService>();
        }

        [HttpPost(nameof(JsonFileUpload))]
        public void JsonFileUpload(string filePath)
        {
            _jsonUploadService.JsonUpload(filePath);
        }

        [HttpGet(nameof(GetJsonList))]
        public IEnumerable<Criminals> GetJsonList()
        {
          return  _jsonUploadService.GetJsonList();
        }
    }
}
