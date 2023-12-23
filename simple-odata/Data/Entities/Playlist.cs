namespace simple_odata.Data.Entities;

public sealed class Playlist : BaseEntity
{
    public string? Name { get; set; }

    public ICollection<Track>? Tracks { get; set; }
}