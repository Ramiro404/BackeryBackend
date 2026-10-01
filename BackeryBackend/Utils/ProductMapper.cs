using BackeryBackend.DTOs;
using BackeryBackend.Entities;

namespace BackeryBackend.Utils
{
    public static class ProductMapper
    {
        public static Product ToEntity(this ProductDto dto) => new()
        {
            Id = dto.Id,
            Description = dto.Description,
            ImageUrl = dto.ImageUrl,
            Name = dto.Name,
            Price = dto.Price,
            UnitAvailable = dto.UnitAvailable,
        };

        public static Product ToEntity(this SaveProductDto dto) => new()
        {
            Description = dto.Description,
            ImageUrl = dto.ImageUrl,
            Name = dto.Name,
            Price = dto.Price,
            UnitAvailable = dto.UnitAvailable,
        };

        public static ProductDto ToDto(this Product dto) => new()
        {
            Id = dto.Id,
            Description = dto.Description,
            ImageUrl = dto.ImageUrl,
            Name = dto.Name,
            Price = dto.Price,
            UnitAvailable = dto.UnitAvailable,
        };


    }
}
