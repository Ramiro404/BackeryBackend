using BackeryBackend.DTOs;
using BackeryBackend.Entities;

namespace BackeryBackend.Utils
{
    public static class CustomerMapper
    {
        public static Customer ToEntity(this CustomerDto dto) => new()
        {
            Id = dto.Id,
            LastName = dto.LastName,
            Name = dto.Name,
            PhoneNumber = dto.PhoneNumber,
        };

        public static Customer ToEntity(this SaveCustomerDto dto) => new()
        {
            LastName = dto.LastName,
            Name = dto.Name,
            PhoneNumber = dto.PhoneNumber,
        };

        public static CustomerDto ToDto(this Customer dto) => new()
        {
            Id = dto.Id,
            LastName = dto.LastName,
            Name = dto.Name,
            PhoneNumber = dto.PhoneNumber,
        };
    }
}
