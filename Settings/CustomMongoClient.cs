using MongoDB.Driver;

namespace MomentumRegistrationApi.Settings
{
    public interface ICustomMongoClient:IMongoClient{

    }
    public class CustomMongoClient : MongoClient, ICustomMongoClient
    {
        public string DatabaseName {get;init;}
        public CustomMongoClient(string conectionString , string dbname):base(conectionString)
        {
            DatabaseName = dbname;
        }
    }
}
