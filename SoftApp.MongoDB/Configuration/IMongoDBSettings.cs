﻿namespace SoftApp.MongoDB
{
    public interface IMongoDBSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
