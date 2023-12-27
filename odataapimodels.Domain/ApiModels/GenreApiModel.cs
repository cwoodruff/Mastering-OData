using odataapimodels.Domain.Converters;
using odataapimodels.Domain.Entities;

namespace odataapimodels.Domain.ApiModels;

public partial class GenreApiModel : BaseApiModel, IConvertModel<Genre>
{
    public string? Name { get; set; }

    public virtual ICollection<TrackApiModel> Tracks { get; set; } = new List<TrackApiModel>();

    public Genre Convert() =>
        new()
        {
            Id = Id,
            Name = Name
        };
}