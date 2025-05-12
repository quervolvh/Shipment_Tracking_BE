public class ShipmentListModel
{
    public int TotalItems { get; set; }
    public int TotalPages { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    public List<Shipment> Items { get; set; } = [];
}
