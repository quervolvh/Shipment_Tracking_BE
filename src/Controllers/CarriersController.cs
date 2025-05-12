using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using shipment_track.src.data;
using shipment_track.src.Utils;

[ApiController]
[Route("[controller]")]
public class CarriersController(ICarrierService service) : ControllerBase
{
    private readonly ICarrierService _service = service;

    // POST / carriers
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Carrier))]
    public async Task<IActionResult> CreateCarrier([FromBody] CarrierDto form)
    {
        var res = await _service.CreateCarrier_(form);

        if (res.IsSuccess)
            return Ok(res.Value);

        return BadRequest(new { error = res.Error });

    }

    // GET /carriers/{id}
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Carrier))]
    public async Task<IActionResult> GetCarrier(int id)
    {
        var res = await _service.GetCarrier_(id);

        if (res.IsSuccess)
            return Ok(res.Value);

        return BadRequest(new { error = res.Error });
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Carrier>))]
    public async Task<IActionResult> GetCarriers()
    {
        var res = await _service.GetCarriers_();

        if (res.IsSuccess)
            return Ok(res.Value);

        return BadRequest(new { error = res.Error });
    }

}
