using BackeryBackend.DTOs;
using BackeryBackend.Entities;
using BackeryBackend.Repositories;
using BackeryBackend.Utils;
using Microsoft.EntityFrameworkCore;

namespace BackeryBackend.Services
{
    public interface IProductService
    {
        Task SaveProductAsync(SaveProductDto product);
        Task UpdateProductAsync(ProductDto product);
        Task<ProductDto?> GetProductByIdAsync(int id);
        Task<List<ProductDto>> GetAllProductsAsync();
        Task DeleteProductById(int id);
    }

    public class ProductService: IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task SaveProductAsync(SaveProductDto product)
        {
            var newProduct = ProductMapper.ToEntity(product);
            await _productRepository.SaveProductAsync(newProduct);
        }

        public async Task UpdateProductAsync(ProductDto product)
        {
            var currentProduct = ProductMapper.ToEntity(product);
            await _productRepository.UpdateProductAsync(currentProduct);
        }

        public async Task<ProductDto?> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product != null) {
                return ProductMapper.ToDto(product);
            }
            throw new Exception();
        }

        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return products.Select(ProductMapper.ToDto).ToList();
        }

        public async Task DeleteProductById(int id)
        {
            await _productRepository.DeleteProductById(id);
        }
    }
}
