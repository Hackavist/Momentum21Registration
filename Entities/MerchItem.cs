using MomentumRegistrationApi.Enums;

namespace MomentumRegistrationApi.Entities
{
    public record MerchItem : BaseEntity
    {
        public byte[] ImageBytes { get; set;}
        public decimal Price { get; set;}
        public MerchandiseType Type { get; set; }

    }
}