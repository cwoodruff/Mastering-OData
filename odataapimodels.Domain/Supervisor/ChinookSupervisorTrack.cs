using FluentValidation;
using odataapimodels.Domain.ApiModels;
using odataapimodels.Domain.Entities;

namespace odataapimodels.Domain.Supervisor;

public partial class ChinookSupervisor
{
    public List<TrackApiModel> GetAllTrack()
    {
        var tracks = trackRepository.GetAll().Select(mapper.Map<TrackApiModel>).ToList();

        return tracks;
    }

    public TrackApiModel GetTrackById(int id)
    {
        var track = trackRepository.GetById(id);
        var trackApiModel = _mapper.Map<TrackApiModel>(track);
        return trackApiModel;
    }

    public TrackApiModel AddTrack(TrackApiModel newTrackApiModel)
    {
        trackValidator.ValidateAndThrowAsync(newTrackApiModel);
        var track = _mapper.Map<Track>(newTrackApiModel);
        track = trackRepository.Add(track);
        newTrackApiModel.Id = track.Id;
        return newTrackApiModel;
    }

    public bool UpdateTrack(TrackApiModel trackApiModel)
    {
        trackValidator.ValidateAndThrowAsync(trackApiModel);
        var track = _mapper.Map<Track>(trackApiModel);
        return trackRepository.Update(track);
    }
    
    public bool DeleteTrack(int id)
        => trackRepository.Delete(id);
    
    public List<TrackApiModel>? GetTrackByAlbumId(int id)
    {
        var tracks = trackRepository.GetByAlbumId(id).Select(mapper.Map<TrackApiModel>).ToList();
        return tracks;
    }

    public List<TrackApiModel> GetTrackByGenreId(int id)
    {
        var tracks = trackRepository.GetByGenreId(id).Select(mapper.Map<TrackApiModel>).ToList();
        return tracks;
    }

    public List<TrackApiModel> GetTrackByMediaTypeId(int id)
    {
        var tracks = trackRepository.GetByMediaTypeId(id).Select(mapper.Map<TrackApiModel>).ToList();
        return tracks;
    }

    public List<TrackApiModel> GetTrackByPlaylistId(int id)
    {
        var tracks = trackRepository.GetByPlaylistId(id).Select(mapper.Map<TrackApiModel>).ToList();
        return tracks;
    }

    public List<TrackApiModel> GetTrackByArtistId(int id)
    {
        var tracks = trackRepository.GetByArtistId(id).Select(mapper.Map<TrackApiModel>).ToList();
        return tracks;
    }

    public List<TrackApiModel> GetTrackByInvoiceId(int id)
    {
        var tracks = trackRepository.GetByInvoiceId(id).Select(mapper.Map<TrackApiModel>).ToList();
        return tracks;
    }
}