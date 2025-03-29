using MongoDB.Bson;

namespace MongoEFSample.Model;

public class Invoice
{
    public Guid Id { get; set; }
    public string CustomerName { get; set; }

    public List<InvoiceLine> Lines { get; set; }

    public Address ShippingAddress { get; set; }
}

public class InvoiceLine
{
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public decimal LineTotal => Price * Quantity;
}