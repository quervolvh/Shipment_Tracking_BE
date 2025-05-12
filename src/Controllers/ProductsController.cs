using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shipment_track.src.data;

[ApiController]
[Route("[controller]")]
public class ProductsController(IProductService service) : ControllerBase
{
    private readonly IProductService _service = service;
    // POST /products
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
    public async Task<IActionResult> CreateProduct([FromBody] Product product)
    {
        var res = await _service.CreateProduct_(product);

        if (res.IsSuccess)
            return Ok(res.Value);
        return BadRequest(new { error = res.Error });

    }

    // GET /products/{id}
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
    public async Task<IActionResult> GetProduct(int id)
    {
        var res = await _service.GetProduct_(id);

        if (res.IsSuccess)
            return Ok(res.Value);
        return BadRequest(new { error = res.Error });
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Product>))]
    public async Task<IActionResult> GetProducts(decimal? minPrice, decimal? maxPrice)
    {
        var res = await _service.GetProducts_(minPrice, maxPrice);

        if (res.IsSuccess)
            return Ok(res.Value);
        return BadRequest(new { error = res.Error });
    }
}
