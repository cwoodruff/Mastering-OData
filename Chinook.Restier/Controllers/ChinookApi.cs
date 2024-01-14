using Chinook.Restier.Data;
using Microsoft.Restier.EntityFrameworkCore;

namespace Chinook.Restier.Controllers;

public partial class ChinookApi(IServiceProvider serviceProvider) : EntityFrameworkApi<ChinookContext>(serviceProvider);