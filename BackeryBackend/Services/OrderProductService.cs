using BackeryBackend.Repositories;

namespace BackeryBackend.Services
{
    public class OrderProductService
    {
        private readonly IOrderProductRepository _orderproductRepository;

        public OrderProductService(IOrderProductRepository orderproductRepository)
        {
            _orderproductRepository = orderproductRepository;
        }
        /*
        public async Task SaveOrderProductAsync(SaveOrderProductDto orderproduct)
        {
            var newOrderProduct = OrderProductMapper.ToEntity(orderproduct);
            await _orderproductRepository.SaveOrderProductAsync(newOrderProduct);
        }

        public async Task UpdateOrderProductAsync(OrderProductDto orderproduct)
        {
            var currentOrderProduct = OrderProductMapper.ToEntity(orderproduct);
            await _orderproductRepository.UpdateOrderProductAsync(currentOrderProduct);
        }

        public async Task<OrderProductDto?> GetOrderProductByIdAsync(int id)
        {
            var orderproduct = await _orderproductRepository.GetOrderProductByIdAsync(id);
            if (orderproduct != null)
            {
                return OrderProductMapper.ToDto(orderproduct);
            }
            throw new Exception();
        }

        public async Task<List<OrderProductDto>> GetAllOrderProductsAsync()
        {
            var orderproduct = await _orderproductRepository.GetAllOrderProductsAsync();
            return orderproduct.Select(OrderProductMapper.ToDto).ToList();
        }

        public async Task DeleteOrderProductById(int id)
        {
            await _orderproductRepository.DeleteOrderProductById(id);
        }
        */
    }
}
