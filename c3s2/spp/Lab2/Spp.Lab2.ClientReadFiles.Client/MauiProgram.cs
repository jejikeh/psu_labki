using Microsoft.Extensions.Logging;
using Spp.Lab2.ClientReadFiles.Client.Services;

namespace Spp.Lab2.ClientReadFiles.Client;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services
			.AddTransient<MainPage>()
			.AddHttpClient()
			.AddSingleton<HttpClientProvider>()
			.AddSingleton<CacheHttpClientService>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
