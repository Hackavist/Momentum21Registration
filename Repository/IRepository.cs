using System;
using System.Collections.Generic;
using MomentumRegistrationApi.Entities;

namespace MomentumRegistrationApi.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(Guid id);
        
    }
}