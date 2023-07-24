
namespace Play.Catalog.Service.Settings
{
    public class MongoDBSettings 
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string ConnectionString => $"mongodb://{Host}:{Port}";
    }
}
