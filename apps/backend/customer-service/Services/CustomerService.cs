using commercetools.Sdk.Client;
using Shared.Models;

namespace CustomerService.Services;

public interface ICustomerService
{
    Task<IEnumerable<Customer>> GetCustomersAsync();
    Task<Customer?> GetCustomerByIdAsync(string id);
    Task<Customer> CreateCustomerAsync(Customer customer);
    Task<Customer> UpdateCustomerAsync(string id, Customer customer);
}

public class CustomerService : ICustomerService
{
    private readonly IClient _client;

    public CustomerService(IClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<Customer>> GetCustomersAsync()
    {
        var response = await _client.Customers().Get().ExecuteAsync();
        return response.Results.Select(c => new Customer
        {
            Id = c.Id,
            Name = $"{c.FirstName} {c.LastName}",
            Email = c.Email,
            Status = "active", // TODO: Implement proper status handling
            JoinDate = c.CreatedAt,
            OrdersCount = 0, // TODO: Implement order count calculation
            TotalSpent = 0, // TODO: Implement total spent calculation
            CreatedAt = c.CreatedAt,
            UpdatedAt = c.LastModifiedAt
        });
    }

    public async Task<Customer?> GetCustomerByIdAsync(string id)
    {
        var response = await _client.Customers().WithId(id).Get().ExecuteAsync();
        if (response == null) return null;

        return new Customer
        {
            Id = response.Id,
            Name = $"{response.FirstName} {response.LastName}",
            Email = response.Email,
            Status = "active", // TODO: Implement proper status handling
            JoinDate = response.CreatedAt,
            OrdersCount = 0, // TODO: Implement order count calculation
            TotalSpent = 0, // TODO: Implement total spent calculation
            CreatedAt = response.CreatedAt,
            UpdatedAt = response.LastModifiedAt
        };
    }

    public async Task<Customer> CreateCustomerAsync(Customer customer)
    {
        // TODO: Implement commercetools customer creation
        throw new NotImplementedException();
    }

    public async Task<Customer> UpdateCustomerAsync(string id, Customer customer)
    {
        // TODO: Implement commercetools customer update
        throw new NotImplementedException();
    }
}
