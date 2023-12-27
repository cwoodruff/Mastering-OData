using odataapimodels.Domain.ApiModels;
using odataapimodels.Domain.Converters;

namespace odataapimodels.Domain.Entities;

public partial class Album : BaseEntity, IConvertModel<AlbumApiModel>
{
    public string Title { get; set; } = null!;

    public int? ArtistId { get; set; }

    public virtual Artist Artist { get; set; } = null!;

    public virtual ICollection<Track> Tracks { get; set; } = new List<Track>();

    public AlbumApiModel Convert() =>
        new()
        {
            Id = Id,
            ArtistId = ArtistId,
            Title = Title
        };
}