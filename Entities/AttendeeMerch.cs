using MomentumRegistrationApi.Enums;

namespace MomentumRegistrationApi.Entities
{
    public record AttendeeMerch
    {
        public int Quantity { get; set; }
        public MerchandiseType Type { get; set; }
        public TshirtSize Size { get; set; }
    }
}