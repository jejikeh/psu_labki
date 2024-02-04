using System.Text.Json;

namespace Spp.Lab2.ClientReadFiles.Client;

public partial class MainPage : ContentPage
{
    private readonly CacheHttpClientService _cacheHttpClientService;

    public MainPage(CacheHttpClientService cacheHttpClientService)
    {
        InitializeComponent();

        _cacheHttpClientService = cacheHttpClientService;
    }

    private async void SimpleMessageButtonClicked(object sender, EventArgs e)
    {
        var response = await _cacheHttpClientService.GetStringAsync("http://localhost:5000/simple-message") ?? "Server doesnt response.";

        SimpleMessageLabel.Text = response;
    }

    private async void ImageMessageButtonClicked(object sender, EventArgs e)
    {
        var imageString = await _cacheHttpClientService.GetStringAsync("http://localhost:5000/image") ?? string.Empty;
        var ms = new MemoryStream(Convert.FromBase64String(imageString));
        SimpleImage.Source = ImageSource.FromStream(() => ms);
    }

    private async void JsonMessageButtonClicked(object sender, EventArgs e)
    {
        var content = await _cacheHttpClientService.GetStringAsync("http://localhost:5000/table") ?? string.Empty;
        if (string.IsNullOrEmpty(content))
        {
            return;
        }

        var someData = JsonSerializer.Deserialize<SomeData>(content);
        if (string.IsNullOrEmpty(content))
        {
            return;
        }

        IdTextCell.Detail = someData.Id.ToString();
        NameTextCell.Detail = someData.Name;
        CostTextCell.Detail = someData.Cost.ToString();
    }

    public class SomeData
    {
        public int Id { get; set; } = Random.Shared.Next(10, 199);
        public string Name { get; set; } = "Hello, World";
        public int Cost { get; set; } = Random.Shared.Next(100, 2000);
    }
}

