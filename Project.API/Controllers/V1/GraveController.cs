using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using Project.Core.Entities.Business;
using Project.Core.Interfaces.IServices;
using Project.Core.Common;

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

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var set = (await graveService.GetAll(cancellationToken)).AsQueryable();

        try
        {
            return Ok(new ResponseViewModel<IList<GraveViewModel>> { Data = set.Take(100).ToList(), Success = true, Message = "Graves retrieved successfully" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while retrieving graves");

            var errorResponse = new ResponseViewModel<IEnumerable<GraveViewModel>>
            {
                Success = false,
                Message = "Error retrieving graves",
                Error = new ErrorViewModel
                {
                    Code = "ERROR_CODE",
                    Message = ex.Message
                }
            };

            return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
    {
        var grave = await graveService.GetById(id, cancellationToken);

        try
        {
            return Ok(new ResponseViewModel<GraveViewModel> { Data = grave, Success = true, Message = "Grave retrieved successfully" });
        }
        catch (Exception ex)
        {
            if (ex.Message == "No data found")
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseViewModel<GraveViewModel>
                {
                    Success = false,
                    Message = "Grave not found",
                    Error = new ErrorViewModel
                    {
                        Code = "NOT_FOUND",
                        Message = "Grave not found"
                    }
                });
            }

            _logger.LogError(ex, "An error occurred while retrieving grave");

            var errorResponse = new ResponseViewModel<GraveViewModel>
            {
                Success = false,
                Message = "Error retrieving grave",
                Error = new ErrorViewModel
                {
                    Code = "ERROR_CODE",
                    Message = ex.Message
                }
            };

            return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
        }
    }

    [HttpGet("pagination")]
    public async Task<IActionResult> Get(int? pageNumber, int? pageSize, string? search, string? sortBy, string? sortOrder, CancellationToken cancellationToken)
    {
        var pageNumberValue = pageNumber ?? 1;
        var pageSizeValue = pageSize ?? 10;
        sortBy ??= "";
        sortOrder ??= "";

        try
        {
            var filters = new List<ExpressionFilter>();
            if (!string.IsNullOrWhiteSpace(search))
            {
                filters.AddRange(new[] {
                    new ExpressionFilter{
                        PropertyName="Name",
                        Value=search,
                        Comparison=Comparison.Contains
                    }
            });
            }

            var result = await graveService.GetPaginatedData(pageNumberValue, pageSizeValue, filters, sortBy, sortOrder, cancellationToken);
            var response = new ResponseViewModel<PaginatedDataViewModel<GraveViewModel>> { Data = result, Success = true, Message = "Graves retrieved successfully" };
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while retrieving graves");

            var errorResponse = new ResponseViewModel<IEnumerable<GraveViewModel>>
            {
                Success = false,
                Message = "Error retrieving graves",
                Error = new ErrorViewModel
                {
                    Code = "ERROR_CODE",
                    Message = ex.Message
                }
            };

            return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
        }
    }
}
