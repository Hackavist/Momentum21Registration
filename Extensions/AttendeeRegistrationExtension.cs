using System;
using MomentumRegistrationApi.Dtos;
using MomentumRegistrationApi.Entities;
namespace MomentumRegistrationApi.Extensions
{
    public static class AttendeeRegistrationExtension
    {
        public static AttendeeRegistrationResponseDto AsResponseDto(this AttendeeRegistration item)
        {

            return new AttendeeRegistrationResponseDto
            {
                Id = item.Id,
                CreationDateTime = item.CreationDateTime,
                FullName = item.FullName,
                Gender = item.Gender,
                PhoneNumber = item.PhoneNumber,
                Email = item.Email,
                Lc = item.Lc,
                Function=item.Function,
                Role= item.Role,
                FacebookLink=item.FacebookLink,
                NeededMedia = item.NeededMedia,
                SelectedMerch=item.SelectedMerch,
            };
        }
        
        public static AttendeeRegistration AsAttnedee(this AttendeeRegistrationRequestDto item)
        {

            return new AttendeeRegistration
            {
                Id = Guid.NewGuid(),
                CreationDateTime = DateTimeOffset.UtcNow,
                FullName = item.FullName,
                Gender = item.Gender,
                PhoneNumber = item.PhoneNumber,
                Email = item.Email,
                Lc = item.Lc,
                Function=item.Function,
                Role= item.Role,
                FacebookLink=item.FacebookLink,
                NeededMedia = item.NeededMedia,
                SelectedMerch=item.SelectedMerch
            };
        }
    }
}