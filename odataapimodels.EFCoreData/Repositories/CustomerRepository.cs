using Chinook.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using odataapimodels.Domain.Entities;
using odataapimodels.EFCoreData.Data;

namespace odataapimodels.EFCoreData.Repositories;

public class CustomerRepository(ChinookContext context) : ICustomerRepository
{
    private bool CustomerExists(int id) =>
        context.Customers.Any(c => c.Id == id);

    public void Dispose() => context.Dispose();

    public List<Customer> GetAll() =>
        context.Customers.Include(c => c.Invoices).Include(c => c.SupportRep).AsNoTrackingWithIdentityResolution().ToList();

    public Customer GetById(int id) =>
        context.Customers.Include(c => c.Invoices).Include(c => c.SupportRep).AsNoTrackingWithIdentityResolution().FirstOrDefault(c => c.Id == id);

    public Customer Add(Customer newCustomer)
    {
        context.Customers.Add(newCustomer);
        context.SaveChanges();
        return newCustomer;
    }

    public bool Update(Customer customer)
    {
        if (!CustomerExists(customer.Id))
            return false;
        context.Customers.Update(customer);
        context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        if (!CustomerExists(id))
            return false;
        var toRemove = context.Customers.Find(id);
        context.Customers.Remove(toRemove);
        context.SaveChanges();
        return true;
    }

    public List<Customer> GetBySupportRepId(int id) =>
        context.Customers.Where(a => a.SupportRepId == id).AsNoTrackingWithIdentityResolution().ToList();
}