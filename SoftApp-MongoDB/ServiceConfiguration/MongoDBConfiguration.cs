//using Microsoft.Extensions.Options;
//using SoftApp_MongoDB.Models;

//namespace SoftApp_MongoDB.ServiceConfiguration
//{
//    public static class MongoDBConfiguration
//    {
//            public static IServiceCollection MongoDBConfigurationService(this IServiceCollection services, WebApplicationBuilder builder)
//            {
//                services.Configure<MongoDbConfigurationSettings>(builder.Configuration.GetSection(nameof(MongoDbConfigurationSettings)));
//                services.AddSingleton<IMongoDBSettings>(sp => sp.GetRequiredService<IOptions<MongoDbConfigurationSettings>>().Value);
//                return services;
//            }
//    }
//}
