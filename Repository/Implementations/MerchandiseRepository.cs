using MomentumRegistrationApi.Entities;
using MomentumRegistrationApi.Settings;

namespace MomentumRegistrationApi.Repository.Implementations
{
    public interface IMerchandiseRepository : IRepository<MerchItem>
    {
        
    }
    public class MerchandiseRepository : Repository<MerchItem>, IMerchandiseRepository
    {
        public MerchandiseRepository(ICustomMongoClient mongoClient) : base(mongoClient) { }

    }
}
