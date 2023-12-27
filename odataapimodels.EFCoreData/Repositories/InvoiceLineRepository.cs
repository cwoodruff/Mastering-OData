using Chinook.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using odataapimodels.Domain.Entities;
using odataapimodels.EFCoreData.Data;

namespace odataapimodels.EFCoreData.Repositories;

public class InvoiceLineRepository(ChinookContext context) : IInvoiceLineRepository
{
    private bool InvoiceLineExists(int id) =>
        context.InvoiceLines.Any(i => i.Id == id);

    public void Dispose() => context.Dispose();

    public List<InvoiceLine> GetAll() =>
        context.InvoiceLines.Include(i => i.Invoice).Include(i => i.Track).AsNoTrackingWithIdentityResolution().ToList();

    public InvoiceLine GetById(int id) =>
        context.InvoiceLines.Include(i => i.Invoice).Include(i => i.Track).AsNoTrackingWithIdentityResolution().FirstOrDefault(i => i.Id == id);

    public InvoiceLine Add(InvoiceLine newInvoiceLine)
    {
        context.InvoiceLines.Add(newInvoiceLine);
        context.SaveChanges();
        return newInvoiceLine;
    }

    public bool Update(InvoiceLine invoiceLine)
    {
        if (!InvoiceLineExists(invoiceLine.Id))
            return false;
        context.InvoiceLines.Update(invoiceLine);
        context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        if (!InvoiceLineExists(id))
            return false;
        var toRemove = context.InvoiceLines.Find(id);
        context.InvoiceLines.Remove(toRemove);
        context.SaveChanges();
        return true;
    }

    public List<InvoiceLine> GetByInvoiceId(int id) =>
        context.InvoiceLines.Include(i => i.Track).Where(a => a.InvoiceId == id).AsNoTrackingWithIdentityResolution().ToList();

    public List<InvoiceLine> GetByTrackId(int id) =>
        context.InvoiceLines.Where(a => a.TrackId == id).AsNoTrackingWithIdentityResolution().ToList();
}