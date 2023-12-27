﻿using odataapimodels.Domain.Entities;

namespace Chinook.Domain.Repositories;

public interface IGenreRepository : IDisposable
{
    List<Genre> GetAll();
    Genre GetById(int id);
    Genre Add(Genre newGenre);
    bool Update(Genre genre);
    bool Delete(int id);
}