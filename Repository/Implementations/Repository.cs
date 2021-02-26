using System;
using System.Collections.Generic;
using System.Linq;
using MomentumRegistrationApi.Entities;

namespace MomentumRegistrationApi.Repository.Implementations
{
    public class Repository<T> : IRepository<T> where T :BaseEntity
    {
        public IEnumerable<T> Collection = new List<T>();
        public T Get(Guid id)
        {
            return Collection.Where(x=>x.Id==id).SingleOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return Collection;
        }
    }
}