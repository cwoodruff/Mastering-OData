using odataapimodels.Domain.Entities;

namespace Chinook.Domain.Repositories;

public interface IMediaTypeRepository : IDisposable
{
    List<MediaType> GetAll();
    MediaType GetById(int id);
    MediaType Add(MediaType newMediaType);
    bool Update(MediaType mediaType);
    bool Delete(int id);
}