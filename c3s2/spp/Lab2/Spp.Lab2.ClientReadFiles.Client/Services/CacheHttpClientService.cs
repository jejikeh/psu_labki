using System.Text.Json;
using Spp.Lab2.ClientReadFiles.Client.Services;

namespace Spp.Lab2.ClientReadFiles.Client;

public class CacheHttpClientService(HttpClientProvider httpClientProvider)
{
    private readonly HttpClient _httpClient = httpClientProvider.CreateClient();
    private static readonly JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public async Task<string?> GetStringAsync(string url, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync(url, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            return default;
        }

        var jsonResult = await response.Content.ReadAsStringAsync(cancellationToken);

        return jsonResult;
    }
}