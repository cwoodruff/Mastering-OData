using Chinook.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using odataapimodels.Domain.Entities;
using odataapimodels.EFCoreData.Data;

namespace odataapimodels.EFCoreData.Repositories;

public class EmployeeRepository(ChinookContext context) : IEmployeeRepository
{
    private bool EmployeeExists(int id) =>
        context.Employees.Any(e => e.Id == id);

    public void Dispose() => context.Dispose();

    public List<Employee> GetAll() =>
        context.Employees
            .AsNoTrackingWithIdentityResolution().ToList();

    public Employee GetById(int id) =>
        context.Employees.Include(e => e.Customers).Include(e => e.ReportsToNavigation).AsNoTrackingWithIdentityResolution().FirstOrDefault(e => e.Id == id);

    public Employee Add(Employee newEmployee)
    {
        context.Employees.Add(newEmployee);
        context.SaveChanges();
        return newEmployee;
    }

    public bool Update(Employee employee)
    {
        if (!EmployeeExists(employee.Id))
            return false;
        context.Employees.Update(employee);
        context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        if (!EmployeeExists(id))
            return false;
        var toRemove = context.Employees.Find(id);
        context.Employees.Remove(toRemove);
        context.SaveChanges();
        return true;
    }

    public Employee GetReportsTo(int id) =>
        context.Employees.Find(id);

    public List<Employee> GetDirectReports(int id) =>
        context.Employees.Where(e => e.ReportsTo == id).AsNoTrackingWithIdentityResolution().ToList();

    public Employee GetToReports(int id) =>
        context.Employees
            .Find(context.Employees.Where(e => e.Id == id)
                .Select(p => new { p.ReportsTo })
                .First());
}