using System;
using System.Collections.Generic;
using MomentumRegistrationApi.Entities;
using MomentumRegistrationApi.Enums;
using MomentumRegistrationApi.Repository;
using MomentumRegistrationApi.Repository.Implementations;
using MomentumRegistrationApi.Settings;

namespace Repository.Implementations
{
    public interface IMerchandiseRepository : IRepository<MerchItem>
    {
        
    }
    public class MerchandiseRepository : Repository<MerchItem>, IMerchandiseRepository
    {
        public MerchandiseRepository(ICustomMongoClient mongoClient) : base(mongoClient) { }

    }
}
