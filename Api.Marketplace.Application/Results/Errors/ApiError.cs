using System.Net;
using System.Text.Json;

namespace Api.Marketplace.Application.Results.Errors
{
    public class ApiError : Error
    {
        public ApiError(HttpStatusCode statusCode, string responseContent)
            : base(ErrorType.Api)
        {
            StatusCode = statusCode;
            ResponseContent = responseContent;
        }

        /// <summary>
        ///     The HttpStatusCode of the API request.
        /// </summary>
        public HttpStatusCode StatusCode { get; }

        /// <summary>
        ///     The response body as a string of the API request.
        /// </summary>
        public string ResponseContent { get; }

        /// <summary>
        ///     Deserializes the <seealso cref="ResponseContent"/> into the required type.
        ///     Uses the <seealso cref="JsonSerializer"/> provided by the System.Text.Json to handle the deserialization.
        /// </summary>
        /// <typeparam name="T">The object type to be deserialized to.</typeparam>
        /// <param name="options">Any options to be considered during the deserialization.</param>
        /// <returns>The deserialized object. Can be null.</returns>
        public T? DeserializeContent<T>(JsonSerializerOptions? options = default)
        {
            return JsonSerializer.Deserialize<T>(ResponseContent, options);
        }
    }
}
