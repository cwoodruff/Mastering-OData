using FluentValidation;
using odataapimodels.Domain.ApiModels;
using odataapimodels.Domain.Entities;

namespace odataapimodels.Domain.Supervisor;

public partial class ChinookSupervisor
{
    public List<InvoiceApiModel> GetAllInvoice()
    {
        var invoices = _invoiceRepository.GetAll().Select(mapper.Map<InvoiceApiModel>).ToList();

        return invoices;
    }

    public InvoiceApiModel? GetInvoiceById(int id)
    {
        var invoice = _invoiceRepository.GetById(id);
        var invoiceApiModel = _mapper.Map<InvoiceApiModel>(invoice);

        return invoiceApiModel;
    }

    public InvoiceApiModel AddInvoice(InvoiceApiModel newInvoiceApiModel)
    {
        _invoiceValidator.ValidateAndThrowAsync(newInvoiceApiModel);
        var invoice = _mapper.Map<Invoice>(newInvoiceApiModel);
        invoice = _invoiceRepository.Add(invoice);
        newInvoiceApiModel.Id = invoice.Id;
        return newInvoiceApiModel;
    }

    public bool UpdateInvoice(InvoiceApiModel invoiceApiModel)
    {
        _invoiceValidator.ValidateAndThrowAsync(invoiceApiModel);
        var invoice = _mapper.Map<Invoice>(invoiceApiModel);
        return _invoiceRepository.Update(invoice);
    }

    public bool DeleteInvoice(int id)
        => _invoiceRepository.Delete(id);


    public List<InvoiceApiModel> GetInvoiceByEmployeeId(int id)
    {
        var invoices = _invoiceRepository.GetByEmployeeId(id).Select(mapper.Map<InvoiceApiModel>).ToList();
        return invoices;
    }
    
    public List<InvoiceApiModel> GetInvoiceByCustomerId(int id)
    {
        var invoices = _invoiceRepository.GetByCustomerId(id).Select(mapper.Map<InvoiceApiModel>).ToList();
        return invoices;
    }
}