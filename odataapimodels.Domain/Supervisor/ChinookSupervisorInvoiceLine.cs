using FluentValidation;
using odataapimodels.Domain.ApiModels;
using odataapimodels.Domain.Entities;

namespace odataapimodels.Domain.Supervisor;

public partial class ChinookSupervisor
{
    public List<InvoiceLineApiModel> GetAllInvoiceLine()
    {
        var invoiceLines = _invoiceLineRepository.GetAll().Select(mapper.Map<InvoiceLineApiModel>).ToList();

        return invoiceLines;
    }

    public InvoiceLineApiModel GetInvoiceLineById(int id)
    {
        var invoiceLine = _invoiceLineRepository.GetById(id);
        var invoiceLineApiModel = _mapper.Map<InvoiceLineApiModel>(invoiceLine);

        return invoiceLineApiModel;
    }

    public InvoiceLineApiModel AddInvoiceLine(InvoiceLineApiModel newInvoiceLineApiModel)
    {
        _invoiceLineValidator.ValidateAndThrowAsync(newInvoiceLineApiModel);
        
        var invoiceLine = _mapper.Map<InvoiceLine>(newInvoiceLineApiModel);

        invoiceLine = _invoiceLineRepository.Add(invoiceLine);
        newInvoiceLineApiModel.Id = invoiceLine.Id;
        return newInvoiceLineApiModel;
    }

    public bool UpdateInvoiceLine(InvoiceLineApiModel invoiceLineApiModel)
    {
        _invoiceLineValidator.ValidateAndThrowAsync(invoiceLineApiModel);

        var invoiceLine = _mapper.Map<InvoiceLine>(invoiceLineApiModel);

        return _invoiceLineRepository.Update(invoiceLine);
    }

    public bool DeleteInvoiceLine(int id)
        => _invoiceLineRepository.Delete(id);
    
    public List<InvoiceLineApiModel> GetInvoiceLineByInvoiceId(int id)
    {
        var invoiceLines = _invoiceLineRepository.GetByInvoiceId(id).Select(mapper.Map<InvoiceLineApiModel>).ToList();
        return invoiceLines;
    }

    public List<InvoiceLineApiModel> GetInvoiceLineByTrackId(int id)
    {
        var invoiceLines = _invoiceLineRepository.GetByTrackId(id).Select(mapper.Map<InvoiceLineApiModel>).ToList();
        return invoiceLines;
    }
}