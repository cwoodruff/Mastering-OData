using Chinook.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using odataapimodels.Domain.Entities;
using odataapimodels.EFCoreData.Data;

namespace odataapimodels.EFCoreData.Repositories;

public class AlbumRepository(ChinookContext context) : IAlbumRepository
{
    private bool AlbumExists(int id) =>
        context.Albums.Any(a => a.Id == id);

    public void Dispose() => context.Dispose();

    public List<Album> GetAll() => context.Albums.Include(a => a.Artist).Include(a => a.Tracks).AsNoTrackingWithIdentityResolution().ToList();

    public Album GetById(int id)
    {
        var dbAlbum = context.Albums.Include(a => a.Artist).Include(a => a.Tracks).AsNoTrackingWithIdentityResolution().FirstOrDefault(a => a.Id == id);
        return dbAlbum;
    }

    public Album Add(Album newAlbum)
    {
        context.Albums.Add(newAlbum);
        context.SaveChanges();
        return newAlbum;
    }

    public bool Update(Album album)
    {
        if (!AlbumExists(album.Id))
            return false;
        context.Albums.Update(album);
        context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        if (!AlbumExists(id))
            return false;
        var toRemove = context.Albums.Find(id);
        context.Albums.Remove(toRemove);
        context.SaveChanges();
        return true;
    }

    public List<Album> GetByArtistId(int id) =>
        context.Albums.Include(a => a.Artist)
            .Include(a => a.Tracks)
            .Where(a => a.ArtistId == id).AsNoTrackingWithIdentityResolution().ToList();
}