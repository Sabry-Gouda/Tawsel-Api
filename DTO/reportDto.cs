namespace tawsel.DTO
{
    public class reportDto
    {
    public int id { get; set; }
    public string serialNumber { get; set; }
    public string status { get; set; }
    public string traderName { get; set; }
    public string customerName { get; set; }
    public string phoneNumber { get; set; }
    public string government { get; set; }
    public string city { get; set; }
    public decimal orderCost { get; set; }
    public int receivedAmount { get; set; }
    public decimal shippingCost { get; set; }
    public decimal paidShippingAmount { get; set; }
    public decimal companyValue { get; set; }
    public string date { get; set; }
    }
}
