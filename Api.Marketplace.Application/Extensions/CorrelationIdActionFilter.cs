using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Api.Marketplace.Application.Extensions;

public class CorrelationIdActionFilter : ActionFilterAttribute
{
    private const string CorrelationIdHeaderName = "X-Correlation-ID";

    private ILogger<CorrelationIdActionFilter> _logger;

    public CorrelationIdActionFilter(ILogger<CorrelationIdActionFilter> logger)
    {
        _logger = logger;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.HttpContext.Request.Headers.ContainsKey(CorrelationIdHeaderName))
            context.HttpContext.Request.Headers.Add(CorrelationIdHeaderName, Guid.NewGuid().ToString());

        var correlationId = context.HttpContext.Request.Headers[CorrelationIdHeaderName].First();
        _logger.LogInformation("CorrelationId: {correlationId}", correlationId);
        
        base.OnActionExecuting(context);
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        var correlationId = context.HttpContext.Request.Headers[CorrelationIdHeaderName].First();
        context.HttpContext.Response.Headers.Add(CorrelationIdHeaderName, correlationId);

        base.OnActionExecuted(context);
    }
}
