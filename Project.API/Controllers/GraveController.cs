using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Core.Entities;
using Project.Core.Interfaces;

namespace Project.API.Controllers;

[Route("[controller]")]
[ApiController]
public class GraveController : ControllerBase
{
    private readonly ILogger<GraveController> _logger;
    private readonly IGraveRepository graveRepository;

    public GraveController(ILogger<GraveController> logger, IGraveRepository graveRepository)
    {
        _logger = logger;
        this.graveRepository = graveRepository;
    }

    [HttpGet(Name = "GetGraves")]
    public IList<GraveModel> Get(int? minYear, int? maxYear, string? lastName)
    {
        var set = graveRepository.Get().AsQueryable();

        if (minYear.HasValue)
        {
            set = set.Where(x => x.DeathYear >= minYear.Value);
        }
        if (maxYear.HasValue)
        {
            set = set.Where(x => x.DeathYear <= maxYear.Value);
        }
        if (!string.IsNullOrEmpty(lastName))
        {
            set = set.Where(x => !string.IsNullOrEmpty(x.Name) && x.Name.StartsWith(lastName));
        }

        return set.Take(100).ToList();
    }
}
