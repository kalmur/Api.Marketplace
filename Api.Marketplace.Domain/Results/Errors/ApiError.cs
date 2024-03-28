using System.Net;
using System.Text.Json;

namespace Api.Marketplace.Domain.Results.Errors
{
    public class ApiError : Error
    {
        public ApiError(HttpStatusCode statusCode, string responseContent)
            : base(ErrorType.Api)
        {
            StatusCode = statusCode;
            ResponseContent = responseContent;
        }

        public HttpStatusCode StatusCode { get; }

        public string ResponseContent { get; }

        public T? DeserializeContent<T>(JsonSerializerOptions? options = default)
        {
            return JsonSerializer.Deserialize<T>(ResponseContent, options);
        }
    }
}
