
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SoftApp.Exceptions.Middleware;
using SoftApp.MongoDB;
using SoftApp.MongoDB.JsonUpload;
using SoftApp.MongoDB.MongoDB;
using SoftApp.MongoDB.Repository;
using SoftApp_MongoDB.Models;
using SoftApp_MongoDB.Services;
using System.Configuration;
using System.Reflection;

namespace SoftApp_MongoDB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //builder.Services.MongoDBConfigurationService(builder);

            builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDbSettings"));
            builder.Services.AddSingleton<MongoDbContext>();

            builder.Services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
            builder.Services.AddScoped(typeof(JsonUploadForMongo<>));
            builder.Services.AddTransient<IJsonUploadService, JsonUploadService>();
            builder.Services.AddTransient<IUserService, UserService>();

            var app = builder.Build();
            
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseMiddleware<ExceptionHandler>();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }

    }
}