using Microsoft.AspNetCore.Mvc;

namespace EchoApi.Controllers;

/// <summary>
/// Controller that provides echo functionality for query strings
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class EchoController : ControllerBase
{
    private readonly ILogger<EchoController> _logger;

    public EchoController(ILogger<EchoController> logger)
    {
        _logger = logger;
    }

    
    [HttpPost("Query")]
    public ActionResult<WorkOrdersRequest> Query([FromBody] WorkOrdersRequest request)
    {
        try
        {
            _logger.LogInformation("Echo POST request received with query: {Query}", request?.Query);

            if (request == null || string.IsNullOrWhiteSpace(request.Query))
            {
                _logger.LogWarning("Empty or null query received in POST request");
                return BadRequest(new { error = "Query in request body cannot be empty" });
            }

            var response = new WorkOrdersResponse
            {
                OriginalQuery = request.Query,
               ResponseToQuery = $"Echo: {request.Query}"
            };

            _logger.LogInformation("Successfully processed echo POST request");
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing echo POST request");
            return StatusCode(500, new { error = "Internal server error occurred" });
        }
    }
}


public class WorkOrdersRequest
{
    public string Query { get; set; } = string.Empty;
}

public class WorkOrdersResponse
{
    public string OriginalQuery { get; set; } = string.Empty;
    public string ResponseToQuery { get; set; } = string.Empty;
}
