namespace MomentumRegistrationApi.Settings
{
    public class MongoDbSettings
    {
        // public string Host { get; set; }
        public string DbName { get; set; }
        // public int Port { get; set; }
        // public string User { get; set; }
        public string Password { get; set; }
        public string ConnectionString =>$"mongodb+srv://mongoadmin:{Password}@momentumregistrationclu.kkbra.mongodb.net/MomentumRegistration?retryWrites=true&w=majority";

    }
}