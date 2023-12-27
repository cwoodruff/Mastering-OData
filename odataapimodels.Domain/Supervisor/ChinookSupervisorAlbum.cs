using FluentValidation;
using odataapimodels.Domain.ApiModels;
using odataapimodels.Domain.Entities;

namespace odataapimodels.Domain.Supervisor;

public partial class ChinookSupervisor
{
    public List<AlbumApiModel> GetAllAlbum()
    {
        var albums = albumRepository.GetAll().Select(mapper.Map<AlbumApiModel>).ToList();

        return albums;
    }

    public AlbumApiModel? GetAlbumById(int id)
    {
        var album = _albumRepository.GetById(id);
        var albumApiModel = _mapper.Map<AlbumApiModel>(album);

        return albumApiModel;
    }

    public List<AlbumApiModel> GetAlbumByArtistId(int id)
    {
        var albums = _albumRepository.GetByArtistId(id).Select(mapper.Map<AlbumApiModel>).ToList();
        return albums;
    }

    public AlbumApiModel AddAlbum(AlbumApiModel newAlbumApiModel)
    {
        _albumValidator.ValidateAndThrowAsync(newAlbumApiModel);

        var album = _mapper.Map<Album>(newAlbumApiModel);

        album = _albumRepository.Add(album);
        newAlbumApiModel.Id = album.Id;
        return newAlbumApiModel;
    }

    public bool UpdateAlbum(AlbumApiModel albumApiModel)
    {
        _albumValidator.ValidateAndThrowAsync(albumApiModel);
        var album = _mapper.Map<Album>(albumApiModel);

        return _albumRepository.Update(album);
    }

    public bool DeleteAlbum(int id)
        => _albumRepository.Delete(id);
}