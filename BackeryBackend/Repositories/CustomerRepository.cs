using BackeryBackend.Data;
using BackeryBackend.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackeryBackend.Repositories
{
    public interface ICustomerRepository
    {
        Task SaveCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(Customer customer);
        Task<Customer?> GetCustomerByIdAsync(int id);
        Task<List<Customer>> GetAllCustomersAsync();
        Task DeleteCustomerById(int id);
    }

    public class CustomerRepository: ICustomerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveCustomerAsync(Customer customer)
        {
            _dbContext.Customer.Add(customer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            var currentCustomer = await _dbContext.Customer.FirstOrDefaultAsync(x => x.Id == customer.Id);
            if (currentCustomer != null)
            {
                currentCustomer = customer;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Customer?> GetCustomerByIdAsync(int id)
        {
            return await _dbContext.Customer.FirstOrDefaultAsync(entity => id == entity.Id);
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _dbContext.Customer.AsNoTracking().ToListAsync();
        }

        public async Task DeleteCustomerById(int id)
        {
            await _dbContext.Customer.Where(entity => entity.Id == id).ExecuteDeleteAsync();
        }

    }

}
