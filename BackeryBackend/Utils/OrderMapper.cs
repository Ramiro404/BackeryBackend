using BackeryBackend.DTOs;
using BackeryBackend.Entities;

namespace BackeryBackend.Utils
{
    public static class OrderMapper
    {
        public static Order ToEntity(this OrderDto dto) => new()
        {
            Id = dto.Id,
            CretedAt =  dto.CreatedAt,
            CustomerId = dto.CustomerId,
            Total = dto.Total,
        };

        public static Order ToEntity(this SaveOrderDto dto) => new()
        {
            CretedAt = dto.CreatedAt,
            CustomerId = dto.CustomerId,
            Total = dto.Total,
        };

        public static OrderDto ToDto(this Order dto) => new()
        {
            Id = dto.Id,
            CreatedAt = dto.CretedAt,
            CustomerId = dto.CustomerId,
            Total = dto.Total,
        };
    }
}
