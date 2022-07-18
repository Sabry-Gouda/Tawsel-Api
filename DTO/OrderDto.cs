namespace tawsel.DTO
{
    public class OrderDto
    {
    public int id { get; set; }
    public string serialNumber { get; set; }
    public string date { get; set; }
    public clientDto customerData { get; set; }
    public string government { get; set; }
    public string city { get; set; }
    public decimal  orderCost { get; set; }
    public string status { get; set; }
    }
}
