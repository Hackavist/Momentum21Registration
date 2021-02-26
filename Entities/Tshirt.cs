using MomentumRegistrationApi.Enums;

namespace MomentumRegistrationApi.Entities
{
    public record Tshirt : MerchItem
    {
        public TshirtSize TshirtSize { get; set; }
    }
}