using BackeryBackend.Data;
using BackeryBackend.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackeryBackend.Repositories
{


    public interface IOrderRepository
    {
        Task SaveOrderAsync(Order order);
        Task UpdateOrderAsync(Order order);
        Task<Order?> GetOrderByIdAsync(int id);
        Task<List<Order>> GetAllOrdersAsync();
        Task DeleteOrderById(int id);
    }

    public class OrderRepository: IOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveOrderAsync(Order order)
        {
            _dbContext.Order.Add(order);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateOrderAsync(Order order)
        {
            var currentOrder = await _dbContext.Order.FirstOrDefaultAsync(entity => entity.Id == order.Id);
            if (currentOrder != null)
            {
                currentOrder = order;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _dbContext.Order.FirstOrDefaultAsync(entity => id == entity.Id);
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _dbContext.Order.ToListAsync();
        }

        public async Task DeleteOrderById(int id)
        {
            await _dbContext.Order.Where(entity => entity.Id == id).ExecuteDeleteAsync();
        }

    }
}
