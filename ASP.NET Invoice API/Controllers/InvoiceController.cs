using Microsoft.AspNetCore.Mvc;
using MongoEFSample.Model;

namespace MongoEFSample.Controllers;

[ApiController]
[Route("/invoices/")]
public class InvoiceController(InvoicingDataContext db)
    : ControllerBase
{
    [HttpGet]
    public IEnumerable<Invoice> GetAll()
    {
        return db.Invoices.OrderBy(i => i.Id).ToList();
    }

    [HttpGet("{id}")]
    public Invoice? Get(Guid id)
    {
        return db.Invoices.FirstOrDefault(i => i.Id == id);
    }

    [HttpGet("load")]
    public string LoadSampleData()
    {
        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();

        db.Invoices.AddRange(new Invoice
        {
            CustomerName = "Damien",
            ShippingAddress = new Address
            {
                    Street = "123 Main St",
                    City = "Seattle",
                    Region = "WA",
                    PostalCode = "98052",
                    },
            Lines =
            [
                new InvoiceLine
                {
                    ProductName = "Item 1",
                    Price = 10.0m,
                    Quantity = 2
                }
            ]
        }, new Invoice
        {
            CustomerName = "John",
            ShippingAddress = new Address
            {
                Street = "123 Main St",
                City = "Seattle",
                Region = "WA",
                PostalCode = "98052",
            },
            Lines =
            [
                new InvoiceLine
                {
                    ProductName = "Item 2",
                    Price = 20.0m,
                    Quantity = 1
                }
            ]
        });

        db.SaveChanges();

        return "Created";
    }
}