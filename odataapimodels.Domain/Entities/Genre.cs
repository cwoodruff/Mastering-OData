using odataapimodels.Domain.ApiModels;
using odataapimodels.Domain.Converters;

namespace odataapimodels.Domain.Entities;

public partial class Genre : BaseEntity, IConvertModel<GenreApiModel>
{
    public string? Name { get; set; }

    public virtual ICollection<Track> Tracks { get; set; } = new List<Track>();

    public GenreApiModel Convert() =>
        new()
        {
            Id = Id,
            Name = Name
        };
}