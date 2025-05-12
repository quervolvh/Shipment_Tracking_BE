using Microsoft.AspNetCore.Mvc;
using shipment_track.src.Utils;

[ApiController]
[Route("[controller]")]
public class ShipmentsController(IShipmentService service, ILogger<ShipmentsController> logger) : ControllerBase
{
    private readonly IShipmentService _service = service;

    private readonly ILogger<ShipmentsController> _logger = logger;

    // POST /shipments
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Shipment))]
    public async Task<IActionResult> CreateShipment([FromBody] ShipmentDto form)
    {

        _logger.LogInformation("Creating shipment");

        var res = await _service.CreateShipment_(form);

        if (res.IsSuccess)
            return Ok(res.Value);

        return BadRequest(new { error = res.Error });
    }

    // GET /shipments/{id}
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Shipment))]
    public async Task<IActionResult> GetShipment(int id)
    {

        _logger.LogInformation("Getting shipment");

        var res = await _service.GetShipment_(id);

        if (res.IsSuccess)
            return Ok(res.Value);

        return BadRequest(new { error = res.Error });

    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ShipmentListModel))]
    public async Task<IActionResult> GetShipments(ShipmentStatus? status, int? carrier, int? page)
    {

        _logger.LogInformation("Getting all shipments");

        var res = await _service.GetShipments_(status, carrier, page);

        if (res.IsSuccess)
            return Ok(res.Value);

        return BadRequest(new { error = res.Error });
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Shipment))]
    public async Task<IActionResult> UpdateShipment(int id, string? status)
    {

        _logger.LogInformation("Updating shipment");
            
        var res = await _service.UpdateShipment_(id, status);

        if (res.IsSuccess)
            return Ok(res.Value);

        return BadRequest(new { error = res.Error });
    }
}
