using odataapimodels.Domain.ApiModels;
using odataapimodels.Domain.Converters;

namespace odataapimodels.Domain.Entities;

public partial class InvoiceLine : BaseEntity, IConvertModel<InvoiceLineApiModel>
{
    public int? InvoiceId { get; set; }

    public int? TrackId { get; set; }

    public decimal UnitPrice { get; set; }

    public int Quantity { get; set; }

    public virtual Invoice Invoice { get; set; } = null!;

    public virtual Track Track { get; set; } = null!;

    public InvoiceLineApiModel Convert() =>
        new()
        {
            Id = Id,
            InvoiceId = InvoiceId,
            TrackId = TrackId,
            UnitPrice = UnitPrice,
            Quantity = Quantity
        };
}