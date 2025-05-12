using System.ComponentModel.DataAnnotations.Schema;
using shipment_track.src.Utils;

public class Carrier
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    [Column(TypeName = "varchar")]     
    public CarrierSize Vehicle { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
