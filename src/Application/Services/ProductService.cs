public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Product>> CreateProduct_(Product product)
    {
        var result = await _repository.CreateProduct(product);
        return result;
    }

    public async Task<Result<Product>> GetProduct_(int id)
    {
        var res = await _repository.GetProduct(id);

        return res;
    }

    public async Task<Result<List<Product>>> GetProducts_(decimal? minPrice, decimal? maxPrice)
    {
        return await _repository.GetProducts(minPrice, maxPrice);
    }
}

public interface IProductService
{
    Task<Result<Product>> CreateProduct_(Product product);
    Task<Result<Product>> GetProduct_(int id);
    Task<Result<List<Product>>> GetProducts_(decimal? minPrice, decimal? maxPrice);
}
