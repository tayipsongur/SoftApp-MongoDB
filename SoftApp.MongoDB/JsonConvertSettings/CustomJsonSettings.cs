using Newtonsoft.Json;

namespace SoftApp.MongoDB.JsonConvertSettings
{
    public  class CustomJsonSettings
    {
        public static  JsonSerializerSettings GetSettings() 
        {
            var settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
            };

            return settings;
        }

    }
}
