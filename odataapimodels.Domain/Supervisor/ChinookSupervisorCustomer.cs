using FluentValidation;
using odataapimodels.Domain.ApiModels;
using odataapimodels.Domain.Entities;

namespace odataapimodels.Domain.Supervisor;

public partial class ChinookSupervisor
{
    public List<CustomerApiModel> GetAllCustomer()
    {
        var customers = customerRepository.GetAll().Select(mapper.Map<CustomerApiModel>).ToList();

        return customers;
    }

    public CustomerApiModel GetCustomerById(int id)
    {
        var customer = _customerRepository.GetById(id);
        var customerApiModel = _mapper.Map<CustomerApiModel>(customer);

        return customerApiModel;
    }

    public List<CustomerApiModel> GetCustomerBySupportRepId(int id)
    {
        var customers = _customerRepository.GetBySupportRepId(id).Select(mapper.Map<CustomerApiModel>).ToList();

        return customers;
    }

    public CustomerApiModel AddCustomer(CustomerApiModel newCustomerApiModel)
    {
        _customerValidator.ValidateAndThrowAsync(newCustomerApiModel);
        
        var customer = _mapper.Map<Customer>(newCustomerApiModel);

        customer = _customerRepository.Add(customer);
        newCustomerApiModel.Id = customer.Id;
        return newCustomerApiModel;
    }

    public bool UpdateCustomer(CustomerApiModel customerApiModel)
    {
        _customerValidator.ValidateAndThrowAsync(customerApiModel);
        var customer = _mapper.Map<Customer>(customerApiModel);

        return _customerRepository.Update(customer);
    }

    public bool DeleteCustomer(int id)
        => _customerRepository.Delete(id);
}