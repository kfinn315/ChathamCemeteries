using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using Project.Core.Interfaces.IRepositories;
using Project.Core.Entities.Business;
using Project.Core.Interfaces.IServices;

namespace Project.API.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
public class GraveController : ControllerBase
{
    private readonly ILogger<GraveController> _logger;
    private readonly IGraveService graveService;

    public GraveController(ILogger<GraveController> logger, IGraveService graveService)
    {
        _logger = logger;
        this.graveService = graveService;
    }

    [HttpGet(Name = "GetGraves")]
    public async Task<IList<GraveViewModel>> Get(int? minYear, int? maxYear, string? lastName, CancellationToken cancellationToken)
    {
        var set = (await graveService.GetAll(cancellationToken)).AsQueryable();

        // if (minYear.HasValue)
        // {
        //     set = set.Where(x => x.DeathYear >= minYear.Value);
        // }
        // if (maxYear.HasValue)
        // {
        //     set = set.Where(x => x.DeathYear <= maxYear.Value);
        // }
        if (!string.IsNullOrEmpty(lastName))
        {
            set = set.Where(x => !string.IsNullOrEmpty(x.Name) && x.Name.StartsWith(lastName));
        }

        return set.Take(100).ToList();
    }
}
