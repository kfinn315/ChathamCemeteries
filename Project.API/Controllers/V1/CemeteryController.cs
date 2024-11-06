using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Project.Core.Common;
using Project.Core.Entities.Business;
using Project.Core.Interfaces.IServices;

namespace Project.API.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
public class CemeteryController : ControllerBase
{
    private readonly ILogger<CemeteryController> _logger;
    private readonly ICemeteryService cemeteryService;

    public CemeteryController(ILogger<CemeteryController> logger, ICemeteryService cemeteryService)
    {
        _logger = logger;
        this.cemeteryService = cemeteryService;
    }

    [HttpGet("paginated-data")]
    public async Task<IActionResult> Get(int? pageNumber, int? pageSize, string? search, string? sortBy, string? sortOrder, CancellationToken cancellationToken)
    {
        try
        {
            int pageSizeValue = pageSize ?? 10;
            int pageNumberValue = pageNumber ?? 1;
            sortBy = sortBy ?? "Id";
            sortOrder = sortOrder ?? "desc";

            var filters = new List<ExpressionFilter>();
            if (!string.IsNullOrWhiteSpace(search) && search != null)
            {
                // Add filters for relevant properties
                filters.AddRange(new[]
                {
                        new ExpressionFilter
                        {
                            PropertyName = "Name",
                            Value = search,
                            Comparison = Comparison.Contains
                        },
                        new ExpressionFilter
                        {
                            PropertyName = "Description",
                            Value = search,
                            Comparison = Comparison.Contains
                        }
                    });

                // // Check if the search string represents a valid numeric value for the "Price" property
                // if (double.TryParse(search, out double price))
                // {
                //     filters.Add(new ExpressionFilter
                //     {
                //         PropertyName = "Price",
                //         Value = price,
                //         Comparison = Comparison.Equal
                //     });
                // }
            }

            var cemeteries = await cemeteryService.GetPaginatedData(pageNumberValue, pageSizeValue, filters, sortBy, sortOrder, cancellationToken);

            var response = new ResponseViewModel<PaginatedDataViewModel<CemeteryViewModel>>
            {
                Success = true,
                Message = "Cemeteries retrieved successfully",
                Data = cemeteries
            };

            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while retrieving cemeteries");

            var errorResponse = new ResponseViewModel<IEnumerable<CemeteryViewModel>>
            {
                Success = false,
                Message = "Error retrieving products",
                Error = new ErrorViewModel
                {
                    Code = "ERROR_CODE",
                    Message = ex.Message
                }
            };

            return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        try
        {
            var cemeteries = (await cemeteryService.GetAll(cancellationToken)).Take(100).ToList();
            var response = new ResponseViewModel<IList<CemeteryViewModel>>() { Success = true, Message = "Cemeteries retrieved successfully", Data = cemeteries };
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while retrieving cemeteries");

            var errorResponse = new ResponseViewModel<IEnumerable<CemeteryViewModel>>
            {
                Success = false,
                Message = "Error retrieving cemeteries",
                Error = new ErrorViewModel
                {
                    Code = "ERROR_CODE",
                    Message = ex.Message
                }
            };

            return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
        }
    }

    [HttpGet("summary")]
    public async Task<IActionResult> GetSummary(int id, CancellationToken cancellationToken)
    {
        try
        {
            var summary = await cemeteryService.GetDecadeSummary(id, cancellationToken);
            var response = new ResponseViewModel<NodeViewModel>() { Success = true, Message = "Cemetery retrieved successfully", Data = summary };
            return Ok(response);
        }
        catch (Exception ex)
        {
            if (ex.Message == "No data found")
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseViewModel<IEnumerable<NodeViewModel>>
                {
                    Success = false,
                    Message = "Cemetery not found",
                    Error = new ErrorViewModel
                    {
                        Code = "NOT_FOUND",
                        Message = "Cemetery not found"
                    }
                });
            }

            _logger.LogError(ex, $"An error occurred while retrieving the cemetery");

            var errorResponse = new ResponseViewModel<IEnumerable<NodeViewModel>>
            {
                Success = false,
                Message = "Error retrieving cemetery",
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
    public async Task<IActionResult> Get(int id, bool includeGraves, CancellationToken cancellationToken)
    {
        try
        {
            CemeteryViewModel? cemetery;
            if (includeGraves)
            {
                cemetery = await cemeteryService.GetByIdWithGraves(id, cancellationToken);
            }
            else
            {
                cemetery = await cemeteryService.GetById(id, cancellationToken);
            }
            var response = new ResponseViewModel<CemeteryViewModel>() { Success = true, Message = "Cemetery retrieved successfully", Data = cemetery };
            return Ok(response);
        }
        catch (Exception ex)
        {
            if (ex.Message == "No data found")
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseViewModel<CemeteryViewModel>
                {
                    Success = false,
                    Message = "Cemetery not found",
                    Error = new ErrorViewModel
                    {
                        Code = "NOT_FOUND",
                        Message = "Cemetery not found"
                    }
                });
            }

            _logger.LogError(ex, $"An error occurred while retrieving the cemetery");

            var errorResponse = new ResponseViewModel<CemeteryViewModel>
            {
                Success = false,
                Message = "Error retrieving cemetery",
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
