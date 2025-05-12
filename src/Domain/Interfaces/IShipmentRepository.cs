using shipment_track.src.Utils;

public interface IShipmentRepository
{
    Task<Result<Shipment>> CreateShipment(ShipmentDto form);
    Task<Result<Shipment>> GetShipment(int id);
    Task<Result<ShipmentListModel>> GetShipments(ShipmentStatus? status, int? carrier, int? page);
    Task<Result<Shipment>> UpdateShipment(int id, string? status);
}
