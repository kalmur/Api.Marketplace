using Api.Marketplace.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;

namespace Api.Marketplace.WebApi.Services;

public class HttpResponse : IHttpResponse
{
    public ObjectResult Forbidden(string? errorMessage = default)
    {
        return new ObjectResult(
            new ProblemDetails
            {
                Type = "https://www.rfc-editor.org/rfc/rfc7231#section-6.5.3",
                Title = "Forbidden.",
                Detail = errorMessage ?? "Access to resource is Forbidden.",
                Status = StatusCodes.Status403Forbidden
            }
        )
        {
            StatusCode = StatusCodes.Status403Forbidden
        };
    }

    public NotFoundObjectResult NotFound(string? errorMessage = default)
    {
        return new NotFoundObjectResult(new ProblemDetails
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
            Title = "Not Found.",
            Detail = errorMessage ?? "The requested resource could not be found.",
            Status = StatusCodes.Status404NotFound
        });
    }

    public ObjectResult InternalServerError(string? errorMessage = default)
    {
        return new ObjectResult(
            new ProblemDetails
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                Title = "Internal Server Error.",
                Detail = errorMessage ?? "An unexpected error occurred.",
                Status = StatusCodes.Status500InternalServerError
            }
        )
        {
            StatusCode = StatusCodes.Status500InternalServerError
        };
    }

    public BadRequestObjectResult BadRequest(IDictionary<string, string[]> errors, string? errorMessage = default)
    {
        return new BadRequestObjectResult(
            new ValidationProblemDetails(errors)
            {
                Type = "https://www.rfc-editor.org/rfc/rfc7231#section-6.5.1",
                Title = "Bad Request.",
                Detail = errorMessage ?? "One or more validation errors occurred.",
                Status = StatusCodes.Status400BadRequest
            }
        );
    }

    public BadRequestObjectResult BadRequest(ModelStateDictionary modelStateDictionary, string? errorMessage = default)
    {
        return new BadRequestObjectResult(
            new ValidationProblemDetails(modelStateDictionary)
            {
                Type = "https://www.rfc-editor.org/rfc/rfc7231#section-6.5.1",
                Title = "Bad Request.",
                Detail = errorMessage ?? "One or more validation errors occurred.",
                Status = StatusCodes.Status400BadRequest,
            });
    }

    public ObjectResult Conflict(string? errorMessage = default)
    {
        return new ObjectResult(
            new ProblemDetails
            {
                Type = "https://www.rfc-editor.org/rfc/rfc7231#section-6.5.8",
                Title = "Conflict.",
                Detail = errorMessage ?? "Conflict with the target resource.",
                Status = StatusCodes.Status409Conflict
            }
        )
        {
            StatusCode = StatusCodes.Status409Conflict
        };
    }

    public ObjectResult UnprocessableEntity(string? errorMessage = null)
    {
        return new ObjectResult(
            new ProblemDetails
            {
                Type = "https://www.rfc-editor.org/rfc/rfc4918#section-11.2",
                Title = "Unprocessable Entity.",
                Detail = errorMessage ?? "Invalid or incomplete data.",
                Status = StatusCodes.Status422UnprocessableEntity
            }
        )
        {
            StatusCode = StatusCodes.Status422UnprocessableEntity
        };
    }
}
