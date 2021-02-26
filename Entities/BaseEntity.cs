using System;
namespace MomentumRegistrationApi.Entities
{
    public record BaseEntity
    {
        public Guid Id { get; init ;}
        public DateTimeOffset CreationDateTime { get; init; }
    }
}