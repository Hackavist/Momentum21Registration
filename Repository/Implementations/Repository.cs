using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MomentumRegistrationApi.Entities;
using MomentumRegistrationApi.Settings;
using MongoDB.Driver;

namespace MomentumRegistrationApi.Repository.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IMongoCollection<T> Collection;
        private readonly FilterDefinitionBuilder<T> filterBuilder = Builders<T>.Filter;

        public Repository(ICustomMongoClient mongoClient)
        {
            var customClient = mongoClient as CustomMongoClient;
            var database = mongoClient.GetDatabase(customClient.DatabaseName);
            Collection = database.GetCollection<T>(nameof(T));
        }

        public async Task<DeleteResult> DeleteAsync(Guid itemId)
        {
            var filter = filterBuilder.Eq(item => item.Id, itemId);
            return await Collection.DeleteOneAsync(filter);
        }

        public async Task<T> GetAsync(Guid id)
        {
            var filter = filterBuilder.Eq(item => item.Id, id);
            return await Collection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Collection.Find(filterBuilder.Empty).ToListAsync();
        }

        public async Task<long> InsertAsync(T item)
        {
            try
            {
                item.RegistrationNumber = await Collection.EstimatedDocumentCountAsync() + 1;
                await Collection.InsertOneAsync(item);
                return item.RegistrationNumber;
            }
            catch (MongoWriteException mwx)
            {
                throw mwx;
            }
        }

        public async Task<IEnumerable<long>> InsertManyAsync(IEnumerable<T> items)
        {
            try
            {
                var currentCount =  await Collection.EstimatedDocumentCountAsync();
                foreach (var item in items)
                {
                    currentCount++;
                    item.RegistrationNumber = currentCount;
                }
               await Collection.InsertManyAsync(items);
               return items.Select(i=>i.RegistrationNumber);
            }
            catch (MongoWriteException mwx)
            {
                throw mwx;
            }
        }

        public async Task<ReplaceOneResult> UpdateAsync(T item)
        {
            var filter = filterBuilder.Eq(exisitingItem => exisitingItem.Id, item.Id);
            return await Collection.ReplaceOneAsync(filter, item);
        }
    }
}