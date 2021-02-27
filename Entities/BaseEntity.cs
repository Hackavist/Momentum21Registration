using System;
using MongoDB.Bson.Serialization.Attributes;

namespace MomentumRegistrationApi.Entities
{
    public record BaseEntity
    {
        [BsonId]
        public Guid Id { get; init ;}

        public long RegistrationNumber { get; set;}
        public DateTimeOffset CreationDateTime { get; init; }
    }
}