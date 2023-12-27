using FluentValidation;
using odataapimodels.Domain.ApiModels;
using odataapimodels.Domain.Entities;

namespace odataapimodels.Domain.Supervisor;

public partial class ChinookSupervisor
{
    public List<PlaylistApiModel> GetAllPlaylist()
    {
        var playlists = _playlistRepository.GetAll().Select(mapper.Map<PlaylistApiModel>).ToList();

        return playlists;
    }

    public PlaylistApiModel GetPlaylistById(int id)
    {
        var playlist = _playlistRepository.GetById(id);
        var playlistApiModel = _mapper.Map<PlaylistApiModel>(playlist);

        return playlistApiModel;
    }

    public PlaylistApiModel AddPlaylist(PlaylistApiModel newPlaylistApiModel)
    {
        _playlistValidator.ValidateAndThrowAsync(newPlaylistApiModel);
        var playlist = _mapper.Map<Playlist>(newPlaylistApiModel);
        playlist = _playlistRepository.Add(playlist);
        newPlaylistApiModel.Id = playlist.Id;
        return newPlaylistApiModel;
    }

    public bool UpdatePlaylist(PlaylistApiModel playlistApiModel)
    {
        _playlistValidator.ValidateAndThrowAsync(playlistApiModel);
        var playlist = _mapper.Map<Playlist>(playlistApiModel);
        return _playlistRepository.Update(playlist);
    }

    public bool DeletePlaylist(int id)
        => _playlistRepository.Delete(id);
}