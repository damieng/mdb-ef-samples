using Microsoft.EntityFrameworkCore;

namespace MongoEFSample.Model;

public class InvoicingDataContext(DbContextOptions options)
    : DbContext(options)
{
    public DbSet<Invoice> Invoices { get; set; }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<Invoice>(i =>
        {
            i.OwnsMany(l => l.Lines);
            i.OwnsOne(l => l.ShippingAddress);
            // Properties can use converters, bson representations
            // Redefined element names, choose date types (utc/local etc).
            // Value generator registered for ObjectId
            // Concurrency support with IsRowVersion and IsTimestamp
            // Most of these have attribute versions either from EF, MongoDB or the MongoDB EF Provider
        });
    }
}