using Chinook.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using odataapimodels.Domain.Entities;
using odataapimodels.EFCoreData.Data;

namespace odataapimodels.EFCoreData.Repositories;

public class MediaTypeRepository(ChinookContext context) : IMediaTypeRepository
{
    private bool MediaTypeExists(int id) =>
        context.MediaTypes.Any(i => i.Id == id);

    public void Dispose() => context.Dispose();

    public List<MediaType> GetAll() =>
        context.MediaTypes.AsNoTrackingWithIdentityResolution().ToList();

    public MediaType GetById(int id) =>
        context.MediaTypes.Include(m => m.Tracks).AsNoTrackingWithIdentityResolution().FirstOrDefault(m => m.Id == id);

    public MediaType Add(MediaType newMediaType)
    {
        context.MediaTypes.Add(newMediaType);
        context.SaveChanges();
        return newMediaType;
    }

    public bool Update(MediaType mediaType)
    {
        if (!MediaTypeExists(mediaType.Id))
            return false;
        context.MediaTypes.Update(mediaType);
        context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        if (!MediaTypeExists(id))
            return false;
        var toRemove = context.MediaTypes.Find(id);
        context.MediaTypes.Remove(toRemove);
        context.SaveChanges();
        return true;
    }
}