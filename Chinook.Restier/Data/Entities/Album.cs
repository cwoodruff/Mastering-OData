namespace Chinook.Restier.Data.Entities;

public partial class Album : BaseEntity
{
    public Album()
    {
        Tracks = new HashSet<Track>();
    }
    
    public string Title { get; set; } = null!;
    public int ArtistId { get; set; }

    public virtual Artist Artist { get; set; } = null!;
    public virtual ICollection<Track> Tracks { get; set; }
}