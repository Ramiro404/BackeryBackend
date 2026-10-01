using BackeryBackend.Data;
using BackeryBackend.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackeryBackend.Repositories
{
    public interface IProductRepository
    {
        Task SaveProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task<Product?> GetProductByIdAsync(int id);
        Task<List<Product>> GetAllProductsAsync();
        Task DeleteProductById(int id);
    }

    public class ProductRepository: IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext= dbContext;
        }

        public async Task SaveProductAsync(Product product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            var currentProduct = await _dbContext.Products.FirstOrDefaultAsync(entity => entity.Id == product.Id);
            if(currentProduct != null)
            {
                currentProduct = product;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(entity => id == entity.Id);
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task DeleteProductById(int id) {
            await _dbContext.Products.Where(entity => entity.Id == id).ExecuteDeleteAsync();
        }
            
    }
}
