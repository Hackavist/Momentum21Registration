using System.Threading.Tasks;
using Entities;
using MomentumRegistrationApi.Repository;
using MomentumRegistrationApi.Repository.Implementations;
using MomentumRegistrationApi.Settings;
using MongoDB.Driver;

namespace Repository.Implementations
{
    public interface ILcLookUpRepository : IRepository<LcLookUp>
    {
        Task<LcLookUp> ValidateCode(string code);
    }
    public class LcLookupRepository : Repository<LcLookUp>,ILcLookUpRepository
    {
        public LcLookupRepository(ICustomMongoClient mongoClient) : base(mongoClient) { }
       public  async Task<LcLookUp> ValidateCode(string code){

            var filter = filterBuilder.Eq(item => item.Code, code);
            return await Collection.Find(filter).SingleOrDefaultAsync();
        

        }
    }
}