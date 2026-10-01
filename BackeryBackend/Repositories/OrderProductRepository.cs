using BackeryBackend.Data;
using BackeryBackend.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackeryBackend.Repositories
{
    public interface IOrderProductRepository
    {
        Task SaveOrderProductAsync(OrderProduct orderproduct);
        Task UpdateOrderProductAsync(OrderProduct orderproduct);
        Task<OrderProduct?> GetOrderProductByIdAsync(int id);
        Task<List<OrderProduct>> GetAllOrderProductsAsync();
        Task DeleteOrderProductById(int id);
    }

    public class OrderProductRepository: IOrderProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveOrderProductAsync(OrderProduct orderproduct)
        {
            _dbContext.OrderProduct.Add(orderproduct);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateOrderProductAsync(OrderProduct orderproduct)
        {
            var currentOrderProduct = await _dbContext.OrderProduct.FirstOrDefaultAsync(x =>  x.Id == orderproduct.Id);
            if (currentOrderProduct != null)
            {
                currentOrderProduct = orderproduct;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<OrderProduct?> GetOrderProductByIdAsync(int id)
        {
            return await _dbContext.OrderProduct.FirstOrDefaultAsync(entity => id == entity.Id);
        }

        public async Task<List<OrderProduct>> GetAllOrderProductsAsync()
        {
            return await _dbContext.OrderProduct.ToListAsync();
        }

        public async Task DeleteOrderProductById(int id)
        {
            await _dbContext.OrderProduct.Where(entity => entity.Id == id).ExecuteDeleteAsync();
        }

    }

}
