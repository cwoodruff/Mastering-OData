using Chinook.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using odataapimodels.Domain.Entities;
using odataapimodels.EFCoreData.Data;

namespace odataapimodels.EFCoreData.Repositories;

public class TrackRepository(ChinookContext context) : ITrackRepository
{
    private bool TrackExists(int id) =>
        context.Tracks.Any(i => i.Id == id);

    public void Dispose() => context.Dispose();

    public List<Track> GetAll() =>
        context.Tracks.Include(t => t.Album).Include(t => t.Genre).Include(t => t.MediaType).AsNoTrackingWithIdentityResolution().ToList();

    public Track GetById(int id) =>
        context.Tracks.Include(t => t.Album).Include(t => t.Genre).Include(t => t.MediaType).AsNoTrackingWithIdentityResolution().FirstOrDefault(t => t.Id == id);

    public Track Add(Track newTrack)
    {
        context.Tracks.Add(newTrack);
        context.SaveChanges();
        return newTrack;
    }

    public bool Update(Track track)
    {
        if (!TrackExists(track.Id))
            return false;
        context.Tracks.Update(track);
        context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        if (!TrackExists(id))
            return false;
        var toRemove = context.Tracks.Find(id);
        context.Tracks.Remove(toRemove);
        context.SaveChanges();
        return true;
    }

    public List<Track> GetByAlbumId(int id) =>
        context.Tracks.Where(a => a.AlbumId == id).AsNoTrackingWithIdentityResolution().ToList();

    public List<Track> GetByGenreId(int id) =>
        context.Tracks.Include(t => t.Album).Include(t => t.Genre).Where(a => a.GenreId == id).AsNoTrackingWithIdentityResolution().ToList();

    public List<Track> GetByMediaTypeId(int id) =>
        context.Tracks.Include(t => t.Album).Include(t => t.Genre).Where(a => a.MediaTypeId == id).AsNoTrackingWithIdentityResolution().ToList();

    public List<Track> GetByPlaylistId(int id) =>
        context.Playlists.Where(p => p.Id == id).SelectMany(p => p.Tracks)
            .AsNoTrackingWithIdentityResolution().ToList();

    public List<Track> GetByArtistId(int id) =>
        context.Albums.Include(a => a.Artist).Where(a => a.ArtistId == 5).SelectMany(t => t.Tracks).AsNoTrackingWithIdentityResolution().ToList();

    public List<Track> GetByInvoiceId(int id) => context.Tracks.Include(t => t.Album)
        .Where(c => c.InvoiceLines.Any(o => o.InvoiceId == id))
        .AsNoTrackingWithIdentityResolution().ToList();
}