using FluentValidation;
using odataapimodels.Domain.ApiModels;
using odataapimodels.Domain.Entities;

namespace odataapimodels.Domain.Supervisor;

public partial class ChinookSupervisor
{
    public List<MediaTypeApiModel> GetAllMediaType()
    {
        var mediaTypes = _mediaTypeRepository.GetAll().Select(mapper.Map<MediaTypeApiModel>).ToList();

        return mediaTypes;
    }

    public MediaTypeApiModel? GetMediaTypeById(int id)
    {
        var mediaType = _mediaTypeRepository.GetById(id);
        var mediaTypeApiModel = _mapper.Map<MediaTypeApiModel>(mediaType);

        return mediaTypeApiModel;
    }

    public MediaTypeApiModel AddMediaType(MediaTypeApiModel newMediaTypeApiModel)
    {
        _mediaTypeValidator.ValidateAndThrowAsync(newMediaTypeApiModel);
        var mediaType = _mapper.Map<MediaType>(newMediaTypeApiModel);
        mediaType = _mediaTypeRepository.Add(mediaType);
        newMediaTypeApiModel.Id = mediaType.Id;
        return newMediaTypeApiModel;
    }

    public bool UpdateMediaType(MediaTypeApiModel mediaTypeApiModel)
    {
        _mediaTypeValidator.ValidateAndThrowAsync(mediaTypeApiModel);
        var mediaType = _mapper.Map<MediaType>(mediaTypeApiModel);
        return _mediaTypeRepository.Update(mediaType);
    }

    public bool DeleteMediaType(int id)
        => _mediaTypeRepository.Delete(id);
}