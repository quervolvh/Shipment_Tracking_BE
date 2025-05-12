using shipment_track.src.Utils;

public interface IProductRepository
{
    Task<Result<Product>> CreateProduct(Product product);
    Task<Result<Product>> GetProduct(int id);
    Task<Result<List<Product>>> GetProducts(decimal? minPrice, decimal? maxPrice);
}
