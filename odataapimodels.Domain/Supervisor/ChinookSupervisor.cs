using AutoMapper;
using Chinook.Domain.Repositories;
using FluentValidation;
using odataapimodels.Domain.ApiModels;

namespace odataapimodels.Domain.Supervisor;

public partial class ChinookSupervisor(IAlbumRepository albumRepository,
        IArtistRepository artistRepository,
        ICustomerRepository customerRepository,
        IEmployeeRepository employeeRepository,
        IGenreRepository genreRepository,
        IInvoiceLineRepository invoiceLineRepository,
        IInvoiceRepository invoiceRepository,
        IMediaTypeRepository mediaTypeRepository,
        IPlaylistRepository playlistRepository,
        ITrackRepository trackRepository,
        IValidator<AlbumApiModel> albumValidator,
        IValidator<ArtistApiModel> artistValidator,
        IValidator<CustomerApiModel> customerValidator,
        IValidator<EmployeeApiModel> employeeValidator,
        IValidator<GenreApiModel> genreValidator,
        IValidator<InvoiceApiModel> invoiceValidator,
        IValidator<InvoiceLineApiModel> invoiceLineValidator,
        IValidator<MediaTypeApiModel> mediaTypeValidator,
        IValidator<PlaylistApiModel> playlistValidator,
        IValidator<TrackApiModel> trackValidator,
        IMapper mapper)
    : IChinookSupervisor
{
    private readonly IAlbumRepository _albumRepository = albumRepository;
    private readonly IArtistRepository _artistRepository = artistRepository;
    private readonly ICustomerRepository _customerRepository = customerRepository;
    private readonly IEmployeeRepository _employeeRepository = employeeRepository;
    private readonly IGenreRepository _genreRepository = genreRepository;
    private readonly IInvoiceLineRepository _invoiceLineRepository = invoiceLineRepository;
    private readonly IInvoiceRepository _invoiceRepository = invoiceRepository;
    private readonly IMediaTypeRepository _mediaTypeRepository = mediaTypeRepository;
    private readonly IPlaylistRepository _playlistRepository = playlistRepository;
    private readonly ITrackRepository _trackRepository = trackRepository;

    private readonly IValidator<AlbumApiModel> _albumValidator = albumValidator;
    private readonly IValidator<ArtistApiModel> _artistValidator = artistValidator;
    private readonly IValidator<CustomerApiModel> _customerValidator = customerValidator;
    private readonly IValidator<EmployeeApiModel> _employeeValidator = employeeValidator;
    private readonly IValidator<GenreApiModel> _genreValidator = genreValidator;
    private readonly IValidator<InvoiceApiModel> _invoiceValidator = invoiceValidator;
    private readonly IValidator<InvoiceLineApiModel> _invoiceLineValidator = invoiceLineValidator;
    private readonly IValidator<MediaTypeApiModel> _mediaTypeValidator = mediaTypeValidator;
    private readonly IValidator<PlaylistApiModel> _playlistValidator = playlistValidator;
    private readonly IValidator<TrackApiModel> _trackValidator = trackValidator;
    private readonly IMapper _mapper = mapper;
}