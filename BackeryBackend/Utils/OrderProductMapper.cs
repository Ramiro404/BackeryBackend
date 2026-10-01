using BackeryBackend.DTOs;
using BackeryBackend.Entities;

namespace BackeryBackend.Utils
{
    public static  class OrderProductMapper
    {
        public static OrderProduct ToEntity(this OrderProductDto dto) => new()
        {
            Id = dto.Id,
            Amount = dto.Amount,
            OrderId = dto.OrderId,
            ProductId = dto.ProductId,
        };

        public static OrderProduct ToEntity(this SaveOrderProductDto dto) => new()
        {
            Amount = dto.Amount,
            OrderId = dto.OrderId,
            ProductId = dto.ProductId,
        };

        public static OrderProductDto ToDto(this OrderProduct dto) => new()
        {
            Id = dto.Id,
            Amount = dto.Amount,
            OrderId = dto.OrderId,
            ProductId = dto.ProductId,
        };
    }
}
