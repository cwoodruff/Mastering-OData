using Chinook.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using odataapimodels.Domain.Entities;
using odataapimodels.EFCoreData.Data;

namespace odataapimodels.EFCoreData.Repositories;

public class GenreRepository(ChinookContext context) : IGenreRepository
{
    private bool GenreExists(int id) =>
        context.Genres.Any(g => g.Id == id);

    public void Dispose() => context.Dispose();

    public List<Genre> GetAll() =>
        context.Genres.AsNoTrackingWithIdentityResolution().ToList();

    public Genre GetById(int id)
    {
        var dbGenre = context.Genres.Include(g => g.Tracks).AsNoTrackingWithIdentityResolution().FirstOrDefault(g => g.Id == id);
        return dbGenre;
    }

    public Genre Add(Genre newGenre)
    {
        context.Genres.Add(newGenre);
        context.SaveChanges();
        return newGenre;
    }

    public bool Update(Genre genre)
    {
        if (!GenreExists(genre.Id))
            return false;
        context.Genres.Update(genre);
        context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        if (!GenreExists(id))
            return false;
        var toRemove = context.Genres.Find(id);
        context.Genres.Remove(toRemove);
        context.SaveChanges();
        return true;
    }
}