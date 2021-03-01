using System;
using MomentumRegistrationApi.Dtos;
using MomentumRegistrationApi.Entities;

namespace MomentumRegistrationApi.Extensions
{
    public static class MerchandiseExtensions
    {
        public static MerchandiseResponseDto AsResponseDto(this MerchItem item)
        {

            return new MerchandiseResponseDto
            {
                Id = item.Id,
                CreationDateTime = item.CreationDateTime,
                Type = item.Type,
                Price = item.Price,
                ImageBase64 = Helpers.Helpers.StringFromByteArray(item.ImageBytes)
            };
        }

        public static MerchItem AsMerchItem(this MerchandiseRequestDto item)
        {

            return new MerchItem
            {
                Id = Guid.NewGuid(),
                CreationDateTime = DateTimeOffset.UtcNow,
                Price = item.Price,
                Type = item.Type,
                ImageBytes = Helpers.Helpers.ByteArrayFromBase64String(item.ImageBase64)
            };
        }
    }
}