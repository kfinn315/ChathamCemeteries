using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Core.Entities.Business;
using Project.Core.Interfaces.IRepositories;
using Project.Core.Interfaces.IServices;

namespace Project.API.Controllers;

[Route("[controller]")]
[ApiController]
public class CemeteryController : ControllerBase
{
    private readonly ILogger<CemeteryController> _logger;
    private readonly ICemeteryService cemeteryService;

    public CemeteryController(ILogger<CemeteryController> logger, ICemeteryService cemeteryService)
    {
        _logger = logger;
        this.cemeteryService = cemeteryService;
    }

    [HttpGet(Name = "GetCemeteries")]
    public async Task<IList<CemeteryViewModel>> Get(CancellationToken cancellationToken)
    {
        return (await cemeteryService.GetAll(cancellationToken)).Take(100).ToList();
    }
}
