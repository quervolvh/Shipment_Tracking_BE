using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shipment_track.src.data;

public class ProductsRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductsRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<Product>> CreateProduct([FromBody] Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return Result<Product>.Success(product);
    }
    public async Task<Result<Product>> GetProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);
        return product == null ? Result<Product>.Failure("Not found") : Result<Product>.Success(product);
    }
    
    public async Task<Result<List<Product>>> GetProducts(decimal? minPrice, decimal? maxPrice)
    {
        var query = _context.Products.AsQueryable();
        if (minPrice.HasValue)
            query = query.Where(product => product.Price >= minPrice);
        if (maxPrice.HasValue)
            query = query.Where(product => product.Price <= maxPrice);
        var product = await query.ToListAsync();
        return product == null ? Result<List<Product>>.Failure("Not found") : Result<List<Product>>.Success(product);
    }
}
