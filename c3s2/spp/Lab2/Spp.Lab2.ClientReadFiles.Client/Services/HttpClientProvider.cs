using System.Net.Http.Headers;

namespace Spp.Lab2.ClientReadFiles.Client.Services;

public class HttpClientProvider(IHttpClientFactory clientFactory)
{
    public HttpClient CreateClient()
    {
        var httpClient = clientFactory.CreateClient();
        httpClient.DefaultRequestHeaders.Accept.Clear();
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        return httpClient;
    }
}