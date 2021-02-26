using System;
using System.ComponentModel.DataAnnotations;
using MomentumRegistrationApi.Enums;

namespace MomentumRegistrationApi.Dtos
{
    public record MerchandiseResponseDto
    {
        public Guid Id { get; init; }
        public DateTimeOffset CreationDateTime { get; init; }
        public string ImageBase64 { get; set; }
        public decimal Price { get; set; }
        public MerchandiseType Type { get; set; }
        public string MerchTypeName => Type.ToString();
    }


    public record MerchandiseRequestDto
    {
        [Required]
        public string ImageBase64 { get; set; }
        [Required]
        [Range(1, 150)]
        public decimal Price { get; set; }
        [Required]
        [Range(0, 8)]
        public MerchandiseType Type { get; set; }
    }
}
