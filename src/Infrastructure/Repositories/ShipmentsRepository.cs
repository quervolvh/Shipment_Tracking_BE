using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shipment_track.src.data;
using shipment_track.src.Utils;

public class ShipmentsRepository : IShipmentRepository
{
    private readonly ApplicationDbContext _context;

    public ShipmentsRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    // POST /shipments
    [HttpPost]
    public async Task<Result<Shipment>> CreateShipment([FromBody] ShipmentDto form)
    {
        if (!form.Carrier.HasValue)
            return Result<Shipment>.Failure("Please provide carrier for shipment");

        if (!form.Product.HasValue)
            return Result<Shipment>.Failure("Please provide product to be shipped");

        if (form.Destination == null)
            return Result<Shipment>.Failure("Please provide shipment destination");

        if (form.Origin == null)
            return Result<Shipment>.Failure("Please provide shipment origin");

        if (form.Eta == null)
            return Result<Shipment>.Failure("Please provide shipment Eta");

        if (form.ShipDate == null)
            return Result<Shipment>.Failure("Please provide shipment date");

        var parsedDate = DateTime.TryParse(form.ShipDate, out DateTime shipDate);

        if (!parsedDate)
            return Result<Shipment>.Failure("Please provide shipment date");

        var EtaAsString = ShipmentEtaValidator.GetEtaAsString(form.Eta ?? 0);

        var carrier = await _context.Carriers.FindAsync(form.Carrier);

        if (carrier == null)
            return Result<Shipment>.Failure("Cannot find selected carrier");

        var product = await _context.Products.FindAsync(form.Product);

        if (product == null)
            return Result<Shipment>.Failure("Cannot find selected product");

        var shipment = new Shipment
        {
            Price = ShipmentGenerator.getPriceForShipment(carrier),
            CarrierId = carrier.Id,
            ProductId = product.Id,
            Status = ShipmentStatus.pending,
            Reference = ShipmentGenerator.getReferenceForShipment(),
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            Eta = ShipmentEtaValidator.getEta(EtaAsString),
            Origin = form.Origin,
            Destination = form.Destination,
            ShipDate = shipDate
        };

        _context.Shipments.Add(shipment);

        await _context.SaveChangesAsync();

        return Result<Shipment>.Success(shipment);

    }

    // GET /shipments/{id}
    [HttpGet("{id}")]
    public async Task<Result<Shipment>> GetShipment(int id)
    {
        var shipment = await _context.Shipments.FindAsync(id);
        return shipment == null ? Result<Shipment>.Failure("Not Found") : Result<Shipment>.Success(shipment);
    }

    [HttpGet]
    public async Task<Result<ShipmentListModel>> GetShipments(ShipmentStatus? status, int? carrier, int? page)
    {

        var pageSize = 10;

        var query = _context.Shipments.AsQueryable();

        if (status != null)
            query = query.Where(shipment => shipment.Status.Equals(status));

        if (carrier != null)
            query = query.Where(shipment => shipment.CarrierId.Equals(carrier));

        query = query.OrderByDescending(s => s.Id);

        var totalItems = await query.CountAsync();

        var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

        var shipments = await query
                            .Skip(((page ?? 1) - 1) * pageSize)
                            .Take(pageSize)
                            .Include(p => p.Product)
                            .Include(p => p.Carrier).ToListAsync();

        return shipments == null ?

        Result<ShipmentListModel>.Failure("Not Found") :

        Result<ShipmentListModel>.Success(
        new ShipmentListModel
        {
            TotalItems = totalItems,
            TotalPages = totalPages,
            Page = page ?? 1,
            PageSize = pageSize,
            Items = shipments
        });
    }

    [HttpPut("{id}")]
    public async Task<Result<Shipment>> UpdateShipment(int id, string? status)
    {
        if (status == null)
            Result<Shipment>.Failure("No Status Provided");

        var shipment = await _context.Shipments.FindAsync(id);

        if (shipment == null)
            return Result<Shipment>.Failure("Not Found");

        if (!ShipmentStatusValidator.CheckStatusValidity(status!))
            return Result<Shipment>.Failure("Invalid Status Provided");

        shipment.Status = ShipmentStatusValidator.getStatus(status!);

        await _context.SaveChangesAsync();

        return shipment == null ? Result<Shipment>.Failure("Unable to Update Status") : Result<Shipment>.Success(shipment);
    }
}
