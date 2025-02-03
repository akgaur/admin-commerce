using Microsoft.AspNetCore.Mvc;
using OrderService.Services;
using Shared.Models;

namespace OrderService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
    {
        var orders = await _orderService.GetOrdersAsync();
        return Ok(orders);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> GetOrder(string id)
    {
        var order = await _orderService.GetOrderByIdAsync(id);
        if (order == null)
        {
            return NotFound();
        }
        return Ok(order);
    }

    [HttpPost]
    public async Task<ActionResult<Order>> CreateOrder([FromBody] Order order)
    {
        var createdOrder = await _orderService.CreateOrderAsync(order);
        return CreatedAtAction(nameof(GetOrder), new { id = createdOrder.Id }, createdOrder);
    }

    [HttpPatch("{id}/status")]
    public async Task<ActionResult<Order>> UpdateOrderStatus(string id, [FromBody] UpdateOrderStatusRequest request)
    {
        try
        {
            var updatedOrder = await _orderService.UpdateOrderStatusAsync(id, request.Status);
            return Ok(updatedOrder);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}

public class UpdateOrderStatusRequest
{
    public string Status { get; set; } = null!;
}
