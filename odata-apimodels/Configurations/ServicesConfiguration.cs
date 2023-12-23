using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;
using odata_apimodels.Data.Entities;

namespace odata_apimodels.Configurations;

public static class ServicesConfiguration
{
    public static IEdmModel GetEdmModel(this IServiceCollection services)
    {
        ODataConventionModelBuilder builder = new();
        builder.EntitySet<Album>("Albums");
        builder.EntitySet<Artist>("Artists");
        builder.EntitySet<Customer>("Customers");
        builder.EntitySet<Employee>("Employees");
        builder.EntitySet<Genre>("Genres");
        builder.EntitySet<Invoice>("Invoices");
        builder.EntitySet<InvoiceLine>("InvoiceLines");
        builder.EntitySet<MediaType>("MediaTypes");
        builder.EntitySet<Playlist>("Playlists");
        builder.EntitySet<Track>("Tracks");
        return builder.GetEdmModel();
    }
}
