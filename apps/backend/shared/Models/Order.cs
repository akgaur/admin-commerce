namespace Shared.Models;

public class Order
{
    public string Id { get; set; } = null!;
    public string OrderNumber { get; set; } = null!;
    public string CustomerId { get; set; } = null!;
    public decimal Total { get; set; }
    public string Status { get; set; } = null!;
    public List<OrderItem> Items { get; set; } = new();
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public class OrderItem
{
    public string ProductId { get; set; } = null!;
    public string ProductName { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Total { get; set; }
}
