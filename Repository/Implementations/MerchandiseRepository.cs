using System;
using System.Collections.Generic;
using MomentumRegistrationApi.Entities;
using MomentumRegistrationApi.Enums;
using MomentumRegistrationApi.Repository;
using MomentumRegistrationApi.Repository.Implementations;

namespace Repository.Implementations
{
    public interface IMerchandiseRepository : IRepository<MerchItem>
    {
        IEnumerable<string> GetTshirtSizes();
    }
    public class MerchandiseRepository : Repository<MerchItem>, IMerchandiseRepository
    {
        public IEnumerable<string> GetTshirtSizes()
        {
            var sizes = new List<string>();
            foreach (var size in Enum.GetValues(typeof(TshirtSize)))
                sizes.Add(size.ToString());
            return sizes;
        }
    }
}