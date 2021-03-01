using System;
using Entities;
using MomentumRegistrationApi.Dtos;

namespace MomentumRegistrationApi.Extensions
{
    public static class LookUpExtensions
    {
        public static LookUpResponseDto AsDto(this LcLookUp lookup)
        {
            return new LookUpResponseDto
            {
                LocalCommitteeId = lookup.LocalCommitteeId,
                Name = lookup.LocalCommitteeId.ToString(),
            };
        }

        public static LcLookUp AsLookUp(this LookUpRequestDto lookup)
        {
            return new LcLookUp
            {
                Id = Guid.NewGuid(),
                CreationDateTime = DateTimeOffset.UtcNow,
                LocalCommitteeId = lookup.LocalCommitteeId,
                Code = lookup.Code
            };
        }
    }
}