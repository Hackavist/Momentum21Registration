using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MomentumRegistrationApi.Entities;
using MongoDB.Driver;

namespace MomentumRegistrationApi.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(Guid id);
        Task<long> InsertAsync(T item);
        Task<IEnumerable<long>> InsertManyAsync(IEnumerable<T> items);
        Task<ReplaceOneResult> UpdateAsync(T item);
        Task<DeleteResult> DeleteAsync(Guid itemId);
    }
}