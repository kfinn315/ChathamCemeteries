using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Core.Entities;
using Project.Core.Interfaces;

namespace Project.API.Controllers;

[Route("[controller]")]
[ApiController]
public class CemeteryController : ControllerBase
{
    private readonly ILogger<CemeteryController> _logger;
    private readonly ICemeteryRepository cemeteryRepository;

    public CemeteryController(ILogger<CemeteryController> logger, ICemeteryRepository cemeteryRepository)
    {
        _logger = logger;
        this.cemeteryRepository = cemeteryRepository;
    }

    [HttpGet(Name = "GetCemeteries")]
    public IList<CemeteryModel> Get()
    {
        return cemeteryRepository.Get().Take(100).ToList();
    }
}
