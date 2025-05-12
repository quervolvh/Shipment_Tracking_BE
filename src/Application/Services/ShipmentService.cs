using shipment_track.src.Utils;

public class ShipmentService : IShipmentService
{
    private readonly IShipmentRepository _repository;

    public ShipmentService(IShipmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Shipment>> CreateShipment_(ShipmentDto form)
    {
        var result = await _repository.CreateShipment(form);
        return result;
    }

    public async Task<Result<ShipmentListModel>> GetShipments_(ShipmentStatus? status, int? carrier, int? page)
    {
        var res = await _repository.GetShipments(status, carrier, page);

        return res;
    }

    public async Task<Result<Shipment>> GetShipment_(int id)
    {
        return await _repository.GetShipment(id);
    }

    public async Task<Result<Shipment>> UpdateShipment_(int id, string? status)
    {
        return await _repository.UpdateShipment(id, status);
    }
}

public interface IShipmentService
{
    Task<Result<Shipment>> CreateShipment_(ShipmentDto form);
    Task<Result<ShipmentListModel>> GetShipments_(ShipmentStatus? status, int? carrier, int? page);
    Task<Result<Shipment>> GetShipment_(int id);
    Task<Result<Shipment>> UpdateShipment_(int id, string? status);
}