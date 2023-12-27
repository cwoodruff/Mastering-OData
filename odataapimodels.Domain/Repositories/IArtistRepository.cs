using odataapimodels.Domain.Entities;

namespace Chinook.Domain.Repositories;

public interface IArtistRepository : IDisposable
{
    List<Artist> GetAll();
    Artist GetById(int id);
    Artist Add(Artist newArtist);
    bool Update(Artist artist);
    bool Delete(int id);
}