using Microsoft.EntityFrameworkCore;
using shipment_track.src.data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SQLiteSource");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString), ServiceLifetime.Scoped);

builder.Services.AddOpenApi();

builder.Services.AddControllers();

builder.Services.AddScoped<IShipmentService, ShipmentService>();

builder.Services.AddScoped<IShipmentRepository, ShipmentsRepository>();

builder.Services.AddScoped<ICarrierService, CarrierService>();

builder.Services.AddScoped<ICarrierRepository, CarriersRepository>();

builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IProductRepository, ProductsRepository>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwagger();

    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () => { return new Dictionary<string, string>(); })
.WithName("GetHome");

app.MapControllers();

app.Run();
