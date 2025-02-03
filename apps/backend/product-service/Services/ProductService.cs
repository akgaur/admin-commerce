using commercetools.Sdk.Client;
using commercetools.Base.Client;
using Shared.Models;

namespace ProductService.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<Product?> GetProductByIdAsync(string id);
    Task<Product> CreateProductAsync(Product product);
    Task<Product> UpdateProductAsync(string id, Product product);
    Task DeleteProductAsync(string id);
}

public class ProductService : IProductService
{
    private readonly IClient _client;

    public ProductService(IClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        var response = await _client.Products().Get().ExecuteAsync();
        return response.Results.Select(p => new Product
        {
            Id = p.Id,
            Name = p.MasterData.Current.Name["en"],
            Sku = p.MasterData.Current.MasterVariant.Sku ?? "",
            Price = p.MasterData.Current.MasterVariant.Prices.FirstOrDefault()?.Value.CentAmount ?? 0,
            Stock = p.MasterData.Current.MasterVariant.Availability?.AvailableQuantity ?? 0,
            Status = p.MasterData.Current.Published ? "active" : "inactive",
            CreatedAt = p.CreatedAt,
            UpdatedAt = p.LastModifiedAt
        });
    }

    public async Task<Product?> GetProductByIdAsync(string id)
    {
        var response = await _client.Products().WithId(id).Get().ExecuteAsync();
        if (response == null) return null;

        return new Product
        {
            Id = response.Id,
            Name = response.MasterData.Current.Name["en"],
            Sku = response.MasterData.Current.MasterVariant.Sku ?? "",
            Price = response.MasterData.Current.MasterVariant.Prices.FirstOrDefault()?.Value.CentAmount ?? 0,
            Stock = response.MasterData.Current.MasterVariant.Availability?.AvailableQuantity ?? 0,
            Status = response.MasterData.Current.Published ? "active" : "inactive",
            CreatedAt = response.CreatedAt,
            UpdatedAt = response.LastModifiedAt
        };
    }

    public async Task<Product> CreateProductAsync(Product product)
    {
        // TODO: Implement commercetools product creation
        throw new NotImplementedException();
    }

    public async Task<Product> UpdateProductAsync(string id, Product product)
    {
        // TODO: Implement commercetools product update
        throw new NotImplementedException();
    }

    public async Task DeleteProductAsync(string id)
    {
        // TODO: Implement commercetools product deletion
        throw new NotImplementedException();
    }
}
