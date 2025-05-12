using shipment_track.src.Utils;

public interface ICarrierRepository
{
    Task<Result<Carrier>> CreateCarrier(CarrierDto form);
    Task<Result<Carrier>> GetCarrier(int id);
    Task<Result<List<Carrier>>> GetCarriers();
}
