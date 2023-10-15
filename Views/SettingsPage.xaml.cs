namespace TakPhone.Views;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
        InitializeComponent();

        // WebView info: https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/webview?pivots=devices-android

        WebView webvView = new WebView
        {
            Source = "https://learn.microsoft.com/dotnet/maui"
        };
    }
}