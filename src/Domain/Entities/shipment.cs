using System.ComponentModel.DataAnnotations.Schema;
using shipment_track.src.Utils;

public class Shipment
{
    public int Id { get; set; }
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public int CarrierId { get; set; }
    public Carrier? Carrier { get; set; }
    public ShipmentStatus Status { get; set; }
    public string Reference { get; set; } = string.Empty;
    [Column(TypeName = "decimal(18,4)")] 
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
     public string Destination { get; set; } = string.Empty;
    public string Origin { get; set; } = string.Empty;
    public DateTime ShipDate { get; set; }
    public ShipmentEta Eta { get; set; }
}
