using odataapimodels.Domain.Converters;
using odataapimodels.Domain.Entities;

namespace odataapimodels.Domain.ApiModels;

public partial class PlaylistApiModel : BaseApiModel, IConvertModel<Playlist>
{
    public string? Name { get; set; }

    public virtual ICollection<TrackApiModel> Tracks { get; set; } = new List<TrackApiModel>();

    public Playlist Convert() =>
        new()
        {
            Id = Id,
            Name = Name
        };
}