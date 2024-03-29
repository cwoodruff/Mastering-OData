using System.Runtime.InteropServices;
using Chinook.Restier.Controllers;
using Chinook.Restier.Data;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Restier.AspNetCore;
using Microsoft.Restier.Core;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

var connection = String.Empty;

if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
    connection = configuration.GetConnectionString("ChinookDbWindows");
else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ||
         RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
    connection = configuration.GetConnectionString("ChinookDbDocker");

builder.Services.AddRestier((builder) =>
{
    builder.AddRestierApi<ChinookApi>(routeServices =>
    {
        routeServices
            .AddEFCoreProviderServices<ChinookContext>((services, options) =>
                options.UseSqlServer(connection))
            .AddSingleton(new ODataValidationSettings
            {
                MaxTop = 100,
                MaxAnyAllExpressionDepth = 5,
                MaxExpansionDepth = 5,
            });

    });
});

builder.Services.AddRestierSwagger();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseRestierBatching();
app.UseRouting();

app.UseHttpsRedirection();

app.UseEndpoints(endpoints =>
{
    endpoints.Select().Expand().Filter().OrderBy().MaxTop(100).Count().SetTimeZoneInfo(TimeZoneInfo.Utc);
    endpoints.MapRestier(builder =>
    {
        builder.MapApiRoute<ChinookApi>("odata", "", true);
    });
});

app.UseRestierSwagger(true);

app.Run();