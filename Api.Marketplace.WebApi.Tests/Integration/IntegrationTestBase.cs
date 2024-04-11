using Shouldly;
using System.Text;
using System.Text.Json;

namespace Api.Marketplace.WebApi.Tests.Integration;

public class IntegrationTestBase : CustomWebApplicationFactory
{
    protected static async Task<T?> DeserializeResponseBody<T>(HttpResponseMessage? httpResponseMessage)
    {
        httpResponseMessage.ShouldNotBeNull();
        var contentAsString = await httpResponseMessage.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(contentAsString);
    }

    protected static StringContent SerializeContent(object obj)
    {
        return new StringContent(
            JsonSerializer.Serialize(obj),
            Encoding.UTF8,
            "application/json"
        );
    }
}
