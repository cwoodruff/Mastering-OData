using FluentValidation;
using odataapimodels.Domain.ApiModels;
using odataapimodels.Domain.Entities;

namespace odataapimodels.Domain.Supervisor;

public partial class ChinookSupervisor
{
    public List<GenreApiModel> GetAllGenre()
    {
        var genres = genreRepository.GetAll().Select(mapper.Map<GenreApiModel>).ToList();

        return genres;
    }

    public GenreApiModel? GetGenreById(int id)
    {
        var genre = _genreRepository.GetById(id);
        var genreApiModel = _mapper.Map<GenreApiModel>(genre);

        return genreApiModel;
    }

    public GenreApiModel AddGenre(GenreApiModel newGenreApiModel)
    {
        _genreValidator.ValidateAndThrowAsync(newGenreApiModel);
        var genre = _mapper.Map<Genre>(newGenreApiModel);
        genre = _genreRepository.Add(genre);
        newGenreApiModel.Id = genre.Id;
        return newGenreApiModel;
    }

    public bool UpdateGenre(GenreApiModel genreApiModel)
    {
        _genreValidator.ValidateAndThrowAsync(genreApiModel);
        var genre = _mapper.Map<Genre>(genreApiModel);
        return _genreRepository.Update(genre);
    }

    public bool DeleteGenre(int id)
        => _genreRepository.Delete(id);
}