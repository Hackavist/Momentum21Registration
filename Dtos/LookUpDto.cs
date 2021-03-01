using MomentumRegistrationApi.Enums;

namespace MomentumRegistrationApi.Dtos
{
    public record LookUpRequestDto
    {
        public LocalCommittee LocalCommitteeId { get; init; }
        
        public string Code{ get; init; }
    }
        public record LookUpResponseDto
    {
        public LocalCommittee LocalCommitteeId { get; init; }
        public string Name{ get; init; }        
    }
}