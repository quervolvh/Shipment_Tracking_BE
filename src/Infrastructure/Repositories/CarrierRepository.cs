using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using shipment_track.src.data;
using shipment_track.src.Utils;

public class CarriersRepository : ICarrierRepository
{
    private readonly ApplicationDbContext _context;

    public CarriersRepository(ApplicationDbContext context)
    {
        _context = context;
    }
  
    public async Task<Result<Carrier>> CreateCarrier([FromBody] CarrierDto form)
    {
        if (form.Name.IsNullOrEmpty())
            return Result<Carrier>.Failure("Please provide carrier name");

        var carrier = new Carrier
        {
            Name = form.Name!.ToString(),
            Vehicle = CarrierVehicleValidator.getSize(form.Vehicle ?? "small"),
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.Carriers.Add(carrier);

        await _context.SaveChangesAsync();

        return Result<Carrier>.Success(carrier);
    }

    public async Task<Result<Carrier>> GetCarrier(int id)
    {
        var carrier = await _context.Carriers.FindAsync(id);
        
        return carrier == null ?     
            Result<Carrier>.Failure("Not found") : 
            Result<Carrier>.Success(carrier);
    }

    public async Task<Result<List<Carrier>>> GetCarriers()
    {
        var carriers = await _context.Carriers.ToListAsync();

        return carriers == null ? 
            Result<List<Carrier>>.Failure("Not found") : 
            Result<List<Carrier>>.Success(carriers);
    }

}
