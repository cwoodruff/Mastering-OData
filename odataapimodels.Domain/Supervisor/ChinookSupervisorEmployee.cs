using FluentValidation;
using odataapimodels.Domain.ApiModels;
using odataapimodels.Domain.Entities;

namespace odataapimodels.Domain.Supervisor;

public partial class ChinookSupervisor
{
    public List<EmployeeApiModel> GetAllEmployee()
    {
        var employees = employeeRepository.GetAll().Select(mapper.Map<EmployeeApiModel>).ToList();

        return employees;
    }

    public EmployeeApiModel? GetEmployeeById(int id)
    {
        var employee = _employeeRepository.GetById(id);
        var employeeApiModel = _mapper.Map<EmployeeApiModel>(employee);

        return employeeApiModel;
    }

    public EmployeeApiModel? GetEmployeeReportsTo(int id)
    {
        var employee = _employeeRepository.GetReportsTo(id);
        var employeeApiModel = _mapper.Map<EmployeeApiModel>(employee);
        return employeeApiModel;
    }

    public EmployeeApiModel AddEmployee(EmployeeApiModel newEmployeeApiModel)
    {
        _employeeValidator.ValidateAndThrowAsync(newEmployeeApiModel);
        
        var employee = _mapper.Map<Employee>(newEmployeeApiModel);

        employee = _employeeRepository.Add(employee);
        newEmployeeApiModel.Id = employee.Id;
        return newEmployeeApiModel;
    }

    public bool UpdateEmployee(EmployeeApiModel employeeApiModel)
    {
        _employeeValidator.ValidateAndThrowAsync(employeeApiModel);

        var employee = _mapper.Map<Employee>(employeeApiModel);

        return _employeeRepository.Update(employee);
    }

    public bool DeleteEmployee(int id)
        => _employeeRepository.Delete(id);

    public List<EmployeeApiModel> GetEmployeeDirectReports(int id)
    {
        var employees = _employeeRepository.GetDirectReports(id).Select(mapper.Map<EmployeeApiModel>).ToList();
        return employees;
    }

    public List<EmployeeApiModel> GetDirectReports(int id)
    {
        var employees = _employeeRepository.GetDirectReports(id).Select(mapper.Map<EmployeeApiModel>).ToList();
        return employees;
    }
}