using Chinook.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using odataapimodels.Domain.Entities;
using odataapimodels.EFCoreData.Data;

namespace odataapimodels.EFCoreData.Repositories;

public class PlaylistRepository(ChinookContext context) : IPlaylistRepository
{
    private bool PlaylistExists(int id) =>
        context.Playlists.Any(i => i.Id == id);

    public void Dispose() => context.Dispose();

    public List<Playlist> GetAll() =>
        context.Playlists.AsNoTrackingWithIdentityResolution().ToList();

    public Playlist GetById(int id) =>
        context.Playlists.Include(p => p.Tracks).AsNoTrackingWithIdentityResolution().FirstOrDefault(p => p.Id == id);

    public Playlist Add(Playlist newPlaylist)
    {
        context.Playlists.Add(newPlaylist);
        context.SaveChanges();
        return newPlaylist;
    }

    public bool Update(Playlist playlist)
    {
        if (!PlaylistExists(playlist.Id))
            return false;
        context.Playlists.Update(playlist);
        context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        if (!PlaylistExists(id))
            return false;
        var toRemove = context.Playlists.Find(id);
        context.Playlists.Remove(toRemove);
        context.SaveChanges();
        return true;
    }

    public List<Playlist> GetByTrackId(int id)
    {
        return context.Playlists
            .Where(c => c.Tracks.Any(o => o.Id == id))
            .AsNoTrackingWithIdentityResolution().ToList();
    }
}