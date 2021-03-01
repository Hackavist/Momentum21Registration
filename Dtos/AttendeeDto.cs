using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MomentumRegistrationApi.Entities;
using MomentumRegistrationApi.Enums;

namespace MomentumRegistrationApi.Dtos
{
    public record AttendeeRegistrationResponseDto
    {
        public Guid Id { get; init; }
        public DateTimeOffset CreationDateTime { get; init; }
        public string FullName { get; set; }
        public char Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public LocalCommittee Lc { get; set; }
        public Function Function { get; set; }
        public Role Role { get; set; }
        public string FacebookLink { get; set; }
        public AttendeeMedia NeededMedia { get; set; }
        public List<AttendeeMerch> SelectedMerch { get; set; }
    }


    public record AttendeeRegistrationRequestDto
    {
        // [Required]
        // [Range(0, 8)]
        [Required]
        public string FullName { get; set; }
        [Required]
        public char Gender { get; set; }
        [Required]
        [StringLength(11)]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required]
        public LocalCommittee Lc { get; set; }
        [Required]
        public Function Function { get; set; }
        [Required]
        public Role Role { get; set; }
        [Required]
        public string FacebookLink { get; set; }
        public AttendeeMedia NeededMedia { get; set; }
        public List<AttendeeMerch> SelectedMerch { get; set; }
    }
}