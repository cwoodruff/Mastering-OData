using Chinook.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using odataapimodels.Domain.Entities;
using odataapimodels.EFCoreData.Data;

namespace odataapimodels.EFCoreData.Repositories;

public class InvoiceRepository(ChinookContext context) : IInvoiceRepository
{
    private bool InvoiceExists(int id) =>
        context.Invoices.Any(i => i.Id == id);

    public void Dispose() => context.Dispose();
    
    public List<Invoice> GetAll() =>
        context.Invoices.Include(i => i.InvoiceLines).Include(i => i.Customer).AsNoTrackingWithIdentityResolution().ToList();

    public Invoice GetById(int id) =>
        context.Invoices.Include(i => i.InvoiceLines).Include(i => i.Customer).AsNoTrackingWithIdentityResolution().FirstOrDefault(i => i.Id == id);

    public Invoice Add(Invoice newInvoice)
    {
        context.Invoices.Add(newInvoice);
        context.SaveChanges();
        return newInvoice;
    }

    public bool Update(Invoice invoice)
    {
        if (!InvoiceExists(invoice.Id))
            return false;
        context.Invoices.Update(invoice);
        context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        if (!InvoiceExists(id))
            return false;
        var toRemove = context.Invoices.Find(id);
        context.Invoices.Remove(toRemove);
        context.SaveChanges();
        return true;
    }

    public List<Invoice> GetByEmployeeId(int id) =>
        context.Customers.Where(a => a.SupportRepId == 5).SelectMany(t => t.Invoices).AsNoTrackingWithIdentityResolution().ToList();

    public List<Invoice> GetByCustomerId(int id) =>
        context.Invoices.Where(i => i.CustomerId == id).AsNoTrackingWithIdentityResolution().ToList();
}