using odataapimodels.Domain.Converters;
using odataapimodels.Domain.Entities;

namespace odataapimodels.Domain.ApiModels;

public partial class MediaTypeApiModel : BaseApiModel, IConvertModel<MediaType>
{
    public string? Name { get; set; }

    public virtual ICollection<TrackApiModel> Tracks { get; set; } = new List<TrackApiModel>();

    public MediaType Convert() =>
        new()
        {
            Id = Id,
            Name = Name
        };
}