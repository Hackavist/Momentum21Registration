using MongoDB.Driver;

namespace MomentumRegistrationApi.Settings
{
    public class CustomMongoClient : MongoClient, IMongoClient
    {
        public  string DatabaseName {get;init;}
        public CustomMongoClient(string conectionString , string dbname):base(conectionString)
        {
            DatabaseName = dbname;
        }
    }
}
