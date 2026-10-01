using BackeryBackend.DTOs;
using BackeryBackend.Repositories;
using BackeryBackend.Utils;

namespace BackeryBackend.Services
{
    public interface ICustomerService
    {
        Task SaveCustomerAsync(SaveCustomerDto customer);
        Task UpdateCustomerAsync(CustomerDto customer);
        Task<CustomerDto?> GetCustomerByIdAsync(int id);
        Task<List<CustomerDto>> GetAllCustomersAsync();
        Task DeleteCustomerById(int id);

    }
    public class CustomerService: ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task SaveCustomerAsync(SaveCustomerDto customer)
        {
            var newCustomer = CustomerMapper.ToEntity(customer);
            await _customerRepository.SaveCustomerAsync(newCustomer);
        }

        public async Task UpdateCustomerAsync(CustomerDto customer)
        {
            var currentCustomer = CustomerMapper.ToEntity(customer);
            await _customerRepository.UpdateCustomerAsync(currentCustomer);
        }

        public async Task<CustomerDto?> GetCustomerByIdAsync(int id)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(id);
            if (customer != null)
            {
                return CustomerMapper.ToDto(customer);
            }
            throw new Exception();
        }

        public async Task<List<CustomerDto>> GetAllCustomersAsync()
        {
            var customer = await _customerRepository.GetAllCustomersAsync();
            return customer.Select(CustomerMapper.ToDto).ToList();
        }

        public async Task DeleteCustomerById(int id)
        {
            await _customerRepository.DeleteCustomerById(id);
        }
    }
}
