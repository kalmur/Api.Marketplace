using Newtonsoft.Json;
using System.Net;

namespace Api.Marketplace.Application.Models;

public class ApiResult
{
    public HttpStatusCode StatusCode { get; set; }

    public bool Succeeded { get; set; }

    public string Message { get; set; }

    public HttpResponseMessage Response { get; set; }
}

public sealed class ApiResult<T> : ApiResult
{
    public T Item { get; set; }

    public static async Task<ApiResult<T>> FromResponseAsync(HttpResponseMessage response)
    {
        var result = new ApiResult<T>
        {
            Response = response,
            StatusCode = response.StatusCode,
            Succeeded = response.IsSuccessStatusCode,
        };

        if (result.Succeeded)
        {
            var body = await response.Content.ReadAsStringAsync();
            result.Item = JsonConvert.DeserializeObject<T>(body);
        }
        else
        {
            result.Message = await GetErrorMessage(response.Content);
        }

        return result;
    }

    private static async Task<string> GetErrorMessage(HttpContent content)
    {
        var contentAsString = await content.ReadAsStringAsync().ConfigureAwait(false);
        if (string.IsNullOrEmpty(contentAsString))
        {
            return "An error occurred";
        }
        var definition = new { Message = "" };
        try
        {
            var apiResult = JsonConvert.DeserializeAnonymousType(contentAsString, definition);
            return apiResult?.Message ?? string.Empty;
        }
        catch (Exception)
        {
            return contentAsString;
        }
    }
}
