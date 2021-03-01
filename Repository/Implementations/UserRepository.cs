using System.Threading.Tasks;
using MomentumRegistrationApi.Entities;
using MomentumRegistrationApi.Settings;
using MongoDB.Driver;

namespace MomentumRegistrationApi.Repository.Implementations
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> Login(string userName, string password);
        Task<byte[]> GetUserSalt(string userName);
    }
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ICustomMongoClient mongoClient) : base(mongoClient) { }

        public async Task<byte[]> GetUserSalt(string userName)
        {
            var filter = filterBuilder.Eq(x => x.Username, userName.ToLower());
            var user =  await Collection.Find(filter).SingleOrDefaultAsync();
            return user.Salt;
        }

        public async Task<User> Login(string userName, string password)
        {
            var filter = filterBuilder.Eq(x => x.Username, userName.ToLower()) & filterBuilder.Eq(l => l.Password, password);
            return await Collection.Find(filter).SingleOrDefaultAsync();
        }
    }
}
