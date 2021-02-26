using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MomentumRegistrationApi.Entities;
using MomentumRegistrationApi.Settings;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MomentumRegistrationApi.Repository.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {

        // private readonly IMongoClient mongoClient;
        private readonly IMongoCollection<T> Collection;
        private readonly FilterDefinitionBuilder<T> filterBuilder = Builders<T>.Filter;

        public Repository(CustomMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(mongoClient.DatabaseName);
            Collection = database.GetCollection<T>(nameof(T));
        }

        public DeleteResult Delete(Guid itemId)
        {
            var filter = filterBuilder.Eq(item => item.Id, itemId);
            return Collection.DeleteOne(filter);
        }

        public T Get(Guid id)
        {
            var filter = filterBuilder.Eq(item => item.Id, id);
            return Collection.Find(filter).SingleOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return Collection.AsQueryable();
        }

        public long Insert(T item)
        {
            try
            {
                Collection.InsertOne(item);
                return Collection.CountDocuments(filterBuilder.Empty);
            }
            catch (MongoWriteException mwx)
            {
                throw mwx;
            }
        }

        public IEnumerable<long> InsertMany(IEnumerable<T> items)
        {
            try
            {
                var before = Collection.CountDocuments(filterBuilder.Empty);
                Collection.InsertMany(items);
                var after = Collection.CountDocuments(filterBuilder.Empty);
                var insertedIds = new List<long>();
                for (long q = before; q <= after; q++)
                {
                    insertedIds.Add(q);
                }
                return insertedIds;
            }
            catch (MongoWriteException mwx)
            {
                throw mwx;
            }
        }

        public ReplaceOneResult Update(T item)
        {
            var filter = filterBuilder.Eq(exisitingItem => exisitingItem.Id, item.Id);
            return Collection.ReplaceOne(filter, item);
        }
    }
}