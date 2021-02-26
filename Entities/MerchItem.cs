using System;
using MomentumRegistrationApi.Enums;

namespace MomentumRegistrationApi.Entities
{
    public record MerchItem : BaseEntity
    {
        public string ImageBase64 { get; set;}
        public decimal Price { get; set;}
        public MerchandiseType Type { get; set; }

    }
}