namespace TakPhone;

using Esri.ArcGISRuntime;
using Esri.ArcGISRuntime.Maui;

using Microsoft.Extensions.Logging;

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

        builder.UseArcGISRuntime(config => config.UseApiKey("AAPK6973dae222c249dfb49eaf0d688284ac_98K8oJneuaT8ECk9f61O5Oea0TznXb20VxvVnzkBJ29fie9TmFZffQhI9zCdrtP"));

        builder.Services.AddBlazorWebView();

        builder.Services.AddMauiBlazorWebView();
#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
#endif
      
        return builder.Build();
	}
}
