using commercetools.Sdk.Client;
using Shared.Models;

namespace OrderService.Services;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetOrdersAsync();
    Task<Order?> GetOrderByIdAsync(string id);
    Task<Order> CreateOrderAsync(Order order);
    Task<Order> UpdateOrderStatusAsync(string id, string status);
}

public class OrderService : IOrderService
{
    private readonly IClient _client;

    public OrderService(IClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<Order>> GetOrdersAsync()
    {
        var response = await _client.Orders().Get().ExecuteAsync();
        return response.Results.Select(o => new Order
        {
            Id = o.Id,
            OrderNumber = o.OrderNumber ?? "",
            CustomerId = o.CustomerId,
            Total = o.TotalPrice.CentAmount,
            Status = o.OrderState.ToString(),
            Items = o.LineItems.Select(li => new OrderItem
            {
                ProductId = li.ProductId,
                ProductName = li.Name["en"],
                Quantity = li.Quantity,
                UnitPrice = li.Price.Value.CentAmount,
                Total = li.TotalPrice.CentAmount
            }).ToList(),
            CreatedAt = o.CreatedAt,
            UpdatedAt = o.LastModifiedAt
        });
    }

    public async Task<Order?> GetOrderByIdAsync(string id)
    {
        var response = await _client.Orders().WithId(id).Get().ExecuteAsync();
        if (response == null) return null;

        return new Order
        {
            Id = response.Id,
            OrderNumber = response.OrderNumber ?? "",
            CustomerId = response.CustomerId,
            Total = response.TotalPrice.CentAmount,
            Status = response.OrderState.ToString(),
            Items = response.LineItems.Select(li => new OrderItem
            {
                ProductId = li.ProductId,
                ProductName = li.Name["en"],
                Quantity = li.Quantity,
                UnitPrice = li.Price.Value.CentAmount,
                Total = li.TotalPrice.CentAmount
            }).ToList(),
            CreatedAt = response.CreatedAt,
            UpdatedAt = response.LastModifiedAt
        };
    }

    public async Task<Order> CreateOrderAsync(Order order)
    {
        // TODO: Implement commercetools order creation
        throw new NotImplementedException();
    }

    public async Task<Order> UpdateOrderStatusAsync(string id, string status)
    {
        // TODO: Implement commercetools order status update
        throw new NotImplementedException();
    }
}
