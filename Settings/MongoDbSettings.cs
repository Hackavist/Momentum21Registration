namespace MomentumRegistrationApi.Settings
{
    public class MongoDbSettings
    {
        public string Host { get; set; }
        public string DbName { get; set; }
        public int Port { get; set; }

        public string ConnectionString =>$"mongodb://{Host}:{Port}";

    }
}