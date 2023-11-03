namespace TakPhone;

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
                fonts.AddFont("fa-solid-900.ttf", "FontSolid");
            });

        builder.Services.AddBlazorWebView();

        builder.Services.AddMauiBlazorWebView();
#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
#endif
        // Register any app services on the IServiceCollection object
        // e.g. builder.Services.AddSingleton<WeatherForecastService>();
        return builder.Build();
	}
}
