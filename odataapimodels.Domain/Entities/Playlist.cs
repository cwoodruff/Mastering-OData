using odataapimodels.Domain.ApiModels;
using odataapimodels.Domain.Converters;

namespace odataapimodels.Domain.Entities;

public partial class Playlist : BaseEntity, IConvertModel<PlaylistApiModel>
{
    public string? Name { get; set; }

    public virtual ICollection<Track> Tracks { get; set; } = new List<Track>();

    public PlaylistApiModel Convert() =>
        new()
        {
            Id = Id,
            Name = Name
        };
}