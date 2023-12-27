using odataapimodels.Domain.Entities;

namespace Chinook.Domain.Repositories;

public interface IPlaylistRepository : IDisposable
{
    List<Playlist> GetAll();
    Playlist GetById(int id);
    Playlist Add(Playlist newPlaylist);
    bool Update(Playlist playlist);
    bool Delete(int id);
    List<Playlist> GetByTrackId(int id);
}