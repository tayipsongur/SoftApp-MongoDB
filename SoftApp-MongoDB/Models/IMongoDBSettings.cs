namespace SoftApp_MongoDB
{
    public interface IMongoDbConfigurationSettings
    {
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
