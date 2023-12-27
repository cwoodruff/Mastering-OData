using odataapimodels.Domain.ApiModels;

namespace odataapimodels.Domain.Supervisor;

public interface IChinookSupervisor
{
    List<AlbumApiModel> GetAllAlbum();
    AlbumApiModel GetAlbumById(int id);
    List<AlbumApiModel> GetAlbumByArtistId(int id);

    AlbumApiModel AddAlbum(AlbumApiModel newAlbumApiModel);

    bool UpdateAlbum(AlbumApiModel albumApiModel);
    bool DeleteAlbum(int id);
    List<ArtistApiModel> GetAllArtist();
    ArtistApiModel GetArtistById(int id);

    ArtistApiModel AddArtist(ArtistApiModel newArtistApiModel);

    bool UpdateArtist(ArtistApiModel artistApiModel);

    bool DeleteArtist(int id);
    List<CustomerApiModel> GetAllCustomer();
    CustomerApiModel GetCustomerById(int id);

    List<CustomerApiModel> GetCustomerBySupportRepId(int id);

    CustomerApiModel AddCustomer(CustomerApiModel newCustomerApiModel);

    bool UpdateCustomer(CustomerApiModel customerApiModel);

    bool DeleteCustomer(int id);
    List<EmployeeApiModel> GetAllEmployee();
    EmployeeApiModel GetEmployeeById(int id);
    EmployeeApiModel GetEmployeeReportsTo(int id);

    EmployeeApiModel AddEmployee(EmployeeApiModel newEmployeeApiModel);

    bool UpdateEmployee(EmployeeApiModel employeeApiModel);

    bool DeleteEmployee(int id);

    List<EmployeeApiModel> GetEmployeeDirectReports(int id);

    List<EmployeeApiModel> GetDirectReports(int id);
    List<GenreApiModel> GetAllGenre();
    GenreApiModel GetGenreById(int id);

    GenreApiModel AddGenre(GenreApiModel newGenreApiModel);

    bool UpdateGenre(GenreApiModel genreApiModel);
    bool DeleteGenre(int id);
    List<InvoiceLineApiModel> GetAllInvoiceLine();
    InvoiceLineApiModel GetInvoiceLineById(int id);

    List<InvoiceLineApiModel> GetInvoiceLineByInvoiceId(int id);

    List<InvoiceLineApiModel> GetInvoiceLineByTrackId(int id);

    InvoiceLineApiModel AddInvoiceLine(InvoiceLineApiModel newInvoiceLineApiModel);

    bool UpdateInvoiceLine(InvoiceLineApiModel invoiceLineApiModel);

    bool DeleteInvoiceLine(int id);
    List<InvoiceApiModel> GetAllInvoice();
    InvoiceApiModel GetInvoiceById(int id);

    List<InvoiceApiModel> GetInvoiceByCustomerId(int id);

    InvoiceApiModel AddInvoice(InvoiceApiModel newInvoiceApiModel);

    bool UpdateInvoice(InvoiceApiModel invoiceApiModel);

    bool DeleteInvoice(int id);

    List<InvoiceApiModel> GetInvoiceByEmployeeId(int id);

    List<MediaTypeApiModel> GetAllMediaType();
    MediaTypeApiModel GetMediaTypeById(int id);

    MediaTypeApiModel AddMediaType(MediaTypeApiModel newMediaTypeApiModel);

    bool UpdateMediaType(MediaTypeApiModel mediaTypeApiModel);

    bool DeleteMediaType(int id);
    List<PlaylistApiModel> GetAllPlaylist();
    PlaylistApiModel GetPlaylistById(int id);
    PlaylistApiModel AddPlaylist(PlaylistApiModel newPlaylistApiModel);
    bool UpdatePlaylist(PlaylistApiModel playlistApiModel);
    bool DeletePlaylist(int id);

    List<TrackApiModel> GetAllTrack();
    TrackApiModel GetTrackById(int id);
    List<TrackApiModel> GetTrackByAlbumId(int id);
    List<TrackApiModel> GetTrackByGenreId(int id);
    List<TrackApiModel> GetTrackByMediaTypeId(int id);
    List<TrackApiModel> GetTrackByPlaylistId(int id);
    TrackApiModel AddTrack(TrackApiModel newTrackApiModel);
    bool UpdateTrack(TrackApiModel trackApiModel);
    bool DeleteTrack(int id);
    List<TrackApiModel> GetTrackByArtistId(int id);
    List<TrackApiModel> GetTrackByInvoiceId(int id);
}