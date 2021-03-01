using System.Collections.Generic;
using MomentumRegistrationApi.Enums;

namespace MomentumRegistrationApi.Entities
{
    public record AttendeeRegistration:BaseEntity
    {
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
}