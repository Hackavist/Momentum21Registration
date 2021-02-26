using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MomentumRegistrationApi.Entities;
using MongoDB.Driver;

namespace MomentumRegistrationApi.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(Guid id);
        long Insert(T item);
        IEnumerable<long> InsertMany(IEnumerable<T> items);
        ReplaceOneResult Update(T item);
        DeleteResult Delete(Guid itemId);
    }
}