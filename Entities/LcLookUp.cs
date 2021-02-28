using MomentumRegistrationApi.Entities;
using MomentumRegistrationApi.Enums;

namespace Entities
{
    public record LcLookUp : BaseEntity
    {
        public LocalCommittee LocalCommitteeId { get; init; }
        public string Name{ get; init; }
        public string Code{ get; init; }
    }
}