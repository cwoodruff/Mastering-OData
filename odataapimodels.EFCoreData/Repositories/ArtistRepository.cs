using Chinook.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using odataapimodels.Domain.Entities;
using odataapimodels.EFCoreData.Data;

namespace odataapimodels.EFCoreData.Repositories;

public class ArtistRepository(ChinookContext context) : IArtistRepository
{
    private bool ArtistExists(int id) =>
        context.Artists.Any(a => a.Id == id);

    public void Dispose() => context.Dispose();

    public List<Artist> GetAll() =>
        context.Artists.Include(a => a.Albums).AsNoTrackingWithIdentityResolution().ToList();

    public Artist GetById(int id) =>
        context.Artists.Include(a => a.Albums).AsNoTrackingWithIdentityResolution().FirstOrDefault(a => a.Id == id);

    public Artist Add(Artist newArtist)
    {
        context.Artists.Add(newArtist);
        context.SaveChanges();
        return newArtist;
    }

    public bool Update(Artist artist)
    {
        if (!ArtistExists(artist.Id))
            return false;
        context.Artists.Update(artist);
        context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        if (!ArtistExists(id))
            return false;
        var toRemove = context.Artists.Find(id);
        context.Artists.Remove(toRemove);
        context.SaveChanges();
        return true;
    }
}