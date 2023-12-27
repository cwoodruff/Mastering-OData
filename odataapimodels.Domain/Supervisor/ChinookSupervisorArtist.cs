using FluentValidation;
using odataapimodels.Domain.ApiModels;
using odataapimodels.Domain.Entities;

namespace odataapimodels.Domain.Supervisor;

public partial class ChinookSupervisor
{
    public List<ArtistApiModel> GetAllArtist()
    {
        var artists = artistRepository.GetAll().Select(mapper.Map<ArtistApiModel>).ToList();

        return artists;
    }

    public ArtistApiModel GetArtistById(int id)
    {
        var artist = artistRepository.GetById(id);
        var artistApiModel = _mapper.Map<ArtistApiModel>(artist);

        return artistApiModel;
    }

    public ArtistApiModel AddArtist(ArtistApiModel newArtistApiModel)
    {
        _artistValidator.ValidateAndThrowAsync(newArtistApiModel);
        var artist = _mapper.Map<Artist>(newArtistApiModel);
        
        artist = artistRepository.Add(artist);
        newArtistApiModel.Id = artist.Id;
        return newArtistApiModel;
    }

    public bool UpdateArtist(ArtistApiModel artistApiModel)
    {
        _artistValidator.ValidateAndThrowAsync(artistApiModel);
        var artist = _mapper.Map<Artist>(artistApiModel);

        return artistRepository.Update(artist);
    }

    public bool DeleteArtist(int id)
        => artistRepository.Delete(id);
}