public class CarrierService : ICarrierService
{
    private readonly ICarrierRepository _repository;

    public CarrierService(ICarrierRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Carrier>> CreateCarrier_(CarrierDto form)
    {
        var result = await _repository.CreateCarrier(form);
        return result;
    }

    public async Task<Result<Carrier>> GetCarrier_(int id)
    {
        var res = await _repository.GetCarrier(id);

        return res;
    }

    public async Task<Result<List<Carrier>>> GetCarriers_()
    {
        return await _repository.GetCarriers();
    }
}

public interface ICarrierService
{
    Task<Result<Carrier>> CreateCarrier_(CarrierDto form);
    Task<Result<List<Carrier>>> GetCarriers_();
    Task<Result<Carrier>> GetCarrier_(int id);
}
