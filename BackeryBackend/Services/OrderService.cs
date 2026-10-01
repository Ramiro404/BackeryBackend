using BackeryBackend.DTOs;
using BackeryBackend.Repositories;
using BackeryBackend.Utils;

namespace BackeryBackend.Services
{
    public interface IOrderService
    {
        Task SaveOrderAsync(SaveOrderDto order);
        Task UpdateOrderAsync(OrderDto order);
        Task<OrderDto?> GetOrderByIdAsync(int id);
        Task<List<OrderDto>> GetAllOrdersAsync();
        Task DeleteOrderById(int id);
    }
    public class OrderService: IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task SaveOrderAsync(SaveOrderDto order)
        {
            var newOrder = OrderMapper.ToEntity(order);
            await _orderRepository.SaveOrderAsync(newOrder);
        }

        public async Task UpdateOrderAsync(OrderDto order)
        {
            var currentOrder = OrderMapper.ToEntity(order);
            await _orderRepository.UpdateOrderAsync(currentOrder);
        }

        public async Task<OrderDto?> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            if (order != null)
            {
                return OrderMapper.ToDto(order);
            }
            throw new Exception();
        }

        public async Task<List<OrderDto>> GetAllOrdersAsync()
        {
            var order = await _orderRepository.GetAllOrdersAsync();
            return order.Select(OrderMapper.ToDto).ToList();
        }

        public async Task DeleteOrderById(int id)
        {
            await _orderRepository.DeleteOrderById(id);
        }
    }
}
