using BackeryBackend.DTOs;
using BackeryBackend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackeryBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IActionResult> Save(SaveOrderDto order)
        {
            try
            {
                await _orderService.SaveOrderAsync(order);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        public async Task<IActionResult> Update(OrderDto order)
        {
            try
            {
                await _orderService.UpdateOrderAsync(order);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _orderService.GetOrderByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _orderService.GetAllOrdersAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                await _orderService.DeleteOrderById(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
