using System.ComponentModel.DataAnnotations.Schema;

namespace simple_odata.Data.Entities;

public partial class Album : BaseEntity
{
    public Album()
    {
        Tracks = new HashSet<Track>();
    }
    
    public string Title { get; set; } = null!;
    
    [ForeignKey("Artist")]
    public int ArtistId { get; set; }

    public virtual Artist Artist { get; set; } = null!;
    public virtual ICollection<Track> Tracks { get; set; }
}